using System;
using System.ComponentModel;
using System.Timers;

namespace DigitalClock
{
    class TimeModel : INotifyPropertyChanged
    {
        private const int min = 60000;
        private const int interval = 1000;
        private Timer timer;

        public TimeModel()
        {
            timer = new Timer(interval);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Time = DateTime.Now.ToShortTimeString();
            if (timer.Interval == min)
                return;
            timer.Interval = min - DateTime.Now.Second * interval;
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
