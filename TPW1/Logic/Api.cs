namespace Logic
{
    public abstract class LogicApi
    {
        internal abstract List<Ball> Balls { get; }
        public abstract void CreateBalls(int number);
        public abstract int GetNumberOfBalls();
        public abstract float GetX(int number);
        public abstract float GetY(int number);
        public abstract event EventHandler LogicApiEvent;
        public static LogicApi Instance()
        {
            return new Logic();
        }
        private class Logic : LogicApi
        {
            internal override List<Ball> Balls { get; }
            public Logic()
            {
                Balls = new List<Ball>();
            }
            public override event EventHandler LogicApiEvent;

            public override void CreateBalls(int number)
            {
                Random rnd = new Random();
                for (int i = 0; i < number; i++)
                {
                    Ball ball = new Ball(rnd.Next(50, 350), rnd.Next(50, 350));
                    Balls.Add(ball);
                    ball.PositionChanged += Ball_PositionChanged;
                }
            }
            public override int GetNumberOfBalls()
            {
                return Balls.Count;
            }
            public override float GetX(int number)
            {
                return Balls[number].X;
            }
            public override float GetY(int number)
            {
                return Balls[number].Y;
            }
            private void Ball_PositionChanged(object sender, EventArgs e)
            {
                Ball ball = sender as Ball;
                if (ball != null)
                {
                    updatePosition(ball);
                    LogicApiEvent?.Invoke(ball, EventArgs.Empty);
                }
            }

            private void updatePosition(Ball ball)
            {
                if (ball.X < 0)
                {
                    ball.X = 0;
                    ball.HorizontalSpeed = ball.generateRandomSpeed();
                }
                if (ball.Y < 0)
                {
                    ball.Y = 0;
                    ball.VerticalSpeed = ball.generateRandomSpeed();
                }

                if (ball.X + Ball.Radius > 400)
                {
                    ball.X = 400 - Ball.Radius;
                    ball.HorizontalSpeed = ball.generateRandomSpeed();
                }
                if (ball.Y + Ball.Radius > 400)
                {
                    ball.Y = 400 - Ball.Radius;
                    ball.VerticalSpeed = ball.generateRandomSpeed();
                }
            }
        }
    }
}
