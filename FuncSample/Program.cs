using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncSample
{
    class Program
    {
        static Func<string, bool> IsStringEmpty = (s) => (s.Trim() == "" || s == null) ? true : false;

        static void Main(string[] args)
        {
            string s = "";
            Console.WriteLine(TestString(s, IsStringEmpty));

            string s1 = " ";
            Console.WriteLine(TestString(s1, IsStringEmpty));

            string s2 = "s";
            Console.WriteLine(TestString(s2, IsStringEmpty));

            Console.ReadLine();
        }

        public static bool TestString(string s, Func<string, bool> func)
        {
            return func(s);
        }

        //End of Class
    }
}
