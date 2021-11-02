using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads_Practice
{
    partial class Program
    {
        //Shared sum to keep count of the char's used combined.
        static int sum = 0;
        //Shared lock object to ensure interlock.
        static object _lock = new object();
        //Shared string to write in console.
        static string consolewriter = "";
        static void Main()
        {
            Thread[] threads = new Thread[2];
            for (int i = 0; i < 10; i++)
            {
                //Makes a new thread, starts it and runs Hashtag, Hashtag is locked with Monitor. After it writes the sum in console.
                threads[0] = new Thread(Hashtag);
                threads[0].Start();
                threads[0].Join();

                //Makes a new thread, starts it and runs Star, Star is locked with Monitor. After it writes the sum in console.
                threads[1] = new Thread(Star);
                threads[1].Start();
                threads[1].Join();
            }
            Console.ReadLine();
        }
        //This method firstly clears the consolewriter string, then adds 60 * "#" to the string consolewriter, for each char it adds it also adds to the combined sum of char's used. Last it writes the consolewriter in console and end it with the combined sum.
        static void Hashtag()
        {
            Monitor.Enter(_lock);
            try
            {
                consolewriter = "";
                for (int i = 0; i < 60; i++)
                {
                    consolewriter += "#";
                    sum++;
                }
                Console.WriteLine(consolewriter + "     " + sum);
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
        //This method firstly clears the consolewriter string, then adds 60 * "*" to the string consolewriter, for each char it adds it also adds to the combined sum of char's used. Last it writes the consolewriter in console and end it with the combined sum.
        static void Star()
        {
            Monitor.Enter(_lock);
            try
            {
                consolewriter = "";
                for (int i = 0; i < 60; i++)
                {
                    consolewriter += "*";
                    sum++;
                }
                Console.WriteLine(consolewriter + "     " + sum);
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
