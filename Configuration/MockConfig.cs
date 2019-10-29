using System.Collections.Generic;

namespace Configuration
{
    public class MockConfig : IConfig
    {
        private Dictionary<string, string> enviromentConfigPairs = new Dictionary<string, string>();

        public string[,] _DefaultAvailableConfigSettings { get; } = new string[,] { { "HOME", "Cupertino" }, { "USERPROFILE", "SteveJobs" }, { "OS", "macOS" } };

        public MockConfig(bool populateWithDefaultValues)
        {
            if (populateWithDefaultValues)
            {
                for (int i = 0; i < _DefaultAvailableConfigSettings.GetLength(0); i++)
                {
                    SetConfigValue(_DefaultAvailableConfigSettings[i,0], _DefaultAvailableConfigSettings[i,1]);
                }
            }

        }

        public MockConfig(){}
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
            else if (enviromentConfigPairs.ContainsKey(name))
            {
                enviromentConfigPairs.Remove(name);
            }


            enviromentConfigPairs.Add(name, value);


            return true;
        }
    }
}
