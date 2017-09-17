using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //public delegate int WorkPerformedHandler(object sender, WorkPerfomedEventArgs e);


    public class Worker
    {
        //public event WorkPerformedHandler WorkPerformed;

        public event EventHandler<WorkPerfomedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted; 
        
        public void DoWork(int hours, WorkType workType)
        {
            for(int i = 0; i < hours; i++)
            {
                //raise event
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }

            //raise workcompleted
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed;
            if(del != null)
            {
                del(this, new WorkPerfomedEventArgs(hours, workType));
            }
        }
        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
