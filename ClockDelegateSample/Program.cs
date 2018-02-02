using System;

namespace ClockDelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Clock Delegate Sample:\n");
            Clock clock = new Clock();
            Timer timer = new Timer();
            clock.Subscribe(timer);
            timer.StartClock();
        }
    }
}
