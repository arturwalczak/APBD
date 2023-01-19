using System;
using System.Collections.Generic;

namespace LinqTutorials
{
    class Program
    {
        static void print(IEnumerable<object> task)
        {
            foreach (var obj in task) Console.WriteLine(obj);
            Console.WriteLine("==================================");
        }

        static void Main(string[] args)
        {
            print(LinqTasks.Task1());
            print(LinqTasks.Task2());
            Console.WriteLine(LinqTasks.Task3());
            Console.WriteLine("==================================");
            print(LinqTasks.Task4());
            print(LinqTasks.Task5());
            print(LinqTasks.Task6());
            print(LinqTasks.Task7());            
            Console.WriteLine(LinqTasks.Task8());
            Console.WriteLine("==================================");
            Console.WriteLine(LinqTasks.Task9());
            Console.WriteLine("==================================");
            print(LinqTasks.Task10());
            print(LinqTasks.Task11());
            print(LinqTasks.Task12());
            Console.WriteLine("TASK 13");
            int[] arr = { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1 };            
            Console.WriteLine(LinqTasks.Task13(arr));            
            print(LinqTasks.Task14());
        }
    }
}
