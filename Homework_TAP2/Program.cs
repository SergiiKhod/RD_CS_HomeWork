using System.Diagnostics;

namespace Homework_TAP2;

class Program
{
    private static async Task Main()
    {
        int countNumbers;
        int countTasks;
        var stopWatch = new Stopwatch();

        Console.Write("Enter the number of random numbers to generate: ");
        while (!int.TryParse(Console.ReadLine(), out countNumbers) || countNumbers < 0)
        {
            Console.Write("Invalid input. Please enter a positive integer more than 0: ");
        }

        Console.Write("Enter the number of tasks to use for asynchronous calculation: ");
        while (!int.TryParse(Console.ReadLine(), out countTasks) || countTasks < 1)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer more than 0: ");
        }

        Console.WriteLine();
        Console.WriteLine("Generating numbers...");
        var numbers = GenerateRandomNumbers(countNumbers);
        //Console.WriteLine("Generated numbers:");
        //Console.WriteLine(string.Join(", ", numbers));

        Console.WriteLine();
        Console.WriteLine($"Calculating the sum of squares of {countNumbers} random numbers between 1 and 1000...");

        Console.WriteLine();
        stopWatch.Reset();
        stopWatch.Start();
        var syncResult = CalculateSumOfSquaresSync(numbers);
        stopWatch.Stop();

        Console.WriteLine($"Sum of squares (sync): {syncResult}");
        Console.WriteLine($"Sync elapsed time: {stopWatch.ElapsedMilliseconds} ms");

        Console.WriteLine();
        try
        {
            stopWatch.Reset();
            stopWatch.Start();
            var asyncResult = await CalculateSumOfSquaresAsync(numbers, countTasks);
            stopWatch.Stop();

            Console.WriteLine($"Sum of squares (async): {asyncResult}");
            Console.WriteLine($"Async elapsed time: {stopWatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }

    private static int[] GenerateRandomNumbers(int count)
    {
        var random = new Random();
        var numbers = new int[count];

        for (var i = 0; i < count; i++)
        {
            numbers[i] = random.Next(1, 1001);
        }

        return numbers;
    }

    private static long CalculateSumOfSquaresSync(IEnumerable<int> numbers)
    {
        long sum = 0;

        foreach (var number in numbers)
        {
            Thread.Sleep(10);
            var square = (uint)number * (uint)number;
            sum += square;

#if DEBUG
            Console.WriteLine($"{number}: {square}");
#endif
        }

        return sum;
    }

    private static async Task<long> CalculateSumOfSquaresAsync(IEnumerable<int> numbers, int taskCount)
    {
        if (numbers is null)
        {
            throw new ArgumentNullException(nameof(numbers), "Input numbers cannot be null.");
        }

        if (taskCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(taskCount), "Task count must be greater than 0.");
        }

        long sum = 0;
        var tasks = new Task[taskCount];
        var localNumbers = numbers.ToArray();
        for (var i = 0; i < tasks.Length; i++)
        {
            var startIndex = i * (localNumbers.Length / taskCount);
            var endIndex = (i + 1) == tasks.Length ? localNumbers.Length : (i + 1) * (localNumbers.Length / taskCount);
            endIndex = endIndex > localNumbers.Length ? localNumbers.Length : endIndex;
            tasks[i] = Task.Run(() =>
            {
                long localSum = 0;
                for (var j = startIndex; j < endIndex; j++)
                {
                    Task.Delay(10);
                    localSum += (uint)localNumbers[j] * (uint)localNumbers[j];
#if  DEBUG
                    Console.WriteLine($"{localNumbers[j]}: {localNumbers[j] * localNumbers[j]}");
#endif
                }
                Interlocked.Add(ref sum, localSum);
            });
        }

        await Task.WhenAll(tasks);

        return sum;
    }
}