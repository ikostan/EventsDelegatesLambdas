using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClockDelegateSample
{
    class Timer
    {
        public delegate void TimerTimeChanged(object sender, EventArgs tArgs);
        public event TimerTimeChanged TimeChanged;
        public TimeArgs tArgs;

        public Timer() {

            DateTime t = DateTime.Now;
            tArgs = new TimeArgs(t.Hour, t.Minute, t.Second);
        }

        public void StartClock() {

            while (true) {
                Thread.Sleep(1000);
                DateTime dt = DateTime.Now;

                if (tArgs.Second != dt.Second) {

                    tArgs.Hour = dt.Hour;
                    tArgs.Minute = dt.Minute;
                    tArgs.Second = dt.Second;

                    if (TimeChanged != null)
                    {
                        TimeChanged(this, tArgs);
                    }
                }
            }
        }

        //End of class
    }
}
