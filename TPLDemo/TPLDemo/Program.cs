using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(() => DoWork(1, 2000)).ContinueWith((prev)=>DoOtherWork(1,2000));
            Task t2 = Task.Factory.StartNew(() => DoWork(2, 1000));
            Task t3 = Task.Factory.StartNew(() => DoWork(3, 3500));
            Console.WriteLine("Press any key to exit\n");
            Console.ReadKey();
        }

        static void DoWork(int id, int sleep)
        {
            Console.WriteLine($"Task {id} is beginning...");
            Thread.Sleep(sleep);
            Console.WriteLine($"Task {id} is completed...");
        }

        static void DoOtherWork(int id, int sleep)
        {
            Console.WriteLine($"Other Task {id} is beginning...");
            Thread.Sleep(sleep);
            Console.WriteLine($"Other Task {id} is completed...");
        }
    }
}
