using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CustomDelegate
{
    //public delegate int ReturnWorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {

        //Declaring events
        public event EventHandler<WorkPerformedArgs> ReturnWorkPerformed; //Event definition
        public event EventHandler WorkCompleted;

        public string Name { get; set; }

        //Do some work and raise an event while doing it. 
        //Raise an event when the work is done.
        public virtual void DoWork(int hours, WorkType workType)
        {
            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            //Console.WriteLine("Start looping..."); 

            for (int i = 1; i <= hours; i++)
            {
                //Sleep 1 sec
                Thread.Sleep(1000);

                //Raise an event for each hour of work
                //Do some work and notify consumer that work has been performed
                OnWorkPerformed(i, workType);
            }

            //Raise an event when the work is done
            OnWorkCompleted();
        }

        //Work completed method
        protected virtual void OnWorkCompleted()
        {
            ///Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            //Invoke delegate
            var workCompletedEvent = WorkCompleted as EventHandler;

            if (workCompletedEvent != null) //Test if listener attached
            {
                //Pass itself as an object and pass empty EventArgs because we do not have any.
                workCompletedEvent(this, EventArgs.Empty);
            }
        }

        //Work performed method
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + " method called");

            //Raise event
            var workEvent = ReturnWorkPerformed as EventHandler<WorkPerformedArgs>;

            if (workEvent != null) //Check if listener attached
            {
                workEvent(this, new WorkPerformedArgs() { Hours = hours, WType = workType });
            }
        }


    }
}
