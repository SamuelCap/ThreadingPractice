using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Invoke example using parallel. 
             * 
            Parallel.Invoke(() => ParallelInvoke.Task1(), () => ParallelInvoke.Task2());
            */

            /*
             * ForEach example using parallel. 
             * 
            var items = Enumerable.Range(0, 500);
            Parallel.ForEach(items, item =>
              {
                  ParallelForEach.WorkOnItem(item);
              });
            */

            /*
             * For example using lambda with parallel.
             * 
            var items = Enumerable.Range(1, 10).ToArray();
            Parallel.For(0, items.Length, i =>
            {
                ParallelForEach.WorkOnItem(items[i]);
            });
            */

            /*
             * Using loopstate to test what happens with stop and break.
             * 
            var items = Enumerable.Range(24, 202).ToArray();
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                {
                    //loopState.Stop();
                    loopState.Break();
                }

                ParallelForEach.WorkOnItem(items[i]);
            });
            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            */

            /*
             * Going through a an array in parallel using AsParallel.
             * 
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};
            var result = from person in people.AsParallel()
                         where person.City == "Seattle"
                         select person;
            foreach (var person in result)
                Console.WriteLine(person.Name);
            */

            /*
             * Using force Parallelism so asParallel query doesn't decide.
             * 
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};
            var result = from person in people.AsParallel().
                WithDegreeOfParallelism(4).
                WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where person.City == "Seattle"
                         select person;
            foreach (var person in result)
                Console.WriteLine(person.Name);
            */

            /* 
             * The order from Person[] is printed when using AsOrdered.
             * 
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};
            var result = from person in people.AsParallel().AsOrdered()
                         where person.City == "Seattle"
                         select person;
            foreach (var person in result)
                Console.WriteLine(person.Name);
            */

            /*
             * The foreach loop runs in order when using AsSequential. Take returns first n in result. 
             * 
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};
            var result = (from person in people.AsParallel()
                          where person.City == "Seattle"
                          orderby (person.Name)
                          select new
                          {
                              Name = person.Name
                          }).AsSequential().Take(3);
            foreach (var person in result)
                Console.WriteLine(person.Name);
            */

            /*
             * ForAll is a loop that runs in parallel. 
             * 
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};
            var result = from person in people.AsParallel()
                         where person.City == "Seattle"
                         select person;
            result.ForAll(person => Console.WriteLine(person.Name));
            */

            /*
             * Returns the number of errors catched.
             * 
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "", City = "Quito"},
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "Peter", City = "" },
                new Person { Name = "", City = "Kingston"},
                new Person { Name = "James", City = "London" }};
            try
            {
                var result = from person in
                    people.AsParallel()
                             where Person.CheckCity(person.City)
                             select person;
                result.ForAll(person => Console.WriteLine(person.Name));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exceptions.");
            }
            */

            /*
             * Using .Start and .Wait with functions with Task dataType. 
             * 
            Task newTask = new Task(() => TaskManipulation.DoWork());
            newTask.Start();
            newTask.Wait();
            */

            /*
             * Using .Run with functions with Task dataType. 
             * 
            Task newTask = Task.Run(() => TaskManipulation.DoWork());
            newTask.Wait();
            */

            /*
             * Setting task to a variable rather than a function.
             * 
            Task<int> task = Task.Run(() =>
            {
                return TaskManipulation.CalculateResult();
            });
            Console.WriteLine(task.Result);
            */

            /*
             * Using .WaitAll for all tasks to be completed. .WaitAny waits until 1 task is completed (other tasks continue running).
             * 
            Task[] Tasks = new Task[4];

            for (int i = 0; i < 4; i++)
            {
                int taskNum = i;  // make a local copy of the loop counter so that the 
                                  // correct task number is passed into the lambda expression
                                  // As thread will be outside of this for loop where i doesn't equal the current iteration.
                Tasks[taskNum] = Task.Run(() => TaskManipulation.DoWork(taskNum));
            }
            Task.WaitAll(Tasks);
            Task.WaitAny(Tasks);
            */

            /*
             * Creates a pipelin of tasks, .ContinueWith parameter is the task that follows the task that calls .ContinueWith.
             * 
            Task task = Task.Run(() => TaskManipulation.HelloTask());
            task.ContinueWith((x) => TaskManipulation.WorldTask());
            //task.ContinueWith((x) => TaskManipulation.WorldTask()).ContinueWith((y) => TaskManipulation.HelloTask());
            */

            /*
             * Using the .ContinueWith overload function that accepts a TaskContinuationOption.
             * If .HelloTask is run to complition .WorldTask is run but if there is a fault .ExceptionTask will run.
             * 
            Task task = Task.Run(() => TaskManipulation.HelloTask());
            task.ContinueWith((x) => TaskManipulation.WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((x) => TaskManipulation.ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);
            */

            /*
             * A parent task creates 10 child tasks. .StartNew parameter is the lambda expression giving the behavior of the task
             * The overload of .StartNew has 3 parameters: lambdda expression, state of type object, TaskCreationOption value that requests the new task is a child task.
             * 
            var parent = Task.Factory.StartNew(() => {
                Console.WriteLine("Parent starts");
                for (int i = 0; i < 10; i++)
                {
                    int taskNo = i;
                    Task.Factory.StartNew(
                        (x) => ChildTasks.DoChild(x), // lambda expression
                               taskNo, // state object
                               TaskCreationOptions.AttachedToParent);
                }
            });

            parent.Wait(); // will wait for all the attached children to complete
            */

            /*
             * Creating a thread then starting it. The parameter for the thread constuctor is a method (FirstThreads.ThreadHello in this instance).
             *
            Thread thread = new Thread(FirstThreads.ThreadHello);
            thread.Start();
            */

            /* 
             * How thread used to work, by first creating a ThreadStart object.
             * 
            ThreadStart ts = new ThreadStart(FirstThreads.ThreadHello);
            Thread thread = new Thread(ts);
            thread.Start();
            */

            /*
             * Starting a thread using a lambda expression.
             * 
            Thread thread = new Thread(() =>
            {
                Console.WriteLine("Hello from the thread");
                Thread.Sleep(1000);
            });
            thread.Start();
            */

            /*
             * ParameterizedThreadStart is used when when a thread has parameters.
             * 
            ParameterizedThreadStart ps = new ParameterizedThreadStart(FirstThreads.WorkOnData);
            Thread thread = new Thread(ps);
            thread.Start(79);
            */


            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();

        }
    }
}
