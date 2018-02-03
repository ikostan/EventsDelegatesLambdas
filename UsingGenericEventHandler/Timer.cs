using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericEventHandler
{
    class Timer
    {
        public void Subscribe(Clock c)
        {
            //c.timeChanged += new EventHandler<TimeArgs>(ShowTime); //Full reference version
            //c.timeChanged += ShowTime; //Short reference version

            //Anonimus function
            c.timeChanged += delegate (object src, TimeArgs args)
            {
                Console.WriteLine($"{args.Hours} : {args.Minutes} : {args.Seconds}");
            };
        }

        public void ShowTime(object src, TimeArgs args)
        {
            Console.WriteLine($"{args.Hours} : {args.Minutes} : {args.Seconds}");
        }

        //End of class
    }
}
