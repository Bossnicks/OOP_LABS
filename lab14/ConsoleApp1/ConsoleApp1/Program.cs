using System;
using System.Diagnostics;
using System.Reflection;

namespace lab14
{
    public class Program
    {
        public static void Main()
        {
            First();
            Second();
            Third();
            Fourth();
            Fifth();
        }
        static void First()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var allProcess = Process.GetProcesses();
            foreach (var process in allProcess)
                try
                {
                    Console.WriteLine(
                        $"ID: {process.Id}  Name: {process.ProcessName} Priority: {process.BasePriority} " +
                        $"VirtualMemorySize64: {process.VirtualMemorySize64}");
                    Console.WriteLine(
                        $"Start time : {process.StartTime}  Total processor time: {process.TotalProcessorTime}\n");
                }
                catch
                {
                    Console.WriteLine();
                }
        }

        static void Second()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}\n");
            Console.WriteLine($"Config datails: {domain.SetupInformation}\n");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}\n");
            Console.WriteLine("Assemblies: \n");

            //foreach (var ass in domain.GetAssemblies()) Console.WriteLine(ass.FullName);

            //var newDomain = AppDomain.CreateDomain("Domain");
            //newDomain.Load(Assembly.GetExecutingAssembly().GetName());
            //AppDomain.Unload(newDomain);
        }

        private static void Third()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var first = new Thread(ShowSimpleNumbers);
            first.Start();
            first.Name = "SimpleNumbersThread";
            first.Join();
            Console.WriteLine();
        }
        private static void ShowThreadInfo(object thread)
        {
            var currentThread = thread as Thread;
            Console.WriteLine($"Name: {currentThread.Name}");
            Console.WriteLine($"Id: {currentThread.ManagedThreadId}");
            Console.WriteLine($"Priority: {currentThread.Priority}");
            Console.WriteLine($"Status: {currentThread.ThreadState}");
        }
        private static void ShowSimpleNumbers()
        {
            var first = new Thread(ShowThreadInfo);
            first.Start(Thread.CurrentThread);
            first.Join();

            Console.WriteLine("INTER N!!!!!!!!!!!!!!!!!!!!!!!!");
            int n = int.Parse(Console.ReadLine());
            for (var i = 1; i <= n; i++)
            {
                var isSimple = true;
                for (var j = 2; j <= i / 2; j++)
                    if (i % j == 0)
                    {
                        isSimple = false;
                        break;
                    }

                if (isSimple)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }
        private static void Fourth()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            var even = new Thread(ShowEvenNumbers) { Priority = ThreadPriority.Highest };
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            Console.WriteLine();
            FirstlyEvenSecondlyOdd();
            Console.WriteLine();
            ShowOneByOne();



        }
        private static void ShowOneByOne()
        {
            var mutex = new Mutex();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            odd.Start();
            even.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                for (var i = 0; i < 20; i++)
                {
                    mutex.WaitOne();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (i % 2 == 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 20; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }
        }
        private static void FirstlyEvenSecondlyOdd()
        {
            var objectToLock = new object();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                     (objectToLock)
                {
                    for (var i = 0; i < 20; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (i % 2 == 0)
                            Console.Write(i + " ");
                    }
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 20; i++)
                {
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                }
            }
        }
        private static void ShowEvenNumbers()
        {
            for (var i = 0; i < 20; i++)
            {
                Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.Red;
                if (i % 2 == 0)
                    Console.Write(i + " ");
            }
        }
        private static void ShowOddNumbers()
        {
            for (var i = 0; i < 20; i++)
            {
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Blue;
                if (i % 2 != 0)
                    Console.Write(i + " ");
            }
        }
        private static void Fifth()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            int counter = 1;
            TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);
            var timer = new Timer(timerCallback, null, 0, 1000);
            Thread.Sleep(5000);
            timer.Change(Timeout.Infinite, 2000);

            void WhatTimeIsIt(object obj)
            {
                Console.WriteLine(counter);
                counter++;
            }




        }
    }
}