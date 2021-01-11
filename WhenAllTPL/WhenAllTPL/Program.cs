using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhenAllTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(() => displayName());
            Task t2 = Task.Factory.StartNew(() => displayStat());
            Task t3 = Task.Factory.StartNew(() => displayLocation());
            Thread.Sleep(2000);
            Task t = Task.WhenAll(t1, t2, t3);
            if(t.IsCompleted==true)
            {
                Console.WriteLine("All tasks has been completed successfully");
            }
        }

        static void displayName()
        {
            Console.WriteLine("Name is Brad");
        }

        static void displayStat()
        {
            Console.WriteLine("Stat is Online");
        }

        static void displayLocation()
        {
            Console.WriteLine("Location is India");
        }
    }
}
