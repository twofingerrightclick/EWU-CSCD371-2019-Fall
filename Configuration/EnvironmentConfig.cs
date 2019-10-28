using System;


namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {

        public bool GetConfigValue(string name, out string? value)
        {
            value = null;
            IConfigUtilities.CheckValidConfigInput(name, value);

            value = Environment.GetEnvironmentVariable(name);
            
            return (value != null);

        }

        public bool SetConfigValue(string name, string? value)
        {
            IConfigUtilities.CheckValidConfigInput(name, value);

            Environment.SetEnvironmentVariable(name, value);

            return true;
        }



    }
}
