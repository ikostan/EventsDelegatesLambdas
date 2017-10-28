using System;

namespace CustomDelegate
{
    public class WorkPerformedArgs : EventArgs
    {
        public int Hours { get; set; }
        public WorkType WType { get; set; }
    }
}