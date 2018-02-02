using System;
using System.Collections.Generic;
using System.Text;

namespace ClockDelegateSample
{
    class Clock
    {
        public void Subscribe(Timer t) {
            t.TimeChanged += TickTack;
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="t"></param>
        /// <param name="tArgs"></param>
        public void TickTack(object sender, EventArgs tArgs)
        {
            Console.Clear();
            Console.WriteLine($"{((TimeArgs)tArgs).Hour:D2}:{((TimeArgs)tArgs).Minute:D2}:{((TimeArgs)tArgs).Second:D2}");
        }
    }
}
