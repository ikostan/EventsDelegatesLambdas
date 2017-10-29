using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace CustomDelegate
{
    class ProcessData
    {
        public void ProcessDelegate(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine($"Result: {result}");
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
        }

        public void ProcessFunc(int x, int y, Func <int, int, double> func)
        {
            var result = func(x, y);
            Console.WriteLine($"Result: {result}");
        }
    }
}
