using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneWheel
{
    public class Point : IPrize
    {
        public short Value { get; set; }
        public float ChancePercentage { get; set; }
    }
}
