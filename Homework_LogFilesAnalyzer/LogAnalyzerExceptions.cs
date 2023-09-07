namespace Homework_LogFilesAnalyzer
{
    public class LogFileAnalyzerException : Exception
    {
        public LogFileAnalyzerException(Exception innerException) : base("An error occurred while processing the file.", innerException)
        {
            Handle(innerException);
        }

        private void Handle(Exception e)
        {
            switch (e)
            {
                case FileNotFoundException:
                    Console.WriteLine("File not found");
                    break;
                case UnauthorizedAccessException:
                    Console.WriteLine("The file cannot be accessed.");
                    break;
                case LogLineAnalyzerException exception:
                    {
                        Console.WriteLine($"Error during processing of line {exception.LineNumber}: {exception.Message}");
                        break;
                    }
                default:
                    Console.WriteLine($"Unknown error: {e.Message}");
                    break;
            }
        }
    }


    public class LogLineAnalyzerException : IOException
    {
        public int LineNumber { get; }

        public LogLineAnalyzerException(int lineNumber, string message)
            : base(message)
        {
            LineNumber = lineNumber;
        }
    }
}
