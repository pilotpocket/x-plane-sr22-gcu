using System;
using System.Threading;

namespace XPlaneConnector
{
    public class DataRefElement
    {
        private static int NextId;

        public int Id { get; set; }
        public string DataRef { get; set; }
        public int Frequency { get; set; }
        public bool IsInitialized { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.MinValue;
        public string Units { get; set; }
        public string Description { get; set; }
        public float Value { get; set; } = float.MinValue;

        public Action<DataRefElement, float> OnValueChange;

        public DataRefElement()
        {
            Id = Interlocked.Increment(ref NextId);
        }

        public TimeSpan Age => DateTime.Now - LastUpdate;

        public bool Update(float value)
        {
            LastUpdate = DateTime.Now;
            if (value == Value) return false;

            Value = value;
            IsInitialized = true;
            if (OnValueChange != null) OnValueChange(this, Value);
            return true;
        }
    }
}
