namespace HomeWork_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phonebook = new PhoneBook();
            phonebook.AddRange(DataGenerator.GenerateContact(10));
            while (true)
            {
                ConsoleInterface.PrintMenu();
                var choice = Console.ReadLine();
                int item = 0;
                if (int.TryParse(choice, out item))
                {
                    ConsoleInterface.ProcessMenuChoice(phonebook, item);
                }
            }
        }
    }
}

