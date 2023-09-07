namespace Homework_LogFilesAnalyzer
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter the directory to generate the log file: ");
            var path = string.Empty;
            while (string.IsNullOrWhiteSpace(path))
            {
                Console.Clear();
                Console.Write("Enter the directory to generate the log file: ");
                path = Console.ReadLine();
            }
            try
            {
                Console.WriteLine("LogFile is generating ... ");
                var logFile = DataGenerator.GenerateLogFile(path, DateTime.Now.AddDays(-10), 100000);
                Console.Clear();
                var logAnalyzer = new LogFileAnalyzer(logFile);
                Console.WriteLine("LogFile is analyzing ... ");
                logAnalyzer.AnalyzeFile();
                Console.Clear();
                var report = logAnalyzer.GenerateReport();
                Console.WriteLine(report);
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }

            Console.ReadKey();
        }
    }
}