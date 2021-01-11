using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitReturnValAccess
{
    class Program
    {
        //displayResult() is dependent on GetSum()
        static void Main(string[] args)
        {
            callThisFirst();
           Thread.Sleep(1000);

        }

        static async Task callThisFirst()
        {
            Task<int> task = GetSum(5000);
            int sum =await task;
            //displayResult(task);
            displayResult(sum);
        }

        static async Task<int> GetSum(int n)
        {
            var sum = 0;
            await Task.Run(() =>
            {
                for(int i=1;i<=n;i++)
                {
                    sum += i;
                }

            });
            return sum;
        }

        static void displayResult(int result)
        {
            Console.WriteLine($"Result is: {result}");
        }
    }
}
