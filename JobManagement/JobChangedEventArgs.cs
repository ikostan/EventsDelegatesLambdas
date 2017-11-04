using JobManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement
{
    public class JobChangedEventArgs : EventArgs
    {
        public Job Job { get; set; }
    }
}
