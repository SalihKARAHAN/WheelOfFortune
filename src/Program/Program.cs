using FortuneWheel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            WheelFactory wheelFactory = new WheelFactory();
            WheelPlatform<Prize> prizeWheelPlatform = program.CreatePrizeWheelPlatform(wheelFactory);
            WheelPlatform<Point> pointWheelPlatform = program.CreatePointWheelPlatform(wheelFactory);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            prizeWheelPlatform.SpinWheel();
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds + " Milisaniye Çalıştı!");
            Prize prize = prizeWheelPlatform.GetPrize();
            Console.WriteLine(prize.Name);
            if (prize.PointEarnable)
            {
                stopwatch.Reset();
                stopwatch.Start();
                pointWheelPlatform.SpinWheel();
                Point point = pointWheelPlatform.GetPrize();
                Console.WriteLine(point.Value + " Puan kazanıldı");
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds + " Milisaniye Çalıştı!");
            }

        }

        private WheelPlatform<Prize> CreatePrizeWheelPlatform(WheelFactory wheelFactory)
        {
            List<Prize> prizes = new List<Prize>
            {
                new Prize{Name="250 MB Internet Paketi", ChancePercentage=20, PointEarnable=true}
                , new Prize{Name="1 GB Internet Paketi", ChancePercentage=5}
                , new Prize{Name="Boyner 25 TL Hediye Çeki", ChancePercentage=5}
                , new Prize{Name="Koton 10 TL Hediye Çeki", ChancePercentage=10, PointEarnable=true}
                , new Prize{Name="Blu TV 1 Aylık Abonelik", ChancePercentage=5}
                , new Prize{Name="10 TL Steam Cüzdan Kodu", ChancePercentage=10, PointEarnable=true}
                , new Prize{Name="Karavana 😁", ChancePercentage=45, PointEarnable=true}
            };

            wheelFactory.Initialize();
            int prizesCount = prizes.Count;
            for (int i = 0; i < prizesCount; i++)
            {
                Prize currentPrize = prizes[i];
                wheelFactory.DefineSegment(currentPrize);
            }

            WheelPlatform<Prize> prizeWheelPlatform = wheelFactory.CreateWheel<Prize>();
            return prizeWheelPlatform;

        }

        private WheelPlatform<Point> CreatePointWheelPlatform(WheelFactory wheelFactory)
        {
            List<Point> points = new List<Point>
            {
                new Point{Value=75, ChancePercentage=5}
                , new Point{Value=150, ChancePercentage=4}
                , new Point{Value=500, ChancePercentage=1}
                , new Point{Value=5, ChancePercentage=50}
                , new Point{Value=0, ChancePercentage=40}
            };

            wheelFactory.Initialize();
            int prizeCount = points.Count;
            for (int i = 0; i < prizeCount; i++)
            {
                Point currentPrize = points[i];
                wheelFactory.DefineSegment(currentPrize);
            }

            WheelPlatform<Point> prizeWheelPlatform = wheelFactory.CreateWheel<Point>();
            return prizeWheelPlatform;
        }
    }
}
