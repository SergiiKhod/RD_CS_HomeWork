const int N = 10;

int randMax = 30;
int randMin = 0;
Random rand = new Random();

int[,] numbers = new int[N, N];
for (int i = 0; i < numbers.Rank; i++)
    for (int j = 0; j < numbers.GetLength(i); j++)
    {
        int numberNew = 0;
        bool isGetNewNumber = true;
        while (isGetNewNumber)
        {
            numberNew = rand.Next(randMin, randMax);
            isGetNewNumber = false;

            for (int iFind = 0; iFind < numbers.Rank; iFind++)
            {
                for (int jFind = 0; jFind < numbers.GetLength(iFind); jFind++)
                {
                    if (numberNew == numbers[iFind, jFind])
                    {
                        isGetNewNumber = true;
                        break;
                    }
                }
                if (isGetNewNumber) break;
            }
        }
        numbers[i, j] = numberNew;
    }

Console.WriteLine($"Array: ");
for (int i = 0; i < numbers.Rank; i++)
{
    string strRow = string.Empty;
    for (int j = 0; j < numbers.GetLength(i); j++)
    {
        strRow += $"\t{numbers[i, j]}";
    }
    Console.WriteLine(strRow);
}

Console.WriteLine();

int[,] numbersReverse = new int[N, N];
for (int i = 0; i < numbers.Rank; i++)
    for (int j = 0; j < numbers.GetLength(i); j++)
    {
        numbersReverse[i, j] = numbers[numbers.Rank - i - 1, numbers.GetLength(i) - j - 1];
    }

Console.WriteLine($"Reverse array: ");
for (int i = 0; i < numbersReverse.Rank; i++)
{
    string strRow = string.Empty;
    for (int j = 0; j < numbersReverse.GetLength(i); j++)
    {
        strRow += $"\t{numbersReverse[i, j]}";
    }
    Console.WriteLine(strRow);
}

int numberMax = numbers[0, 0];
int numberMin = numbers[0, 0];
for (int i = 0; i < numbers.Rank; i++)
    for (int j = 0; j < numbers.GetLength(i); j++)
    {
        if (numbers[i, j] > numberMax) numberMax = numbers[i, j];
        if (numbers[i, j] < numberMin) numberMin = numbers[i, j];
    }
Console.WriteLine();

Console.Write($"Enter a integer from {numberMin} to {numberMax} to search for a position in the array: ");
string? str = Console.ReadLine();
int number = 0;
bool isNumber = Int32.TryParse(str, out number);

if (isNumber)
{
    int row = 0;
    int column = 0;
    bool isFinded = false;
    for (int i = 0; i < numbers.Rank; i++)
    {
        for (int j = 0; j < numbers.GetLength(i); j++)
        {
            if (numbers[i, j] == number)
            {
                row = i;
                column = j;
                isFinded = true;
                break;
            }
        }
        if (isFinded) break;
    }

    if (isFinded)
        Console.WriteLine($"{number}  position is  [{row},{column}]");
    else
        Console.WriteLine($"{number} is not in the array");
}
else
{
    Console.WriteLine($"{str} is not integer");
}

Console.ReadKey();





