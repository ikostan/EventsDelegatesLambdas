using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncSample
{
    class Program
    {
        static Func<string, bool> testStr = (s) => (s == "" || s == null) ? false : true;

        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine(TestString(s, testStr));

            string s2 = "s";
            Console.WriteLine(TestString(s2, testStr));

            Console.ReadLine();
        }

        public static bool TestString(string s, Func<string, bool> func)
        {
            return func(s);
        }

    }
}
