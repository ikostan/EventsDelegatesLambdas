using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegate
{
    //public delegate int ReturnWorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {

        //Declaring events
        public event EventHandler<WorkPerformedArgs> returnWorkPerformed; //Event definition
        public event EventHandler workCompleted;

        public virtual void DoWork(int hours, WorkType workType)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            Console.WriteLine("Start looping..."); 

            for (int i = 0; i < hours; i++)
            {
                //Raise an event for each hour of work
                //Do some work and notify consumer that work has been performed
                OnWorkPerformed(hours, workType);
            }

            //Raise an event when the work is done
            OnWorkCompleted();
        }

        //Work completed method
        protected virtual void OnWorkCompleted()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            //Invoke delegate
            var del = workCompleted as EventHandler;

            if (del != null) //Test if listener attached
            {
                //Pass itself as an object and pass empty EventArgs because we do not have any.
                del(this, EventArgs.Empty);
            }
        }

        //Work performed method
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            //Raise event
            var del = returnWorkPerformed as EventHandler<WorkPerformedArgs>;

            if (del != null) //Check if listener attached
            {
                del(this, new WorkPerformedArgs() { Hours = hours, WType = workType });
            }
        }

    }
}
