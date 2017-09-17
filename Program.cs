using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{

    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {

            var custs = new List<Customer>
            {
                new Customer { City = "Phoenix", LastName = "Johne", FirstName = "Dab", Id = 54 },
                new Customer { City = "Phoenix", LastName = "Bonnie", FirstName = "Dab", Id = 52 },
                new Customer { City = "NY", LastName = "Smith", FirstName = "Dab", Id = 51 },
                new Customer { City = "LA", LastName = "Herzog", FirstName = "Dab", Id = 57 }
            };

            var phxcust = custs.Where(c => c.City == "Phoenix");
            foreach(var cust in phxcust)
            {
                Console.WriteLine(cust.LastName);
            }


            var data = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            data.Process(5, 4, multiplyDel);

            Func<int, int, int> functAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultipleDel = (x, y) => x * y;
            var result = data.ProcessFunc(5, 3, funcMultipleDel);
            Console.WriteLine(result);


            Action<int, int> myAddAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);


            data.ProcessAction(3, 4, myAddAction);


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

            ///worker.WorkPerformed += Worker_WorkPerformed;
            ///worker.WorkCompleted += Worker_WorkCompleted;


            //convert to lambda expression 
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            };
            
            worker.WorkPerformed += delegate (object sender, WorkPerfomedEventArgs e)
            {
                Console.WriteLine("Anonymous Method");
            };

            worker.WorkCompleted += (s, e) => Console.WriteLine("Work is completed!");



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
