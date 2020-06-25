using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FortuneWheel
{
    public class WheelPlatform<TPrizeType>
        where TPrizeType: IPrize
    {
        private readonly Wheel _wheel;
        public WheelPlatform(Wheel wheel)
        {
            this._wheel = wheel;
        }

        public void SpinWheel()
        {
            this._wheel.Spin();
        }

        public TPrizeType GetPrize()
        {
            Segment segment = this._wheel.GetSegment();
            TPrizeType prize = (TPrizeType)segment.Prize;
            return prize;
        }
    }
}
