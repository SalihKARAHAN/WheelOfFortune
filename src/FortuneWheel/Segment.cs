using System;
using System.Collections.Generic;
using System.Text;

namespace FortuneWheel
{
#if DEBUG
    [System.Diagnostics.DebuggerDisplay("Start: {_startAngle} End: {this._endAngle} Angle: {this._angle}")]
#endif
    class Segment
    {
        private readonly float _startAngle;
        private readonly float _endAngle;
        private readonly float _angle;
        private readonly IPrize _prize;

        internal float Angel
        {
            get { return this._angle; }
        }

        internal IPrize Prize { get { return this._prize; } }

        internal Segment(float startAngle, float endAngle, IPrize prize)
        {
            this._startAngle = startAngle;
            this._endAngle = endAngle;
            this._prize = prize;
            this._angle = this._endAngle - this._startAngle;
        }

        internal bool CheckAngle(float angle)
        {
            bool inThisSegment = this._startAngle <= angle && this._endAngle >= angle;
            return inThisSegment;
        }

    }
}
