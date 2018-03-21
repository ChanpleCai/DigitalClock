using System;
using System.ComponentModel;
using System.Timers;

namespace DigitalClock
{
    class TimeModel : INotifyPropertyChanged
    {
        private const string Format = "d2";
        private Timer timer;
        private DateTime now;

        public TimeModel()
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            now = DateTime.Now;
            Hour = now.Hour.ToString(Format);
            Minute = now.Minute.ToString(Format);
            Second = now.Second.ToString(Format);
        }

        private string _hour;
        private string _minute;
        private string _second;

        public string Hour
        {
            get => _hour; set
            {
                if (_hour != value)
                {
                    _hour = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Hour"));
                }
            }
        }

        public string Minute
        {
            get => _minute; set
            {
                if (_minute != value)
                {
                    _minute = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Minute"));
                }
            }
        }

        public string Second
        {
            get => _second; set
            {
                _second = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Second"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
