using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, string? value)
        {
            throw new NotImplementedException();
        }

        public bool SetConfigValue(string name, string? value)
        {
            CheckValidInput(name, value);




            return true;
        }

        private void CheckValidInput(string name, string? value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Variable canme cannot be null");
            }

            if (name.Contains("="))
            {
                throw new ArgumentException("Variable name and Value cannot contain \'=\'");
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
                if (value.Contains(""))
                {
                    throw new ArgumentException("Variable name and Value cannot contain \'=\'");
                }
            }
        }
    }
}
