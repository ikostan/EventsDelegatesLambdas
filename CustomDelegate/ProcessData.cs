using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace CustomDelegate
{
    class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine($"Result: {result}");
        }
    }
}
