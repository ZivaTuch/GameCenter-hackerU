using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace gameCenter
{
    public  class Timer
    {
        private static DispatcherTimer timer;
        private TimeSpan _timePlayed;
   
        public static event EventHandler<DateTime> TimeChanged;

        static Timer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // קביעת תדירות הטיימר לשנייה אחת
            timer.Tick += Clock;
            timer.Start();
        }

           public TimeSpan Time
        {
            get
            {
                return _timePlayed;
            }
            set
            {
                _timePlayed = value;
                OnTimeChanged(Time);
            }
        }
        private static void Clock(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            OnTimeChanged(currentTime);

        }

        private void OnTimeChanged(TimeSpan time)
        {
            throw new NotImplementedException();
        }

        private static void OnTimeChanged(DateTime time)
        {
            TimeChanged?.Invoke(null, time);
        }

       public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
           timer.Stop();
        }

        private void PlayedTimer_Tick(object sender, EventArgs e)
        {
            Time = _timePlayed.Add(new TimeSpan(0, 0, 1));
        }
    }
}
