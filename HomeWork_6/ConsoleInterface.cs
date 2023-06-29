namespace HomeWork_6
{
    public static class ConsoleInterface
    {
        public enum ItemMenu
        {
            SHOW = 1,
            ADD = 2,
            FIND = 3,
            EXIT = 0
        }


        public static void PrintContacts(List<Contact> listContacts)
        {
            Console.WriteLine();
            PhoneBook.ShowContacts(listContacts);
        }

        public static void PrintMenu()
        {
            Console.Beep();
            Console.Clear();
            Console.WriteLine("Program Menu:");
            Console.WriteLine("1. Show Phone Book");
            Console.WriteLine("2. Add Contact");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("0. Exit Program");
            Console.Write("Please choose a menu option, enter the corresponding number: ");
        }

        public static void ProcessMenuChoice(PhoneBook phoneBook, int choice)
        {

            switch (choice)
            {
                case (int)ItemMenu.SHOW:
                    PrintAllPhoneBook(phoneBook);
                    break;
                case (int)ItemMenu.ADD:
                    AddContact(phoneBook);
                    break;
                case (int)ItemMenu.FIND:
                    SearchContact(phoneBook);
                    break;
                case (int)ItemMenu.EXIT:
                    ExitProgram();
                    break;
                default:
                    Console.Write("Invalid menu choice. Please try again:");
                    break;
            }
        }

        public static void PrintAllPhoneBook(PhoneBook phoneBook)
        {
            Console.WriteLine();
            Console.WriteLine("PHONEBOOK");
            PhoneBook.ShowContacts(phoneBook.GetContacts());
            Console.Read();
        }

        public static void AddContact(PhoneBook phoneBook)
        {
            string phone = ReadPhone("Mobile Phone");
            if (string.IsNullOrWhiteSpace(phone)) { return; }
            if (phoneBook.FindByPhone(phone).Count > 0)
            {
                Console.WriteLine($"The contact is already in the phone book! ");
                Console.Read();
                return;
            }

            string nameFirst = ReadName("First Name");
            if (string.IsNullOrWhiteSpace(nameFirst)) { return; }

            string nameSecond = ReadName("Second Name");
            if (string.IsNullOrWhiteSpace(nameSecond)) { return; }

            Console.Write($"Enter Address: ");
            var address = Console.ReadLine();
            phoneBook.Add(new Contact(nameFirst, nameSecond, phone, $"{address}"));
            Console.WriteLine($"Contact added! ");
            Console.Read();
        }

        private static string ReadName(string fieldName = "Name")
        {
            string ret = string.Empty;
            while (true)
            {
                Console.Write($"Enter {fieldName}: ");
                var name = Console.ReadLine();
                if (name != null && Contact.CheckName(name))
                {
                    ret = name;
                    break;
                }
                else
                {
                    Console.WriteLine(Contact.GetInvalidNameMessage(fieldName));
                    if (!AskForContinuation())
                    {
                        break;
                    }
                }


            }
            return ret;
        }

        private static string ReadPhone(string fieldName = "Phone")
        {
            string ret = string.Empty;
            while (true)
            {
                Console.Write($"Enter {fieldName}: ");
                var phone = Console.ReadLine();
                if (phone != null
                    && Contact.CheckPhone(phone))
                {
                    ret = phone;
                    break;
                }
                else
                {
                    Console.WriteLine(Contact.GetInvalidPhoneMessage(fieldName));
                    if (!AskForContinuation())
                    {
                        break;
                    }
                }


            }
            return ret;
        }

        private static void SearchContact(PhoneBook phoneBook)
        {
            Console.Write("Enter first name, second name or phone number: ");
            var search = $"{Console.ReadLine()}";
            var contactsFinded = phoneBook.Find(search);
            if (contactsFinded.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Founded contacts");
                PhoneBook.ShowContacts(contactsFinded);
                Console.Read();
            }
            else
            {
                Console.WriteLine($"Contact not founded! ");
                Console.Read();
            }
        }

        private static void ExitProgram()
        {
            Console.WriteLine("Exiting the program...");
            Environment.Exit(0);
        }

        private static bool AskForContinuation()
        {
            Console.Write("Do you want to try again? Yes(Y)");
            string response = $"{Console.ReadLine()}";
            return response == "Y" ? true : false;
        }


    }
}
