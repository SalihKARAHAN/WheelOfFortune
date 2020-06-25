using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace FortuneWheel
{
    public class WheelFactory
    {
        private const float LIMIT_PERCENTAGE = 100f;
        private Queue<IPrize> _segments;
        private float _totalPercentage;
        private float _currentAngle;

        public WheelFactory Initialize()
        {
            this._segments = new Queue<IPrize>();
            return this;
        }

        public WheelFactory DefineSegment(IPrize percentageable)
        {
            float percentage = percentageable.ChancePercentage;
            this.CheckRemainPercentage(percentage);
            this._segments.Enqueue(percentageable);
            this._totalPercentage += percentage;
            return this;
        }

        public WheelPlatform<TPrizeType> CreateWheel<TPrizeType>()
            where TPrizeType : IPrize
        {
            this.CheckWheelDefinitions();
            Wheel wheel = new Wheel(this._segments.Count);
            int segmentCount = this._segments.Count;
            while (segmentCount != 0)
            {
                IPrize percentageable = this._segments.Dequeue();
                float angle = this.CalculateAngleByPercentage(percentageable.ChancePercentage);
                float endAngle = this._currentAngle + angle - Wheel.SENSITIVITY;
                Segment segment = new Segment(this._currentAngle, endAngle, percentageable);
                this._currentAngle = this._currentAngle + angle;
                wheel.AddSegment(segment);
                segmentCount = this._segments.Count;
            }

            this.ResetDefinitions();
            WheelPlatform<TPrizeType> wheelPlatform = new WheelPlatform<TPrizeType>(wheel);
            return wheelPlatform;
        }

        private void CheckRemainPercentage(float percentage)
        {
            float remain = this.CalculateRemainPercentage();
            if (percentage > remain)
            {
                throw new RemainedPercentageNotEnoughException();
            }
        }

        private float CalculateRemainPercentage()
        {
            float ramainPercentage = WheelFactory.LIMIT_PERCENTAGE - this._totalPercentage;
            return ramainPercentage;

        }

        private float CalculateAngleByPercentage(float percentage)
        {
            float angle = percentage * Wheel.ONE_ANGLE_PERCENTAGE;
            return angle;
        }

        private void CheckWheelDefinitions()
        {
            if (this._totalPercentage != WheelFactory.LIMIT_PERCENTAGE)
            {
                throw new NotCompletedWheelException();
            }
        }
        private void ResetDefinitions()
        {
            this._currentAngle = 0;
            this._totalPercentage = 0;
            this._segments = null;
        }

    }
}
