using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program 
    {
        static void Main()
        {
            Console.WriteLine("Current Enviroment Config Values: ");

            IConfig envConfig = new EnvironmentConfig();

            List<String> configSettings = new List<String>
            {
                "USERPROFILE",
                "PATH",
                "TEMP",
                "HOME"
            };

            foreach (string setting in configSettings)
            {
                envConfig.GetConfigValue(setting, out string? value);
                Console.WriteLine($"{setting}={value}");
                Console.WriteLine();

            }
        }
    }
}
