using System;
using System.IO;

namespace Configuration
{
    public class FileConfig : IConfig
    {

        public string FilePath { get; set; } = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "config.settings";
        public bool GetConfigValue(string name, string? value)
        {
            int lineCount = 0;
            bool entryFound=false;
            using (StreamReader reader = new StreamReader(FilePath))
            {   
                
                while (!reader.EndOfStream)
                {
                    string currentEntry = reader.ReadLine();
                    string currentEntryName = ParseConfigEntry(currentEntry)[0];
                    if (currentEntryName==name){
                        entryFound=true;
                        break;
                    }
                    lineCount++;

                }

                //Console.WriteLine(reader.ReadToEnd());

            }
            
            return entryFound;
        }

#pragma warning disable CA1822 // Mark members as static
        public string[] ParseConfigEntry(string configEntry)
#pragma warning restore CA1822 // Mark members as static
        {
            if (string.IsNullOrEmpty(configEntry))
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("entry was null", nameof(configEntry));
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            char[] splitOn = { '<', '>','=' };
            
            string[] parsedEntry = configEntry.Split(splitOn, StringSplitOptions.RemoveEmptyEntries);

            return parsedEntry;

        }


        //for small files
        public void editConfigEntry(string name, string newValue, int lineToEdit)
        {
            string[] arrLine = File.ReadAllLines(FilePath);
            arrLine[lineToEdit - 1] = string.Format("<{0}={1}>", name, newValue);
            File.WriteAllLines(FilePath, arrLine);

        }

        public bool SetConfigValue(string name, string? value)
        {
            Console.WriteLine(FilePath);

            CheckValidInput(name, value);



            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {

                if (value == null)
                {
                    value = "not set";
                }
                writer.WriteLine(string.Format("<{0}={1}>", name, value));

            }


            return true;
        }

        private void CheckValidInput(string name, string? value)
        {
            if (name == null)
            {

                throw new ArgumentNullException("Environment Variable name was null");

            }

            if (name.Contains("="))
            {
                throw new ArgumentException("Environment Variable name cannot contain \'=\'");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Environment Variable Name cannot be empty or Null");
            }

            if (name.Contains(" "))
            {
                throw new ArgumentException("Environment Variable name cannot have spaces");
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
                    throw new ArgumentException("value cannot be empty");
                }

            }
        }
    }
}
