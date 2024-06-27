namespace powerraker
{

    public class RakerConnection
    {
        public string Printer { get; internal set; }

        public RakerConnection(string printer)
        {
            this.Printer = printer;
            Current = this;
        }
        public static RakerConnection? Current
        {
            get; internal set;
        }
    }
}