using System.Diagnostics;

namespace Homework_TPL;

internal class Program
{
    private static void Main()
    {
        var numbers = Enumerable.Range(1, 1000000).ToArray();

        var countThreads = Environment.ProcessorCount;
        Console.WriteLine();
        Console.WriteLine();

        //Console.WriteLine("Enter the number of threads you want to use or press Enter to use default:");
        //if (int.TryParse(Console.ReadLine(), out var specifiedDegree))
        //{
        //    countThreads = specifiedDegree;
        //}

        var stopwatch = Stopwatch.StartNew();
        long sequentialSum = 0; //numbers.Sum(Calculate);
        foreach (var number in numbers)
        {
            sequentialSum += Calculate(number);
        }
        stopwatch.Stop();
        Console.WriteLine($"Sequential sum: {sequentialSum}");
        Console.WriteLine($"Time taken (Sequential): {stopwatch.ElapsedMilliseconds} ms");
       
        Console.WriteLine();
        stopwatch.Restart();
        var sumParallel = CalculateWithParallel(numbers, countThreads);
        stopwatch.Stop();
        Console.WriteLine($"Parallel sum using {countThreads} threads: {sumParallel}");
        Console.WriteLine($"Time taken (Parallel): {stopwatch.ElapsedMilliseconds} ms");
        
        Console.WriteLine();
        stopwatch.Restart();
        var sumTasks = CalculateWithTasks(numbers, countThreads).Result;
        stopwatch.Stop();
        Console.WriteLine($"Tasks sum using {countThreads} threads: {sumTasks}");
        Console.WriteLine($"Time taken (Tasks): {stopwatch.ElapsedMilliseconds} ms");
    }

    private static long Calculate(int number)
    {
        return (long)number * number;
    }

    private static long CalculateWithParallel(IEnumerable<int> numbers, int countProcessor)
    {
        var lockObject = new object();
        long result = 0;

        Parallel.ForEach(numbers, new ParallelOptions { MaxDegreeOfParallelism = countProcessor }, number =>
        {
            var square = Calculate(number);
            
            lock (lockObject)
            {
                result += square;
            }
        });

        return result;
    }

    static async Task<long> CalculateWithTasks(int[] numbers, int countTasks)
    {
        var chunkSize = numbers.Length / countTasks;
        var tasks = new Task<long>[countTasks];

        for (var i = 0; i < countTasks; i++)
        {
            var startIndex = i * chunkSize;
            var endIndex = i == countTasks - 1 ? numbers.Length : startIndex + chunkSize;

            tasks[i] = TaskCalculate(numbers, startIndex, endIndex);
        }

        var results = await Task.WhenAll(tasks);
        return results.Sum();
    }

    static Task<long> TaskCalculate(int[] numbers, int start, int end)
    {
        return Task.Run(() =>
        {
            long sum = 0;
            for (var i = start; i < end; i++)
            {
                sum += Calculate(numbers[i]);
            }
            return sum;
        });
    }
}