using System;
using System.Collections.Generic;
using System.IO;

namespace Logger
{
    public abstract class BaseLogger
    {
        public string ClassName
        {
            set;
            get;
            
        }
        public abstract void Log(LogLevel logLevel, string message);

    }

   

}

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        public string FilePath
        {
            private set;
            get;
        }
        public FileLogger(string filePath)
        {
            FilePath = filePath;

        }
        public override void Log(LogLevel logLevel, string message)
        {
            if (FilePath == null) {
                throw new System.ArgumentNullException("File Path not specified/null");
            }

            List<string> entry = new List<string>
            {
                "Log Entry:",
                DateTime.Now.ToString(),
                ClassName,
                "Log Level: "+logLevel.ToString(),
                message,
                "\r\n"
            };
            File.AppendAllLines(FilePath, entry);
            


        }

    }
}