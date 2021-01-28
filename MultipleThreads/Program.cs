using System;
using System.Threading;

namespace MultipleThreads
{
    class Program
    {
        const int Iterations = 1000000;

        static int counter;


        static void Main()
        {
            Thread t1 = new Thread(AddLots);
            Thread t2 = new Thread(AddLots);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(counter);
            Console.ReadLine();
        }

        static void AddLots()
        {
            for (int i = 0; i < Iterations; i++)
            {
                // Broken!
                //counter++;

                //Thread safe
                Interlocked.Increment(ref counter);
            }
        }
    }
}
