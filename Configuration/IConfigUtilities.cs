using System;



namespace Configuration
{
   
    public static class IConfigUtilities
    {

       public static void CheckValidConfigInput(string name, string? value)
        {
            if (name == null)
            {

                throw new ArgumentNullException("Environment Variable name was null");
                //is this only for runtime someone said?

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
