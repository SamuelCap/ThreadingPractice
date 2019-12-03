using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingPractise
{
    class TaskManipulation
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(1000);
            Console.WriteLine("Work finished");
        }
        public static void DoWork(int i)
        {
            Console.WriteLine($"Task {i} starting");
            Thread.Sleep(2000);
            Console.WriteLine($"Task {i} finished");
        }
        public static int CalculateResult()
        {
            Console.WriteLine("Work starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
            return 99;
        }
        public static void HelloTask()
        {
            /*
             *Version that triggers ExeptionTask
            int[] e = new int[2];
            int z = e[3] ;
            */
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }
        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }
        public static void ExceptionTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Exception");
        }
    }
}
