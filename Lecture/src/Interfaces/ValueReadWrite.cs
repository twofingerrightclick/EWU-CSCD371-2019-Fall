using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class ValueReadWrite : IValue
    {
        public object Fetch()
        {
            throw new NotImplementedException();
        }

        public void Save(object myValue)
        {
            throw new NotImplementedException();
        }

        //public void Save(object myValue)
        //{
        //    Console.WriteLine("Saved");
        //}
    }
}
