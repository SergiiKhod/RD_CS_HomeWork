namespace HomeWork_6
{
    public class PhoneBook
    {
        private List<Contact> _listContacts;
        public PhoneBook()
        {
            _listContacts = new List<Contact>();
        }
        public void Add(Contact contact)
        {
            _listContacts.Add(contact);
        }
        public void AddRange(List<Contact> contacts)
        {
            _listContacts.AddRange(contacts);
        }


        public List<Contact> GetContacts() { return _listContacts; }
        public List<Contact> Find(string search)
        {
            List<Contact> ret = new List<Contact>();
            ret.AddRange(FindByName(search));
            ret.AddRange(FindByPhone(search));
            return ret;
        }

        public List<Contact> FindByName(string searchName)
        {
            var ret = new List<Contact>();
            foreach (var contact in _listContacts)
            {
                if (contact.SecondName == searchName
                    || contact.FirstName == searchName)
                {
                    ret.Add(contact);
                }
            }
            return ret;
        }

        public List<Contact> FindByPhone(string searchPhone)
        {
            var ret = new List<Contact>();
            foreach (var contact in _listContacts)
            {
                if (contact.MobilePhone == searchPhone)
                {
                    ret.Add(contact);
                }
            }
            return ret;
        }
        public static void ShowContacts(List<Contact> listContacts)
        {
            Console.WriteLine("_______________________________________________________________________________");
            foreach (var contact in listContacts)
            {
                Console.WriteLine(contact.ContactToString());
            }
            Console.WriteLine("_______________________________________________________________________________");
        }

    }
}