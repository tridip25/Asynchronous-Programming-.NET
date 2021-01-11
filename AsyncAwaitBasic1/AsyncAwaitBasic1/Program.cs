using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitBasic1
{
    class Program
    {       //uncomment the commented lines to see the difference
        static void Main(string[] args)
        {
            //rr();
            //Thread.Sleep(5000);   //this is just to give a time delay
            method1();
            method2();
        }

        //static async Task rr()
        //{
        //    await method1();
        //    method2();
        //}

        static async Task method1()
        {
           await Task.Run(()=>
           {
               for (int i = 0; i < 50; i++)
               {
                   Console.WriteLine($"Hello : {i}");
               }
           }
           );
        }

        static void method2()
        {
            for(int i=0;i<100;i++)
            {
                Console.WriteLine(i);

            }
        }
    }
}
