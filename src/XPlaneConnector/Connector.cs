using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XPlaneConnector
{
    public class Connector : IDisposable
    {
        private const int CheckInterval_ms = 1000;
        private TimeSpan MaxDataRefAge = TimeSpan.FromSeconds(5);

        private CultureInfo EnCulture = new CultureInfo("en-US");

        private UdpClient server;
        private UdpClient client;
        private IPEndPoint XPlaneEP;
        private CancellationTokenSource ts;
        private Task serverTask;
        private Task observerTask;

        public delegate void RawReceiveHandler(string raw);
        public event RawReceiveHandler OnRawReceive;

        public delegate void DataRefReceived(DataRefElement dataRef);
        public event DataRefReceived OnDataRefReceived;

        public delegate void LogHandler(string message);
        public event LogHandler OnLog;

        private Dictionary<int, DataRefElement> DataRefs = new Dictionary<int, DataRefElement>();

        public DateTime LastReceive { get; internal set; }
        public byte[] LastBuffer { get; internal set; }
        public IPEndPoint LocalEP => ((IPEndPoint)client.Client.LocalEndPoint);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ip">IP of the machine running X-Plane, default 127.0.0.1 (localhost)</param>
        /// <param name="xplanePort">Port the machine running X-Plane is listening for, default 49000</param>
        public Connector(string ip = "127.0.0.1", int xplanePort = 49000)
        {
            XPlaneEP = new IPEndPoint(IPAddress.Parse(ip), xplanePort);
        }

        /// <summary>
        /// Initialize the communication with X-Plane machine and starts listening for DataRefs
        /// </summary>
        public void Start()
        {
            client = new UdpClient();
            client.Connect(XPlaneEP.Address, XPlaneEP.Port);

            server = new UdpClient(LocalEP);

            ts = new CancellationTokenSource();
            var token = ts.Token;

            serverTask = Task.Factory.StartNew(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    var response = await server.ReceiveAsync().ConfigureAwait(false);
                    var raw = Encoding.UTF8.GetString(response.Buffer);
                    LastReceive = DateTime.Now;
                    LastBuffer = response.Buffer;

                    OnRawReceive?.Invoke(raw);
                    ParseResponse(response.Buffer);
                }

                OnLog?.Invoke("Stopping server");
                server.Close();
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            observerTask = Task.Factory.StartNew(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    foreach (var dr in DataRefs.Values.Where(d => d.Age > MaxDataRefAge))
                        RequestDataRef(dr);
                    await Task.Delay(CheckInterval_ms).ConfigureAwait(false);
                }

            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        /// <summary>
        /// Stops the comunications with the X-Plane machine
        /// </summary>
        /// <param name="timeout"></param>
        public void Stop(int timeout = 5000)
        {
            if (client == null) return;
            foreach (var dr in DataRefs.Values.ToList())
                Unsubscribe(dr);

            if (ts == null) return;

            ts.Cancel();
            Task.WaitAll(new[] { serverTask, observerTask }, timeout);
            ts.Dispose();
            ts = null;

            client.Close();
        }
        private void ParseResponse(byte[] buffer)
        {
            var pos = 0;
            var header = Encoding.UTF8.GetString(buffer, pos, 4);
            pos += 5; // Including tailing 0

            if (header != "RREF") return; // Ignore other messages

            while (pos < buffer.Length)
            {
                var id = BitConverter.ToInt32(buffer, pos);
                pos += 4;

                try
                {
                    var value = BitConverter.ToSingle(buffer, pos);
                    pos += 4;
                    if (DataRefs.ContainsKey(id) &&
                        DataRefs[id].Update(value))
                    {
                        OnDataRefReceived?.Invoke(DataRefs[id]);
                    }
                }
                catch (ArgumentException ex)
                {
                }
                catch (Exception ex)
                {
                    var error = ex.Message;
                }
            }
        }

        /// <summary>
        /// Sends a command
        /// </summary>
        /// <param name="command">Command to send</param>
        public void SendCommand(XPlaneCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var dg = new XPDatagram("CMND", command.Command);
            client.Send(dg.Bytes, dg.Bytes.Length);
        }

        /// <summary>
        /// Sends a command continously. Use return parameter to cancel the send cycle
        /// </summary>
        /// <param name="command">Command to send</param>
        /// <returns>Token to cancel the executing</returns>
        public CancellationTokenSource StartCommand(XPlaneCommand command)
        {
            var tokenSource = new CancellationTokenSource();

            Task.Run(() =>
            {
                while (!tokenSource.IsCancellationRequested)
                {
                    SendCommand(command);
                }
            }, tokenSource.Token);

            return tokenSource;
        }

        /// <summary>
        /// Subscribe to a DataRef, notification will be sent every time the value changes
        /// </summary>
        /// <param name="dataref">DataRef to subscribe to</param>
        /// <param name="frequency">Times per seconds X-Plane will be seding this value</param>
        /// <param name="onchange">Callback invoked every time a change in the value is detected</param>
        public void Subscribe(DataRefElement dataref, int frequency = -1, Action<DataRefElement, float> onchange = null)
        {
            if (dataref == null)
                throw new ArgumentNullException(nameof(dataref));

            if (onchange != null)
                dataref.OnValueChange = onchange;

            if (frequency > 0)
                dataref.Frequency = frequency;

            DataRefs.Add(dataref.Id, dataref);
        }

        /// <summary>
        /// Subscribe to a DataRef, notification will be sent every time the value changes
        /// </summary>
        /// <param name="dataref">DataRef to subscribe to</param>
        /// <param name="frequency">Times per seconds X-Plane will be seding this value</param>
        /// <param name="onchange">Callback invoked every time a change in the value is detected</param>
        public void Subscribe(StringDataRefElement dataref, int frequency = -1, Action<StringDataRefElement, string> onchange = null)
        {
            if (dataref == null)
                throw new ArgumentNullException(nameof(dataref));

            dataref.OnValueChange = onchange;

            for (var c = 0; c < dataref.StringLength; c++)
            {
                var arrayElementDataRef = new DataRefElement
                {
                    DataRef = $"{dataref.DataRef}[{c}]",
                    Description = ""
                };

                var currentIndex = c;
                Subscribe(arrayElementDataRef, frequency, (e, floatValue) =>
                {
                    var character = Convert.ToChar(Convert.ToInt32(floatValue));
                    dataref.Update(currentIndex, character);
                });
            }
        }

        private void RequestDataRef(DataRefElement element)
        {
            if (client == null) return;
            var dg = new XPDatagram(413);
            dg.Add("RREF");
            dg.Add(element.Frequency);
            dg.Add(element.Id);
            dg.Add(element.DataRef);
            client.Send(dg.Bytes, dg.Bytes.Length);

            OnLog?.Invoke($"Requested {element.DataRef}@{element.Frequency}Hz with Id:{element.Id}");
        }

        /// <summary>
        /// Informs X-Plane to stop sending this DataRef
        /// </summary>
        /// <param name="dataref">DataRef to unsubscribe from</param>
        public void Unsubscribe(DataRefElement dataref)
        {
            if (!DataRefs.ContainsKey(dataref.Id)) return;
            var dr = DataRefs[dataref.Id];
            var dg = new XPDatagram(413);
            dg.Add("RREF");
            dg.Add(dr.Id);
            dg.Add(0);
            dg.Add(dataref.DataRef);
            client.Send(dg.Bytes, dg.Bytes.Length);
            DataRefs.Remove(dr.Id);

            OnLog?.Invoke($"Unsubscribed from {dataref.DataRef}");
        }

        /// <summary>
        /// Informs X-Plane to change the value of the DataRef
        /// </summary>
        /// <param name="dataref">DataRef that will be changed</param>
        /// <param name="value">New value of the DataRef</param>
        public void SetDataRefValue(DataRefElement dataref, float value)
        {
            if (dataref == null)
                throw new ArgumentNullException(nameof(dataref));

            SetDataRefValue(dataref.DataRef, value);
        }

        /// <summary>
        /// Informs X-Plane to change the value of the DataRef
        /// </summary>
        /// <param name="dataref">DataRef that will be changed</param>
        /// <param name="value">New value of the DataRef</param>
        public void SetDataRefValue(string dataref, float value)
        {
            var dg = new XPDatagram(509);
            dg.Add("DREF");
            dg.Add(value);
            dg.Add(dataref);
            client.Send(dg.Bytes, dg.Bytes.Length);
        }
        /// <summary>
        /// Informs X-Plane to change the value of the DataRef
        /// </summary>
        /// <param name="dataref">DataRef that will be changed</param>
        /// <param name="value">New value of the DataRef</param>
        public void SetDataRefValue(string dataref, string value)
        {
            var dg = new XPDatagram(509);
            dg.Add("DREF");
            dg.Add(value);
            dg.Add(dataref);
            client.Send(dg.Bytes, dg.Bytes.Length);
        }

        /// <summary>
        /// Request X-Plane to close, a notification message will appear
        /// </summary>
        public void QuitXPlane()
        {
            var dg = new XPDatagram("QUIT");
            client.Send(dg.Bytes, dg.Bytes.Length);
        }

        /// <summary>
        /// Inform X-Plane that a system is failed
        /// </summary>
        /// <param name="system">Integer value representing the system to fail</param>
        public void Fail(int system)
        {
            var dg = new XPDatagram("FAIL", system.ToString(EnCulture));
            client.Send(dg.Bytes, dg.Bytes.Length);
        }

        /// <summary>
        /// Inform X-Plane that a system is back to normal functioning
        /// </summary>
        /// <param name="system">Integer value representing the system to recover</param>
        public void Recover(int system)
        {
            var dg = new XPDatagram("RECO", system.ToString(EnCulture));
            client.Send(dg.Bytes, dg.Bytes.Length);
        }

        protected virtual void Dispose(bool a)
        {
            server?.Dispose();
            client?.Dispose();
            ts?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
