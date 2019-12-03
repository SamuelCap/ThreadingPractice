using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingPractise
{
    class ChildTasks
    {
        public static void DoChild(object state)
        {
            Console.WriteLine($"Child {state} starting");
            Thread.Sleep(2000);
            Console.WriteLine($"Child {state} finished");
        }
    }
}
