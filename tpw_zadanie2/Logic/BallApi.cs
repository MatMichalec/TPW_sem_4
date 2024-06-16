﻿using Data;
using System.Numerics;
using System.Diagnostics;
using System.Collections.Generic;

namespace Logic
{
    public abstract class DataApi
    {
        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract void CreateBalls(int number);
        public abstract int GetNumberOfBalls();
        public abstract double GetX(int number);
        public abstract double GetY(int number);
        public abstract IBall GetBall(int number);
        public abstract event EventHandler BallEvent;


        public static DataApi Instance()
        {
            return new Data();
        }

        private class Data : DataApi
        {
            private Logger _logger;
            private List<IBall> Balls { get; }
            public override int Width { get; }
            public override int Height { get; }
            public override event EventHandler BallEvent;

            public Data()
            {
                Balls = new List<IBall>();
                Width = 380;
                Height = 380;
                _logger = new Logger(Balls); // Pass the balls list to the logger
            }
            public override void CreateBalls(int number)
            {
                Random rnd = new Random();
                int a = Balls.Count;
                for (int i = 0; i < number; i++)
                {
                    Ball ball = new Ball(rnd.Next(100, 300), rnd.Next(100, 300), 10, i + a);
                    Balls.Add(ball);
                    ball.PositionChanged += Ball_PositionChanged;
                }
            }
            public override int GetNumberOfBalls()
            {
                return Balls.Count;
            }

            private void Ball_PositionChanged(object sender, EventArgs e)
            {
                if (sender != null)
                {
                    BallEvent?.Invoke(sender, EventArgs.Empty);
                }
            }
            public override double GetX(int number)
            {
                return Balls[number].Position.X;
            }
            public override double GetY(int number)
            {
                return Balls[number].Position.Y;
            }
            public override IBall GetBall(int number)
            {
                return Balls[number];
            }
        }
    }
}