using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UsingGenericEventHandler
{
    class Clock
    {
        public event EventHandler<TimeArgs> timeChanged;
        private TimeArgs tArgs;

        public Clock()
        {
            var cTime = DateTime.Now;

            tArgs = new TimeArgs()
            {
                Hours = cTime.Hour,
                Minutes = cTime.Minute,
                Seconds = cTime.Second
            };
        }

        public void StartClock()
        {
            while (true)
            {
                var time = DateTime.Now;
                Thread.Sleep(1000);

                if (!tArgs.CompareTime(time))
                {
                    tArgs.SetArgs(time);

                    if (timeChanged != null)
                    {
                        timeChanged(this, tArgs);
                    }
                } 
            }
        }

        //End of Class
    }
}
