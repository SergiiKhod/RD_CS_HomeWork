using Bogus;

namespace Homework_LINQ
{
    internal class DataGenerator
    {
        public static List<Employee> GetEmployees(int count)
        {
            Randomizer.Seed = new Random(8675309);
            var faker = new Faker<Employee>()
                .RuleFor(e => e.FirstName, f => f.Person.FirstName)
                .RuleFor(e => e.LastName, f => f.Person.LastName)
                .RuleFor(e => e.BirthDate, f => f.Person.DateOfBirth)
                .RuleFor(e => e.Gender, f => f.PickRandom<Gender>())
                .RuleFor(e => e.IsMarried, f => f.Random.Bool())
                .RuleFor(e => e.IsStudent, (f, e) => e.BirthDate <= DateTime.Now.AddYears(-35) && f.Random.Bool())
                .RuleFor(e => e.IsPensioner,
                    (f, e) => (e.BirthDate > DateTime.Now.AddYears(-50) && f.Random.Bool()) ||
                              e.BirthDate > DateTime.Now.AddYears(-65))
                .RuleFor(e => e.Email, f => f.Person.Email)
                .RuleFor(e => e.HireDate, f => f.Date.Between(new DateTime(2002, 1, 1), DateTime.Now))
                .RuleFor(e => e.TerminationDate,
                    (f, e) => f.Random.Bool(0.2f) ? null : f.Date.Between(e.HireDate??DateTime.Now, DateTime.Now));

            return faker.Generate(count);
        }

    }
}
