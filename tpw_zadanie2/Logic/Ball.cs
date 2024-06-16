﻿using System;
using System.Diagnostics;
using System.Numerics;
using Data;

namespace Logic
{
 

    internal class Ball : IBall
    {
        private int _moveTime;
        private Vector2 _speed;
        private Vector2 _position;
        private Stopwatch _stopwatch;
        public int ID { get; }

        public Ball(int x, int y, float weight, int id)
        {
            _stopwatch = new Stopwatch();
            ID = id;
            Random rnd = new Random();
            Speed = new Vector2(x, y)
            {
                X = (float)(rnd.NextDouble() * (0.75 - (-0.75)) + (-0.75)),
                Y = (float)(rnd.NextDouble() * (0.75 - (-0.75)) + (-0.75))
            };
            Position = new Vector2(x, y)
            {
                X = x,
                Y = y
            };
            MoveTime = 1000 / 60;
            RunTask();
        }

        internal event EventHandler PositionChanged;

        internal void OnPositionChanged()
        {
            PositionChanged?.Invoke(this, EventArgs.Empty);
        }

        public int MoveTime
        {
            get => _moveTime;
            private set
            {
                _moveTime = value;
            }
        }
        public Vector2 Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
            }
        }
        public Vector2 Position
        {
            get => _position;
            private set { _position = value; }
        }

        public void Move()
        {
            Position += Speed * MoveTime;
            OnPositionChanged();
        }
        private void RunTask()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Move();
                    await Task.Delay(MoveTime);
                }
            });
        }
    }
}