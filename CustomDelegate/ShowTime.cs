using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegate
{
    public class ShowTime
    {
        public void RegisterEvent(Clock clock)
        {
            clock.timeChanged += new Clock.TimeChanged(ShowTimeNow);
        }

        public void ShowTimeNow(object obj, TimeEventArgs args)
        {
            Console.Clear();
            Console.WriteLine($"{args.Hour,2:D2} : {args.Minute,2:D2} : {args.Second,2:D2}");
        }
    }
}
