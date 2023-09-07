namespace Homework_LogFilesAnalyzer
{ public class LogFileAnalyzer
    {

        public string LogFilePath { get; }
        public Dictionary<string, int> LogLevels { get; }

        public Dictionary<int,int> HourFrequencies { get; }
        public DateTime PeriodStart { get; private set; }
        public DateTime PeriodEnd { get; private set; }

        public string FileSize { get; private set; }

        public DateTime MostHourFrequent { get; private set; }


        public LogFileAnalyzer(string path)
        {
            LogFilePath = path;
            LogLevels = new Dictionary<string, int>();
            HourFrequencies= new Dictionary<int,int>();
            FileSize = string.Empty;
            PeriodEnd= DateTime.MinValue;
            PeriodStart =   DateTime.MinValue;
            MostHourFrequent= DateTime.MinValue;

        }

        public void AnalyzeFile()
        {
            try
            {
                var lineNumber = 0;

                foreach (var line in File.ReadLines(LogFilePath))
                {
                    lineNumber++;
                    try
                    {
                        AnalyzeLine(line);
                    }
                    catch (Exception e)
                    {
                        throw new LogLineAnalyzerException(lineNumber, $"Error processing line {lineNumber}: {e.Message}");
                    }
                }
                
                PeriodStart = GetMinDateTime();
                PeriodEnd = GetMaxDateTime();
                FileSize = GetFileSize();
                MostHourFrequent = GetMostFrequentEventHour();
            }
            catch (Exception e)
            {
             throw new LogFileAnalyzerException(e);
            }

        }

        private void AnalyzeLine(string line)
        {
            var logLine = LogLine.Parse(line);
            UpdateEvents(logLine);
            UpdateFrequencies(logLine);
        }

        private void UpdateFrequencies(LogLine logLine)
        {
            var hour = logLine.EventDateTime.Hour;
            HourFrequencies.TryAdd(hour, 0);
            HourFrequencies[hour]++;
        }

        private void UpdateEvents(LogLine logLine)
        {
            if (LogLevels.ContainsKey(logLine.EventType.ToString()))
            {
                LogLevels[logLine.EventType.ToString()]++;
            }
            else
            {
                LogLevels.Add(logLine.EventType.ToString(), 1);
            }
        }

        private DateTime GetMinDateTime()
        {
           return LogLine.Parse(File.ReadLines(LogFilePath).First()).EventDateTime;
        }

        private DateTime GetMaxDateTime()
        {
            return LogLine.Parse(File.ReadLines(LogFilePath).Last()).EventDateTime;
        }

        private string GetFileSize()
        {
            var fileInfo = new FileInfo(LogFilePath);
            double bytes = fileInfo.Length;

            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            var order = 0;

            while (bytes >= 1024 && order < sizes.Length - 1)
            {
                order++;
                bytes /= 1024;
            }

            return $"{Math.Round(bytes, 2)} {sizes[order]}";
        }

        public DateTime GetMostFrequentEventHour()
        {
            var mostFrequentHour = HourFrequencies.MaxBy(pair => pair.Value).Key;
            return new DateTime(1, 1, 1, mostFrequentHour, 0, 0); 
        }


        public string GenerateReport()
        {
            var report = $"Log File Analysis Report for {Path.GetFileName(LogFilePath)}";
            report += $"{Environment.NewLine}Size of file: {FileSize}";
            report += $"{Environment.NewLine}Total lines: {LogLevels.Sum(row=>row.Value):##,###}";
            report += $"{Environment.NewLine}Period: {PeriodStart:F} - {PeriodEnd:F}";
            report += $"{Environment.NewLine}";
            report=LogLevels.Aggregate(report, (current, logLevel) => current + $"{Environment.NewLine}{logLevel.Key}: {logLevel.Value:##,### 'entries'}");
            report += $"{Environment.NewLine}";
            report += $"{Environment.NewLine}Most frequent event hour: {MostHourFrequent:t}-{MostHourFrequent.AddHours(1):t}";
            return report;
        }
    }

}
