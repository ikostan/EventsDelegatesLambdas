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
            //RegularHandler(worker);

            //Anonymous methods:
            //AnonymousMethods(worker);

            //Using Lambda expression:
            LambdaExpression(worker);

            //Do some work and report on the progress
            worker.DoWork(22, WorkType.Negotiation);

            Console.ReadKey();
        }

        //Using Lambda expression:
        private static void LambdaExpression(Worker worker) {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            //Report on progress
            worker.ReturnWorkPerformed += (obj, args) => {
                Console.Clear();
                string hrs = (args.Hours > 1) ? "hours" : "hour";
                Console.WriteLine($"Working {args.Hours} {hrs} hours on {args.WType}...");
            };

            //Report on completion
            worker.WorkCompleted += (obj, args) =>
            {
                string name = (obj as Worker).Name;
                Console.WriteLine($"{name} finished his duties.");
            };
        }

        private static void AnonymousMethods(Worker worker)
        {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            //Report on progress
            worker.ReturnWorkPerformed += delegate (object sender, WorkPerformedArgs arguments)
            {
                Console.Clear();
                string hrs = (arguments.Hours > 1) ? "hours" : "hour";
                Console.WriteLine($"Working {arguments.Hours} {hrs} on {arguments.WType}...");
            };

            //Report on completion
            worker.WorkCompleted += delegate (object sender, EventArgs arguments)
            {
                string name = (sender as Worker).Name;
                Console.WriteLine($"{name} finished his duties.");
            };
        }

        private static void RegularHandler(Worker worker)
        {
            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            worker.ReturnWorkPerformed += new EventHandler<WorkPerformedArgs>(Worker_WorkPerformed); //Report on completion
            worker.WorkCompleted += new EventHandler(Worker_WorkCompleted); //Report on progress
        }

        //Report on completion
        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            string name = (sender as Worker).Name;

            System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");
            Console.WriteLine($"Work is completed by {name}");
        }

        //Report on progress
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
