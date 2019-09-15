namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Joysticks
{
    public class JoystickEvent
    {
        public JoystickAction Action { get; }
        public JoystickDirection Direction { get; }

        public JoystickEvent(JoystickAction action, JoystickDirection direction)
        {
            Action = action;
            Direction = direction;
        }
    }
}