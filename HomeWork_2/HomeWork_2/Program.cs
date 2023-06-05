Console.WriteLine(" Enter a number from 10000 to 99999:");
string? str = Console.ReadLine();
int number = Convert.ToInt32(str);

int numberFirst = number / 10000;
int numberSecond = (number - (number / 10000)*10000)/1000;
int numberThird = (number - (number / 1000) * 1000) / 100;
int numberFourth = (number - (number / 100) * 100) / 10;
int numberFifth = (number - (number / 10) * 10) / 1;

Console.WriteLine($"{numberFirst} {numberSecond} {numberThird} {numberFourth} {numberFifth}");

Console.ReadLine();