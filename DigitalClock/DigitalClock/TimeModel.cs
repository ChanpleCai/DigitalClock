using System;
using System.ComponentModel;
using System.Timers;

namespace DigitalClock
{
    class TimeModel : INotifyPropertyChanged
    {
        private Timer timer;

        public TimeModel()
        {
            timer = new Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            Time = DateTime.Now.ToShortTimeString();
        }

        private string _time;

        public string Time
        {
            get => _time; set
            {
                if (_time != value)
                {
                    _time = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Time"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
