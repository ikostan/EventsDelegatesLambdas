using System;
using System.Collections.Generic;
using System.Text;

namespace ClockDelegateSample
{
    class TimeArgs : EventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public TimeArgs(int h, int m, int s){

                Hour = h;
                Minute = m;
                Second = s;
        }
    }
}
