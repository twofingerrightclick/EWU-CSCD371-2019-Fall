using System.Collections.Generic;

namespace Configuration
{
    class MockConfig : IConfig
    {
        private Dictionary<string, string> enviromentConfigPairs = new Dictionary<string, string>();
        public bool GetConfigValue(string name, out string? value)
        {
            value = null;
            IConfigUtilities.CheckValidConfigInput(name, value);
            value = enviromentConfigPairs.GetValueOrDefault(name);
            if (value == null)
            {
                return false;
            }
            else
                return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            IConfigUtilities.CheckValidConfigInput(name, value);
            if (value == null)
            {
                enviromentConfigPairs.Remove(name);
                return true;
            }
            else
                enviromentConfigPairs.Add(name, value);


            return true;
        }
    }
}
