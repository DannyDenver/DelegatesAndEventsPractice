﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class WorkPerfomedEventArgs : EventArgs
    {
        public WorkPerfomedEventArgs(int hours, WorkType worktype)
        {
            Hours = hours;
            WorkType = worktype;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
