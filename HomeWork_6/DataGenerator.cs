namespace HomeWork_6
{
    public static class DataGenerator
    {
        public static List<Contact> GenerateContact(int count)
        {
            var ret = new List<Contact>();
            Random rand = new Random();

            string[] listSecondName = { "Shevchenko", "Bilous", "Poltavec", "Zaporozhec", "Kovalenko" };
            string[] listFirstName = { "Ivan", "Petro", "Maria", "Alex", "Ann" };

            for (int i = 0; i < count; i++)
            {
                var contact = new Contact();
                contact.SecondName = listSecondName[rand.Next(listSecondName.Length)];
                contact.FirstName = listFirstName[rand.Next(listFirstName.Length)];
                contact.MobilePhone = GenerateRandomPhone();
                contact.Address = GenerateRandomAddress();

                ret.Add(contact);
            }
            return ret;
        }

        private static string GenerateRandomPhone()
        {
            Random rand = new Random();
            string phone = "380";

            for (int i = 0; i < 9; i++)
            {
                phone += rand.Next(0, 10);
            }

            return phone;
        }

        private static string GenerateRandomAddress()
        {
            Random rand = new Random();

            string[] listStreets = { "Main", "Central", "Sunshine", "White", "Black" };
            string[] listCities = {  "Lviv", "Kharkiv", "Odesa", "Dnipro" };

            string randomStreet = listStreets[rand.Next(listStreets.Length)];
            string randomCity = listCities[rand.Next(listCities.Length)];
            int bld = rand.Next(1, 100);

            return $"st. {randomStreet}, bld. {bld}, {randomCity}";
        }
    }
}
