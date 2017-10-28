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
        public event EventHandler workComplete;

        public virtual void DoWork(int hours, WorkType workType)
        {
            //Do some work and notify consumer that work has been performed
            OnWorkPerformed(hours, workType);
        }

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
