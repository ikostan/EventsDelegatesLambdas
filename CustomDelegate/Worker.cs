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
        public event ReturnWorkPerformedHandler returnWorkPerformed;
        public event EventHandler workComplete;

        public void DoWork(int hours, WorkType workType)
        {

        }

        //Raising events
        private void RaiseEvent(object obj, EventArgs args) {

            if (returnWorkPerformed != null)
            {
                returnWorkPerformed(12, WorkType.GenerateReports);
            }
        }
    }
}
