using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegate
{
    public class Program
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);

        static void Main(string[] args)
        {
            WorkPerformedHandler del = new WorkPerformedHandler(WorkPerformed);
            WorkPerformedHandler workHandler = new WorkPerformedHandler(WorkPerformed);
            WorkPerformedHandler performanceHandler = new WorkPerformedHandler(DoSomeWork);

            //workHandler(8, WorkType.GenerateReports);
            //performanceHandler(16, WorkType.Negotiation);

            //DoSomething(performanceHandler);

            del += workHandler + performanceHandler;
            del(12, WorkType.GoToMeetings);

            Console.ReadKey();
        }

        public static void DoSomething(WorkPerformedHandler del)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");
            del(34, WorkType.Golf);
        }

        public static void DoSomeWork(int hours, WorkType workType)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");
            Console.WriteLine($"Arguments: {hours}, {workType}");
        }

        public static void WorkPerformed(int hours, WorkType workType)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");
            Console.WriteLine($"Arguments: {hours}, {workType}");
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports,
        Negotiation
    }

}
