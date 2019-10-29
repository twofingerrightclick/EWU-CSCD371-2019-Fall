using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {


            IConfig environmentConfiger = new EnvironmentConfig();

            List<String> configSettings = new List<String>
            {
                "USERPROFILE=userprofile",
                "TEMP=temp!"
            };
            char[] splitOn = { '=' };

            

           
            Console.WriteLine("Current Enviroment Config Values: ");

            IterateThroughConfigValues(configSettings, splitOn, environmentConfiger);

            
            
            
            IConfig mockConfiger = new MockConfig();

            Console.WriteLine("Setting MockConfig Values: ");

            foreach (string setting in configSettings)
            {
                string[] parsedEntry = setting.Split(splitOn, StringSplitOptions.RemoveEmptyEntries);
                mockConfiger.SetConfigValue(parsedEntry[0], parsedEntry[1]);
                Console.Write("mockconfig set with: ");
                Console.Write($"{parsedEntry[0]}={parsedEntry[1]}");
                Console.WriteLine();

            }
            Console.WriteLine();

            IterateThroughConfigValues(configSettings, splitOn, mockConfiger);



      

        }

        public static void IterateThroughConfigValues(List <string> configValues, char[] splitOnCharactersForConfigValues, IConfig iconfig)
        {
            Console.WriteLine($"Getting {iconfig.ToString()} Values: ");
            foreach (string setting in configValues)
            {
                string[] parsedEntry = setting.Split(splitOnCharactersForConfigValues, StringSplitOptions.RemoveEmptyEntries);
                iconfig.GetConfigValue(parsedEntry[0], out string? value);
                Console.WriteLine($"{parsedEntry[0]}={value}");
                Console.WriteLine();

            }
        }
    }


}
