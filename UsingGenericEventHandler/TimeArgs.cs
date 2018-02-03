using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericEventHandler
{
    class TimeArgs : EventArgs
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public void SetArgs(DateTime time)
        {
            Hours = time.Hour;
            Minutes = time.Minute;
            Seconds = time.Second;
        }

        public bool CompareTime(DateTime time)
        {
            if (Hours == time.Hour && 
                Minutes == time.Minute && 
                Seconds == time.Second)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //End of Class
    }
}
