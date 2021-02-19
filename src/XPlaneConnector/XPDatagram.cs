using System;
using System.Collections.Generic;
using System.Linq;

namespace XPlaneConnector
{
    public class XPDatagram
    {
        public byte[] Bytes { get; set; }
        protected int Index { get; set; }

        public XPDatagram(params string[] data)
        {
            var len = data.Sum(s => s.Length + 1);
            Bytes = new byte[len];
            foreach (var s in data) Add(s);
        }
        public XPDatagram(int size)
        {
            Bytes = new byte[size];
        }

        public void Add(byte value)
        {
            Bytes[Index++] = value;
        }

        public void Add(IEnumerable<byte> valueArray)
        {
            foreach (var value in valueArray) Bytes[Index++] = value;
        }

        public void Add(int value)
        {
            var bElement = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Add(bElement);
            }
            else
            {
                Add(bElement.Reverse());
            }
        }
        public void Add(float value)
        {
            var bElement = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Add(bElement);
            }
            else
            {
                Add(bElement.Reverse());
            }
        }
        public void Add(string value)
        {
            foreach (var character in value) Add((byte)character);
            Add((byte)0);
        }
    }
}


