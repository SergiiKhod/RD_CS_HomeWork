using System.Reflection;

namespace Homework_Reflection
{
    internal class Program
    {
        private static void Main()
        {
            var obj = new MyClass();

            var methodName = string.Empty;
            while (string.IsNullOrWhiteSpace(methodName))
            {
                Console.Clear();
                Console.Write("Enter the method name to invoke: ");
                methodName = Console.ReadLine();
            }

            var type = typeof(MyClass);
            var methodInfo = type.GetMethod(methodName);

            if (methodInfo != null)
            {
                try
                {
                    methodInfo.Invoke(obj, new object[] { "Hello World" });
                }
                catch (TargetParameterCountException ex)
                {
                    Console.WriteLine($"The method {methodName} does not accept the correct number of parameters. Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Error: The method {methodName} does not exist.");
            }
        }
    }

    public class MyClass
    {
#pragma warning disable CA1822
        // ReSharper disable once UnusedMember.Global
        public void Print(string message)
#pragma warning restore CA1822
        {
            Console.WriteLine(message);
        }
    }
}