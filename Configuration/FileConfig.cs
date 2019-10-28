using System;
using System.Collections.Generic;
using System.IO;

namespace Configuration
{
    public class FileConfig : IConfig
    {

        public string FilePath { get; set; } = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "config.settings";
        public bool GetConfigValue(string name, out string? value)
        {
            value = null;
            int lineCount;
            bool entryFound = SearchAndRetreiveValue(name, ref value, out lineCount);

            return entryFound;
        }

        private bool SearchAndRetreiveValue(string name, ref string value, out int lineIndex)
        {
            bool entryFound = false;
            lineIndex = 0;

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null && !entryFound)
                {

                    string[] currentEntry = ParseConfigEntry(currentLine);

                    Console.WriteLine("line: " + lineIndex + " - " + currentEntry[0] + " value: " + currentEntry[1]);

                    if (string.Equals(currentEntry[0], name))
                    {
                        entryFound = true;
                        value = currentEntry[1];

                    }
                    else
                    {
                        lineIndex++;
                    }

                }


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

            char[] splitOn = { '<', '>', '=' };

            string[] parsedEntry = configEntry.Split(splitOn, StringSplitOptions.RemoveEmptyEntries);

            return parsedEntry;

        }


        //for small files
        public void editConfigEntry(string newEntry, int lineToEdit)
        {
            string[] arrLine = File.ReadAllLines(FilePath);
            arrLine[lineToEdit] = newEntry;
            File.WriteAllLines(FilePath, arrLine);

        }

        public void removeConfigEntry(int lineToEdit)
        {
            List<string> arrLine = new List<string>(File.ReadAllLines(FilePath));
            arrLine.RemoveAt(lineToEdit);
            File.WriteAllLines(FilePath, arrLine);

        }
        //If config variable doesn't exists, adds a Config Variable and Value. If it exists, changes it to new value, or removes it.
        public bool SetConfigValue(string name, string? value)
        {

            

            CheckValidInput(name, value);

            int lineCount = 0;
            bool entryFound = false;
            string? originalValue = value;

            if (File.Exists(FilePath))
            {
              
                entryFound = SearchAndRetreiveValue(name, ref originalValue, out lineCount);
            }

            if (value == null)
            {
                removeConfigEntry(lineCount);
            }

            else
            {

                string newEntry = string.Format("<{0}={1}>", name, value);

                if (entryFound)
                {
                    editConfigEntry(newEntry, lineCount);
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(FilePath, append: true))
                    {
                        writer.WriteLine(newEntry);

                    }
                }
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
