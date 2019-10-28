using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {

        public string FilePath { get; set; } = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "config.settings";
        public bool GetConfigValue(string name, string? value)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (!reader.EndOfStream) {

                    reader.ReadLine();

                }
                
                Console.WriteLine(reader.ReadToEnd());

            }
            //throw new NotImplementedException();
            return true;
        }

        public string [] ParseConfigEntry(string configEntry)
        {
            string[] splitOn = { "<",">"};
            int count = 2;
            string[] parsedEntry = configEntry.Split(splitOn, count, StringSplitOptions.RemoveEmptyEntries);
           
            //string currentEntryName = currentEntry[0];
            Console.WriteLine(parsedEntry);

            return parsedEntry;
            
        }

        public bool SetConfigValue(string name, string? value)
        {
            Console.WriteLine(FilePath);

            CheckValidInput(name, value);

            

            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {

                if (value == null) { 
                    value="not set";
                }
                writer.WriteLine(string.Format("<{0}={1}>",name,value));
               
            }


            return true;
        }

        private void CheckValidInput(string name, string? value)
        {
            

            if (name.Contains("="))
            {
                throw new ArgumentException("Variable name cannot contain \'=\'");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty or Null");
            }

            if (name.Contains(" "))
            {
                throw new ArgumentException("Variable name cannot have spaces");
            }
            if (value != null)
            {
                if (value.Contains(" "))
                {
                    throw new ArgumentException("Value cannot have spaces");
                }
                if (value.Contains("="))
                {
                    throw new ArgumentException("Value cannot have \'=\'");
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

            }
        }
    }
}
