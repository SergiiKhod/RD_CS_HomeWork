using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Homework_LogFilesAnalyzer
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum EventType
    {
        DEBUG,
        INFO,
        WARNING,
        ERROR
    }
    public class LogLine
    {
        public const string SeparatorInfo = "\t";
        public DateTime EventDateTime { get; set; }
        public EventType EventType { get; set; }
        public string? Message { get; set; }

        public static LogLine Parse(string logLine)
        {
            var regex = new Regex(
                $@"\[(?<date>\d{{4}}-\d{{2}}-\d{{2}}T\d{{2}}:\d{{2}}:\d{{2}}\.\d+([+-]\d{{2}}:\d{{2}})?)]{LogLine.SeparatorInfo}\[(?<eventType>\w+)\]{LogLine.SeparatorInfo}(?<message>.*)");
            var match = regex.Match(logLine);

            if (!match.Success)
                throw new FormatException("Log line is not in the expected format.");

            var date = DateTime.Parse(match.Groups["date"].Value);
            if (!Enum.TryParse(match.Groups["eventType"].Value, out EventType eventType))
                throw new FormatException("Invalid event type in log line.");

            var message = match.Groups["message"].Value;

            return new LogLine
            {
                EventDateTime = date,
                EventType = eventType,
                Message = message
            };
        }
    }
}

