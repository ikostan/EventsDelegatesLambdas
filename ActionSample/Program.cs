using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionSample
{
    class Program
    {
        static Action<int, int> sum = (x, y) => Console.WriteLine(x + y);
        static Action<int, int> mul = (x, y) => Console.WriteLine(x * y);
        static Action<int, int> div = (x, y) => Console.WriteLine(x / y);
        static Action<int, int> sub = (x, y) => Console.WriteLine(x - y);

        static void Main(string[] args)
        {
            int x = 6, y = 3;

            DoAction(x, y, sum);
            DoAction(x, y, sub);
            DoAction(x, y, mul);
            DoAction(x, y, div);

            Console.ReadLine();
        }

        private static void DoAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
        }

        //End of Class
    }
}
