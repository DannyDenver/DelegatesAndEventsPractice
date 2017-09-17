using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{

    class Program
    {
        static void Main(string[] args)
        {
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2 + del3;

            //DoWork(del1);

            //  int finalHours = del1(10, WorkType.GoToMeetings);
            //Console.WriteLine(finalHours);

            var worker = new Worker();
            //worker.WorkPerformed += new EventHandler<WorkPerfomedEventArgs>(worker_WorkPerformed);
            //worker.WorkCompleted += new EventHandler(worker_WorkCompleted);

            worker.WorkPerformed += Worker_WorkPerformed;

            worker.WorkPerformed += delegate (object sender, WorkPerfomedEventArgs e)
            {
                Console.WriteLine("Anonymous Method");
            };

            worker.WorkCompleted += Worker_WorkCompleted;


            worker.DoWork(8, WorkType.GenerateReports);

            Console.ReadLine();
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work Complete");

        }

        private static void Worker_WorkPerformed(object sender, WorkPerfomedEventArgs e)
        {
            Console.WriteLine("Hours worked" + e.Hours + " " + e.WorkType);
        }


        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5, WorkType.GoToMeetings);
        //}

        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed 1 ");

            return hours + 1;
        }
        
        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed " + workType + " and hours" + (hours * 1.2));
            return hours + 2;

        }
        static int WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed 3 called " + hours.ToString());
            return hours + 3;
        }

    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
