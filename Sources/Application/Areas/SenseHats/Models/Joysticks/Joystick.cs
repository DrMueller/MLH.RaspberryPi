﻿using System;
using Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Joysticks
{
    public class Joystick : Device
    {
        internal Joystick(IPythonExecutor executor, string scriptFilePath) : base(executor, scriptFilePath)
        {
        }

        public void Listen(Action<JoystickEvent> eventReceived)
        {
            Listen("listen", str => JoystickInputReceived(str, eventReceived));
        }

        private static void JoystickInputReceived(string str, Action<JoystickEvent> callback)
        {
            var splitted = str.Split(':');
            var act = splitted[0];
            var dir = splitted[1];

            var action = ParseAction(act);
            var direction = ParseDirection(dir);

            var joystickEvent = new JoystickEvent(action, direction);
            callback(joystickEvent);
        }

        private static JoystickAction ParseAction(string str)
        {
            switch (str.ToUpperInvariant())
            {
                case "PRESSED":
                    return JoystickAction.Pressed;

                case "RELEASED":
                    return JoystickAction.Released;

                case "HELD":
                    return JoystickAction.Held;

                default:
                    throw new ArgumentException($"Joystick Action {str} not found.");
            }
        }

        private static JoystickDirection ParseDirection(string str)
        {
            switch (str.ToUpperInvariant())
            {
                case "UP":
                    return JoystickDirection.Up;

                case "DOWN":
                    return JoystickDirection.Down;

                case "LEFT":
                    return JoystickDirection.Left;

                case "RIGHT":
                    return JoystickDirection.Right;

                case "MIDDLE":
                    return JoystickDirection.Middle;

                default:
                    throw new ArgumentException($"Joystick Direction {str} not found.");
            }
        }
    }
}