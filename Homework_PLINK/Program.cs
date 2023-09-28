using System.Diagnostics;

namespace Homework_PLINK;

internal class Program
{
    private const int TimeDelay = 1;

    private static void Main()
    {
        int countThreads;
        do
        {
            Console.Clear();
            Console.Write($"Enter the count of threads to use (max {Environment.ProcessorCount}): ");
            int.TryParse(Console.ReadLine(), out countThreads);
        } while (countThreads <= 0 || countThreads > Environment.ProcessorCount);

        int countNumbers;
        do
        {
            Console.Clear();
            Console.WriteLine($"Enter the count of threads to use (max {Environment.ProcessorCount}): {countThreads}");
            Console.Write($"Enter the count of numbers to calculate): ");
            int.TryParse(Console.ReadLine(), out countNumbers);
        } while (countNumbers <= 0);

        Console.WriteLine("Generating numbers...");
        var numbers = Enumerable.Range(1, 100).ToArray();

        Console.WriteLine("Calculating...");
        CalculateAndPrintResult(numbers, "LINQ", countThreads, CalculateLinq);
        CalculateAndPrintResult(numbers, "PLINQ", countThreads, CalculateParallelLinq);

    }

    private static void CalculateAndPrintResult(
        int[] numbers,
        string methodName,
        int countThreads,
        Func<int[], int, int> calculate)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = calculate(numbers, countThreads);
        stopwatch.Stop();

        Console.WriteLine();
        Console.WriteLine($"Using {methodName}");
        Console.WriteLine($"Result: {result}");
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }

    private static int CalculateLinq(int[] numbers, int countThreads)
    {
        var result = numbers
            .Select(x =>
            {
                Task.Delay(TimeDelay).Wait();
                return x;
            })
            .Where(x => x % 2 == 0)
            .Select(x => x * x)
            .ToList();
        return result.Count;
    }
    private static int CalculateParallelLinq(int[] numbers, int countThreads)
    {
        var result = numbers
            .AsParallel()
            .WithDegreeOfParallelism(countThreads)
            .Select(x =>
            {
                Task.Delay(TimeDelay).Wait();
                return x;
            })
            .Where(x => x % 2 == 0)
            .Select(x => x * x)
            .ToList();
        return result.Count;
    }

}