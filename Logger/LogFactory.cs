namespace Logger
{
    public class LogFactory
    {   
        private string FilePath
        {
            set;
            get;
        }
        public BaseLogger CreateLogger(string className)
        {

            if (FilePath != null)
            {
                FileLogger test = new FileLogger(FilePath) { ClassName = className };
                return test;
            }

            else
            {
                return null;
            }
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
    }
}
