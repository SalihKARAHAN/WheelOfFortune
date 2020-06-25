using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace FortuneWheel
{
    public class Wheel
    {
        internal const float ONE_ANGLE_PERCENTAGE = 3.6f;
        internal const float TOTAL_WHEEL_ANGLE = 360f;
        internal const float SENSITIVITY = .01f;
        internal const int MIN_SPIN_RATE_VALUE = 0;
        internal const int MAX_SPIN_RATE_VALUE = 500;

        private readonly List<Segment> _segments;
        private float _currentAngle;

        public Wheel(int segmentCount)
        {
            this._segments = new List<Segment>(segmentCount);
        }

        internal void Spin()
        {
            int spinRate = new Random().Next(Wheel.MIN_SPIN_RATE_VALUE, Wheel.MAX_SPIN_RATE_VALUE);
            float spinAngle = 1.0f;
            while (Math.Round(spinAngle,1) > 0)
            {
                float r1 = (spinAngle / spinRate);
                float r2 = spinAngle * r1;
                spinAngle = spinAngle - r2;
                this._currentAngle += spinAngle;
                if(this._currentAngle > Wheel.TOTAL_WHEEL_ANGLE)
                {
                    this._currentAngle = this._currentAngle - Wheel.TOTAL_WHEEL_ANGLE;
                }

                System.Threading.Thread.Sleep(1);
            }
        }

        internal void AddSegment(Segment segment)
        {
            this._segments.Add(segment);
        }

        internal Segment GetSegment()
        {
            Segment segment = this._segments.First(s => s.CheckAngle(this._currentAngle));
            return segment;
        }
    }
}
