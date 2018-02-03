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
            //Full reference version
            //c.timeChanged += new EventHandler<TimeArgs>(ShowTime); 

            //Short reference version
            //c.timeChanged += ShowTime; 

            //Anonimus function/method
            /*
            c.timeChanged += delegate(object src, TimeArgs args)
            {
                Console.Clear();
                if (args.Seconds % 2 == 0)
                {
                    Console.WriteLine(
                        $"{args.Hours,2:00}:{args.Minutes,2:00}:{args.Seconds,2:00}");
                }
                else
                {
                    Console.WriteLine(
                        $"{args.Hours,2:00} {args.Minutes,2:00} {args.Seconds,2:00}");
                }
            };
            */

            //Lambda Example
            c.timeChanged += (src, args) =>
            {
                Console.Clear();
                if (args.Seconds % 2 == 0)
                {
                    Console.WriteLine(
                        $"{args.Hours,2:00}:" +
                        $"{args.Minutes,2:00}:" +
                        $"{args.Seconds,2:00}");
                }
                else
                {
                    Console.WriteLine(
                        $"{args.Hours,2:00} " +
                        $"{args.Minutes,2:00} " +
                        $"{args.Seconds,2:00}");
                }
            };
        }

        public void ShowTime(object src, TimeArgs args)
        {
            Console.WriteLine($"{args.Hours} : {args.Minutes} : {args.Seconds}");
        }

        //End of class
    }
}
