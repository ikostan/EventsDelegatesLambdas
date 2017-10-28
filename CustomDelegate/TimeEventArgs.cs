using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegate
{
    public class TimeEventArgs : EventArgs
    {
        public int Second { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
    }
}
