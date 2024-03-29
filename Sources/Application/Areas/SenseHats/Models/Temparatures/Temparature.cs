﻿using System;

namespace Mmu.Mlh.RaspberryPi.Areas.SenseHats.Models.Temparatures
{
    public class Temparature
    {
        public float Value { get; }

        internal Temparature(float value)
        {
            Value = value;
        }

        public string AsDescription()
        {
            var roundedValue = Math.Round(Value, 1);
            return $"{roundedValue} C";
        }

        internal static Temparature Parse(string str)
        {
            var val = float.Parse(str);
            return new Temparature(val);
        }
    }
}