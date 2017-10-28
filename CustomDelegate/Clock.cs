using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomDelegate
{
    public class Clock
    {
        int hour, minute, second;

        public delegate void TimeChanged(object obj, TimeEventArgs args);
        public event TimeChanged timeChanged;

        //public event EventHandler<TimeEventArgs> timeChanged;

        public void StartTimer() {

            while (true)
            {
                DateTime time = DateTime.Now;
                Thread.Sleep(1000);

                if (second != time.Second)
                {
                    second = time.Second;
                    minute = time.Minute;
                    hour = time.Hour;
                }

                if (timeChanged != null)
                {
                    timeChanged(
                        this, 
                        new TimeEventArgs() {
                            Second = this.second,
                            Minute = this.minute,
                            Hour = this.hour }
                        );
                }
            }
        }

    }
}
