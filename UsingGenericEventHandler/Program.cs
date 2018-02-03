using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Timer timer = new Timer();
            timer.Subscribe(clock);
            clock.StartClock();
        }

        //End of Class
    }
}
