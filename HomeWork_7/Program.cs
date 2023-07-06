namespace HomeWork_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[]
            {
                new Ferrari(),
                new Hammer(),
                new Scania()
            };

            ConsoleInterface inf = new ConsoleInterface(cars);

            inf.Run();
        }
    }
}