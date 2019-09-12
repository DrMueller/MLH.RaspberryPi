namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    public class PythonArgument
    {
        public bool Escape { get; }
        public string Value { get; }

        public PythonArgument(string value, bool escape)
        {
            Value = value;
            Escape = escape;
        }
    }
}