
using System.Diagnostics;
using static Homework_LINQ.Employee;

namespace Homework_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var startTime = DateTime.Now;
            var timer = new Stopwatch();
            timer.Start();
           Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} Start app");
           Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} Start generated data");
           var employees = DataGenerator.GetEmployees(100000);
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} End generated data");
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} Start get Male");
            var males = GetMale(employees);
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} End get Male");
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} Start get Pensioners");
            var pensioners = GetPensioner(males);
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} End get Pensioners");
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} Start calculated avg pensioner experience");
            var avgExperience = GetAvgExperience(pensioners);
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} End calculated avg pensioner experience");
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} Start get top 3 experienced pensioner");
            var bestOfTheBest = GetTopExperiencedValidEmployees(pensioners,3);
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} End get top 3 experienced pensioner");
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} Start calculate count students");
            var countOfStudents = GetStudents(employees).Count;
            Console.WriteLine($"{startTime.AddMilliseconds(timer.ElapsedMilliseconds)} End calculate count students");
            Console.WriteLine();
            Console.WriteLine("RESULT:");
            Console.WriteLine();
            Console.WriteLine($"Avg experience of male pensioners - {avgExperience} years");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Count of Student - {countOfStudents}");
            Console.WriteLine();
            Console.WriteLine("TOP 3 male Pensioners:");
            foreach (var best in bestOfTheBest)
            {
                Console.WriteLine(best.ToString());
            }

            Console.Read();

        }
    }
}