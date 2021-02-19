namespace XPlaneConnector
{
    public sealed class XPlaneCommand
    {
        public string Command { get; }
        public string Description { get; }

        public XPlaneCommand(string command, string description)
        {
            this.Command = command;
            this.Description = description;
        }
    }
}

