using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneWheel
{
    public class Prize : IPrize
    {
        public string Name { get; set; }
        public float ChancePercentage { get; set; }
        public bool PointEarnable { get; set; }
    }
}
