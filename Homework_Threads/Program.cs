namespace Homework_Threads
{
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine("Task #1: Print numbers");
            HomeworkTaskFirst();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Task #2: Print letters");
            HomeworkTaskSecond();

        }

        private static void HomeworkTaskFirst()
        {
            const int maxNumber = 10;

            var eventEvenNumbers = new AutoResetEvent(false);
            var eventOddNumbers = new AutoResetEvent(true);

            var threadEvenNumbers = new Thread(() =>
            {
                for (var i = 2; i <= maxNumber; i += 2)
                {
                    eventEvenNumbers.WaitOne();
                    Console.Write(i);
                    eventOddNumbers.Set();
                }
            });

            var threadOddNumbers = new Thread(() =>
            {
                for (var i = 1; i <= maxNumber; i += 2)
                {
                    eventOddNumbers.WaitOne();
                    Console.Write(i);
                    eventEvenNumbers.Set();

                }
            });

            threadOddNumbers.Start();
            threadEvenNumbers.Start();

            threadOddNumbers.Join();
            threadEvenNumbers.Join();
        }

        private static void HomeworkTaskSecond()
        {
            var eventCharA = new AutoResetEvent(true);
            var eventCharB = new AutoResetEvent(false);
            var eventCharC = new AutoResetEvent(false);
            var flPrint = true;

            var threadCharA = new Thread(() =>
            {
                while (flPrint)
                {
                    eventCharA.WaitOne();
                    Console.Write("A");
                    Thread.Sleep(1000);
                    eventCharB.Set();
                }
            });

            var threadCharB = new Thread(() =>
            {
                while (flPrint)
                {
                    eventCharB.WaitOne();
                    Console.Write("B");
                    Thread.Sleep(1000);
                    eventCharC.Set();
                }
            });

            var threadCharC = new Thread(() =>
            {
                while (flPrint)
                {
                    eventCharC.WaitOne();
                    Console.Write("C");
                    Thread.Sleep(1000);
                    eventCharA.Set();
                }
            });

            Console.WriteLine("Press any key to stop....");

            threadCharA.Start();
            threadCharB.Start();
            threadCharC.Start();

            Console.ReadKey(true);
            flPrint = false;

            threadCharA.Join();
            threadCharB.Join();
            threadCharC.Join();
        }
    }
}