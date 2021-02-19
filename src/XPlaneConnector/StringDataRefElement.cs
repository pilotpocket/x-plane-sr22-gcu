using System;

namespace XPlaneConnector
{
    public class StringDataRefElement
    {
        private static readonly object lockElement = new object();
        public string DataRef { get; set; }
        public int Frequency { get; set; }
        public int StringLength { get; set; }
        public string Value { get; set; } = "";

        private int CharactersInitialized;

        public bool IsCompletelyInitialized => CharactersInitialized >= StringLength;

        public Action<StringDataRefElement, string> OnValueChange;

        public void Update(int index, char character)
        {
            lock (lockElement)
            {
                var fireEvent = !IsCompletelyInitialized;

                if (!IsCompletelyInitialized)
                    CharactersInitialized++;

                if (character > 0)
                {
                    if (Value.Length <= index)
                        Value = Value.PadRight(index + 1, ' ');

                    var current = Value[index];
                    if (current != character)
                    {
                        Value = Value.Remove(index, 1).Insert(index, character.ToString());
                        fireEvent = true;
                    }
                }

                if (IsCompletelyInitialized && fireEvent)
                {
                    if (OnValueChange != null) OnValueChange(this, Value);
                    CharactersInitialized = 0;
                }
            }
        }
    }
}
