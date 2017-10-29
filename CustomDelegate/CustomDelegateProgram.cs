using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace CustomDelegate
{
    public class CustomDelegateProgram
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);
        public delegate int ReturnWorkPerformedHandler(int hours, WorkType workType);

        static void Main(string[] args)
        {
            WorkPerformedHandler del = new WorkPerformedHandler(WorkPerformed);
            WorkPerformedHandler workHandler = new WorkPerformedHandler(WorkPerformed);
            WorkPerformedHandler performanceHandler = new WorkPerformedHandler(DoSomeWork);
            ReturnWorkPerformedHandler returnWorkPerformedHandler = new ReturnWorkPerformedHandler(AmountWorkPerformed);

            //workHandler(8, WorkType.GenerateReports);
            //performanceHandler(16, WorkType.Negotiation);

            //DoSomething(performanceHandler);

            //del += workHandler + performanceHandler;
            //del(12, WorkType.GoToMeetings);

            //Console.WriteLine($"Work Performed: {returnWorkPerformedHandler(45, WorkType.Negotiation):N2}$");

            //Worker worker = new Worker();

            //worker.DoWork(8, WorkType.GoToMeetings);

            //Clock clock = new Clock();
            //ShowTime display = new ShowTime();
            //display.RegisterEvent(clock);
            //clock.StartTimer();

            Worker worker = new Worker();
            worker.Name = "John Doe";

            //Regular approach:
            //worker.ReturnWorkPerformed += new EventHandler<WorkPerformedArgs>(Worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);

            //Anonymous methods:
            worker.ReturnWorkPerformed += delegate (object sender, WorkPerformedArgs arguments)
            {
                string hrs = (arguments.Hours > 1) ? "hours" : "hour";
                Console.WriteLine($"Working {arguments.Hours} {hrs} hours on {arguments.WType}...");
            };

            worker.WorkCompleted += delegate (object sender, EventArgs arguments)
            {
                string name = (sender as Worker).Name;
                Console.WriteLine($"{name} finished his duties.");
            };

            worker.DoWork(22, WorkType.Negotiation);

            Console.ReadKey();
        }

        private static void Worker_WorkCompleted1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Worker_ReturnWorkPerformed(object sender, WorkPerformedArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            string name = (sender as Worker).Name;

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");
            Console.WriteLine($"Work is completed by {name}");
        }

        public static void Worker_WorkPerformed(object obj, WorkPerformedArgs args)
        {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");
            Console.WriteLine($"{args.Hours} hours of {args.WType}");
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

        public static int AmountWorkPerformed(int hours, WorkType workType)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");
            // Console.WriteLine($"Arguments: {hours}, {workType}");
            return hours * 25;
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
