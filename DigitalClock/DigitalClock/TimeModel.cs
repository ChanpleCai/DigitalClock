using System;
using System.ComponentModel;
using System.Timers;

namespace DigitalClock
{
    class TimeModel : INotifyPropertyChanged
    {
        private const int V = 60000;
        private Timer timer;

        public TimeModel()
        {
            timer = new Timer(125);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Time = DateTime.Now.ToShortTimeString();
            if (timer.Interval == V)
                return;
            timer.Interval = V - DateTime.Now.Second * 1000;
        }

        private string _time;

        public string Time
        {
            get => _time; set
            {
                _time = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Time"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
