using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class User : ApplicationUser, IEntity
    { 

        public string SayHello()
        {
            throw new NotImplementedException();
        }
    }
}
