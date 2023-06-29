namespace HomeWork_6
{
    public class Contact
    {
        private const string _allowedNameCharactersEN = "abcdefghijklmnopqrstuvwxyz";
        private const string _allowedNameCharactersUK = "абвгдеєжзиіїйклмнопрстуфхцчшщьюяґєїі";
        private const string _allowedNameSpecialCharacters = "-'` ";
        private const string _allowedPhoneCharacters = "0123456789";

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }

        public Contact()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;
            MobilePhone = string.Empty;
            Address = string.Empty;
        }
        public Contact(string nameFirst, string nameSecond, string mobile, string address)
        {
            FirstName = nameFirst;
            SecondName = nameSecond;
            MobilePhone = mobile;
            Address = address;
        }
        public string ContactToString()
        {
            string ret = $"{FirstName}\t\t{SecondName}";

            if (!string.IsNullOrWhiteSpace(MobilePhone))
                ret += $"\t\t{MobilePhone}";

            if (!string.IsNullOrWhiteSpace(Address))
                ret += $"\t\t{Address}";

            return ret;
        }

        private static string GetAllowedNameCharacters()
        {
            return _allowedNameCharactersEN + _allowedNameCharactersEN.ToUpper() + _allowedNameCharactersUK + _allowedNameCharactersUK.ToUpper() + _allowedNameSpecialCharacters;
        }
        private static string GetAllowedPhoneCharacters()
        {
            return _allowedPhoneCharacters;
        }
        private static bool CheckStringProperty(string property, string allowedCharacters)
        {
            bool ret = true;            

            for (int i = 0; i < property.Length; i++)
            {
                bool isCorrectCharacter = false;

                for (int j = 0; j < allowedCharacters.Length; j++)
                {
                    if (property[i] == allowedCharacters[j])
                    {
                        isCorrectCharacter = true;
                        break;
                    }
                }

                if (!isCorrectCharacter)
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }

        public static bool CheckName(string name)
        {            
            string allowedCharacters = GetAllowedNameCharacters();
            return CheckStringProperty(name, allowedCharacters);
        }
        public static string GetInvalidNameMessage(string fieldName = "Name")
        {
            return $"Only English and Ukrainian characters, hyphen, apostrophe and space are allowed for '{fieldName}'.";
        }

        public static bool CheckPhone(string phone)
        {
            string allowedCharacters = GetAllowedPhoneCharacters();
            return CheckStringProperty(phone, allowedCharacters);
        }        
        public static string GetInvalidPhoneMessage(string fieldName = "Phone")
        {
            return $"Only numbers are allowed for '{fieldName}'";
        }
    }
}

