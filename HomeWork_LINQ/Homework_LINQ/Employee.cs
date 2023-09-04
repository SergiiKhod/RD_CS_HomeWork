namespace Homework_LINQ
{
    public enum Gender
    {
        Male=0,
        Female=1
    }
    public class Employee
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool IsMarried { get; set; }
        public bool IsPensioner { get; set; }
        public bool IsStudent { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        public void HireEmployee(DateTime date)
        {
            HireDate = date;
        }

        public void TerminateEmployee(DateTime date)
        {
            TerminationDate = date;
        }

        public int CalculateExperience()
        {
            var timespan = (TerminationDate ?? DateTime.Now) - (HireDate??DateTime.Now);
            return (int)(timespan.TotalDays / 365);
        }

        //public Employee(string email, string nameFirst, string nameLast, DateTime dateBirth, Gender gender, bool isMarried, bool isPensioner, bool isStudent)
        //{
        //    Email = email;
        //    FirstName = nameFirst;
        //    LastName=nameLast;
        //    BirthDate = dateBirth;
        //    Gender = gender;
        //    IsMarried = isMarried;
        //    IsPensioner = isPensioner;
        //    IsStudent = isStudent;
        //}

        public override string ToString()
        {
            return $"{FirstName} {LastName}\t\t{HireDate?.ToString("dd.MM.yyyy")} - {TerminationDate?.ToString("dd.MM.yyyy")}";
        }
    
        public static List<Employee> GetStudents(IEnumerable<Employee> employees)
        {
            return employees.Where(e => e.IsStudent).ToList();
        }

        public static List<Employee> GetPensioner(IEnumerable<Employee> employees)
        {
            return employees.Where(e => e.IsPensioner).ToList();
        }

        public static List<Employee> GetMale(IEnumerable<Employee> employees)
        {
            return employees.Where(e => e.Gender==Gender.Male).ToList();
        }

        public static double GetAvgExperience(IEnumerable<Employee> employees)
        {
            return Math.Round(employees.Average(e => e.CalculateExperience()),2);
        }

        public static List<Employee> GetTopExperiencedValidEmployees(IEnumerable<Employee> employees, int countOfTop)
        {
           return  employees.Where(e => e.TerminationDate != null).OrderByDescending(e => e.CalculateExperience())
                .Take(countOfTop).ToList();
        }

    }
}

