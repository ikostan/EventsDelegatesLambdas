using JobManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement
{
    public sealed class Mediator
    {
        private static readonly Mediator _Instance = new Mediator();

        /// <summary>
        /// Constructor
        /// </summary>
        private Mediator() { }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <returns></returns>
        public static Mediator GetInstance()
        {
            return _Instance;
        }

        //Instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        //Event handler
        public void OnJobChanged(object sender, Job job)
        {
            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;

            if (jobChangedDelegate != null)
            {
                jobChangedDelegate(sender, new JobChangedEventArgs { Job = job});
            }
        }

    }
}
