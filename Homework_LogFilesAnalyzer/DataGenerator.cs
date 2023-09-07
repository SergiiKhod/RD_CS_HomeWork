using Bogus;

namespace Homework_LogFilesAnalyzer
{

    public static class DataGenerator
    {
        private sealed class LogLineFaker : Faker<LogLine>
        {
            private readonly Random _random = new();
            public LogLineFaker(DateTime dateStart)
            {
                var dateCurrent = dateStart;
                RuleFor(ll => ll.EventDateTime, _ =>
                {
                    var milliseconds = _random.Next(100, 10001);
                    dateCurrent = dateCurrent.AddMilliseconds(milliseconds);
                    return dateCurrent;
                });
                RuleFor(ll => ll.EventType, f => f.PickRandom<EventType>());
                RuleFor(ll => ll.Message, f => f.Lorem.Sentence());
            }
        }
        public static string GenerateLogFile(string path, DateTime dateStart, int countLines)
        {
            var logFileName = Path.Combine(path, GenerateLogFileRandomName());
            var logFaker = new LogLineFaker(dateStart);
            for (var i = 0; i < countLines; i++)
            {
                var logEntry = logFaker.Generate();
                using var fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write);
                using var sw = new StreamWriter(fs);
                sw.WriteLine($"[{logEntry.EventDateTime:O}]{LogLine.SeparatorInfo}[{logEntry.EventType}]{LogLine.SeparatorInfo}{logEntry.Message}");
            }
            return logFileName;
        }

        private static string GenerateLogFileRandomName()
        {
            return $"log_{Guid.NewGuid()}.txt";
        }
    }
}
