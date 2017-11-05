using CommunicatingBetweenControls.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        //Has one instance only (Singleton)
        private static readonly Mediator _Instance = new Mediator();

        private Mediator() { }

        public static Mediator GetInstance() { return _Instance; }

        //Instance functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var JobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;

            if (JobChangedDelegate != null)
            {
                JobChangedDelegate(sender, new JobChangedEventArgs{ Job = job });
            }
        }

    }
}
