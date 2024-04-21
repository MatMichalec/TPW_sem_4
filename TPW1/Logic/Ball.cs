namespace Logic
{
    internal class Ball
    {
        private float x;
        private float y;

        internal float X
        {
            get { return x; }
            set
            {
                x = value;
                OnPositionChanged();
            }
        }
        internal float Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPositionChanged();
            }
        }

        internal event EventHandler PositionChanged;

        internal void OnPositionChanged()
        {
            PositionChanged?.Invoke(this, EventArgs.Empty);
        }

        internal float HorizontalSpeed { private get; set; }
        internal float VerticalSpeed { private get; set; }
        internal const int Radius = 60;

        private Random rnd;
        private int Speed = 20;

        private static System.Timers.Timer aTimer;

        internal Ball(float x, float y)
        {
            X = x;
            Y = y;
            rnd = new Random();
            HorizontalSpeed = generateRandomSpeed();
            VerticalSpeed = generateRandomSpeed();

            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000 / 30;
            aTimer.Elapsed += OnUpdate;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnUpdate(Object source, System.Timers.ElapsedEventArgs e)
        {
            X +=  HorizontalSpeed;
            Y +=  VerticalSpeed;
        }

        internal float generateRandomSpeed()
        {
            float speed;
            do
            {
                speed = rnd.NextSingle() * Speed - Speed / 2;
            }
            while (speed == 0);
            return speed * 2;
        }
    }
}