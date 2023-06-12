const int N = 5;

int[] numbers = new int[N];
for (int i = 0;i < N; i++)
{
    Console.Write($"Enter a number № {i + 1}: ");
    numbers[i] = Convert.ToInt32(Console.ReadLine());
}

int numbersSummary = 0;
foreach(int number in numbers)
{
    numbersSummary += number;
}    

Console.WriteLine($"Summary: {numbersSummary}");


