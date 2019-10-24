using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class Entity : IEntity
    {
        public int Id { get; set; }

        public string SayHello()
        {
            throw new NotImplementedException();
        }
    }
}
