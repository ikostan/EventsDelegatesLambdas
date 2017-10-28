using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegate
{
    public delegate int ReturnWorkPerformedHandler(int hours, WorkType workType);

    class Worker
    {

        //Declaring events
        public event ReturnWorkPerformedHandler returnWorkPerformed; //Event definition
        public event EventHandler workCompleted;

        public virtual void DoWork(int hours, WorkType workType)
        {

            for (int i = 0; i < hours; i++)
            {
                //Raise an event for each hour of work
                //Do some work and notify consumer that work has been performed
                OnWorkPerformed(hours, workType);
            }

            //Raise an event when the work is done
        }

        //Work completed method
        protected virtual void OnWorkCompleted()
        {
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
            //Raise event
            ReturnWorkPerformedHandler del = returnWorkPerformed as ReturnWorkPerformedHandler;

            if (del != null) //Check if listener attached
            {
                del(hours, workType);
            }
        }

    }
}
