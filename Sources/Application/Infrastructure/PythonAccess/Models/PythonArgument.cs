namespace Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models
{
    // All CLI Arguments are parsed via Strings anyway, so we have to overwrite some stuff
    internal class PythonArgument
    {
        private readonly bool _doEscape;
        private readonly string _value;

        public PythonArgument(object value, bool doEscape = false)
        {
            _value = value.ToString();
            _doEscape = doEscape;
        }

        internal string AsString()
        {
            var val = _value.ToString();
            if (_doEscape)
            {
                val = string.Format("\"{0}\"", val);
            }

            return val;
        }
    }
}