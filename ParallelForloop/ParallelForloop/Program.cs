using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForloop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<data11> values = File.ReadAllLines("C:\\Users\\Tridip\\source\\abc1.csv")
                                             .Skip(1)
                                             .Select(v => FromCsv(v))
                                             .ToList();

            //foreach(var value in values)
            //{
            //    Console.WriteLine(value.period +" "+ value.previously +" "+ value.revised);
            //}

            Stopwatch stopwatch = new Stopwatch();
            var count = 0;
            stopwatch.Start();
            Parallel.For(0, values.Count, i =>
            {
             
                Interlocked.Add(ref count, (int)values[i].revised);
            });
            stopwatch.Stop();

            Console.WriteLine("Time elapsed (ms): {0}", stopwatch.Elapsed.TotalMilliseconds);



            //stopwatch.Start();
            //for (int i = 0; i < values.Count; i++)
            //{
            //    count += (int)values[i].revised;
            //}
            //stopwatch.Stop();
            //Console.WriteLine("Time elapsed (ms): {0}", stopwatch.Elapsed.TotalMilliseconds);



            Console.WriteLine(count);

        }

        public static data11 FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            data11 data = new data11();
            data.period = values[0];
            data.previously = double.Parse(values[1]);
            data.revised = double.Parse(values[2]);
            return data;
        }

    }
}
