using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        public String Color { get; set; }
        private float x;
        public float X
        {
            get { return x; }
            set
            {
                x = value;
                RaisePropertyChanged();
            }
        }
        private float y;
        public float Y
        {
            get { return y; }
            set
            {
                y = value;
                RaisePropertyChanged();
            }
        }
        public float Radious
        {
            get { return 60; }
        }


        public BallModel(float x, float y, string color = "Red")
        {
            Color = color;
            X = x;
            Y = y;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}