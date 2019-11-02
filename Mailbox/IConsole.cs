using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox
{
    public interface IConsole
    {
        public void WriteLine(string output);
        public string ReadLine();
    }

    public class RealConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }

    public class MockConsole : IConsole
    {
        public List<string> Input { get; set; } = new List<string>();
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Input.Add(output);
        }
    }
}
