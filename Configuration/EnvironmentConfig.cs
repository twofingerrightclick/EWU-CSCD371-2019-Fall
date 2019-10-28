using System;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {

        public bool GetConfigValue(string name, string? value)
        {

            value = Environment.GetEnvironmentVariable(name);
            return (value != null);

        }

        public bool SetConfigValue(string name, string? value)
        {
            Environment.SetEnvironmentVariable(name, value);

            return true;
        }

        //cheap method to get actual value
        public string GetConfigValue(string name, ref string? value)
        {
            value = Environment.GetEnvironmentVariable(name);

            return value;


        }

    }
}
