Console.WriteLine("Enter an integer:");
string? str = Console.ReadLine();
int number = int.Parse(str);
int countDigits = str.Length;
for (int i = countDigits; i > 0; i--)
{
    Console.WriteLine((number - (number / (int)Math.Pow(10, i)) * (int)Math.Pow(10, i)) / (int)Math.Pow(10, i - 1));
}
Console.ReadLine();