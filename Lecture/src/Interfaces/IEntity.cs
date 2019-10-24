using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }

        private static string _Message = "";

        public static void SetMessageValue(string value) => _Message = value;

        protected string Save(object value) { return _Message; }

        string SayHello() { return "Hello World"; }
    }
}
