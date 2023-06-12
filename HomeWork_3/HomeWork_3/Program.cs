Console.Write(" Enter any number: ");
string? str = Console.ReadLine();
int number = 0;
bool isNumber = Int32.TryParse(str, out number);

if (isNumber)
{
    bool isPrimeNumber = number >= 2;
    if (number > 2)
    {
        int maxCheckedNumber = (int)Math.Floor(Math.Sqrt(number));

        for (int n = 2; n <= maxCheckedNumber; n++)
        {
            if (number % n == 0)
            {
                isPrimeNumber = false;
                break;
            }
        }
    }

    if (isPrimeNumber)
        Console.WriteLine($@"{number} is a prime number");
    else
        Console.WriteLine($@"{number} is NOT prime number");
}
else
{
    Console.WriteLine($@"{str} is not an integer");
}

Console.ReadKey();
