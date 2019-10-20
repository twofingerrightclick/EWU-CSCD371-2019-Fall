using System;
using System.IO;

namespace Inheritance
{
    public class Penny : Actor 
    {
       // private string name = "Penny";

        public string Name
        {
            get { return "Penny"; }
            
        }

        
        public void Speak(TextWriter writer)
        {
            writer.WriteLine(Name + " says \"Who do we love?\"");
        }
    }


    public class Raj : Actor
    {
        // private string name = "Penny";

        public string Name
        {
            get { return "Raj"; }

        }


        private bool womenPresent= false;

        public bool WomenPresent
        {
            get { return womenPresent; }
            set { womenPresent = value; }
        }


        public void Speak(TextWriter writer)
        {
            writer.WriteLine(Name + " says \"I'm sorry I'm so late. I was on the phone with my mother.\"");
        }

        public void SpeakWomen(TextWriter writer)
        {
            writer.WriteLine(Name + " mumbles");
        }
    }

    public class Sheldon : Actor
    {
        
        public string Name
        {
            get { return "Sheldon"; }

        }

        public void Speak(TextWriter writer)
        {
            writer.WriteLine(Name+ " says \"I'll be back before this banana hits the ground.\"");
        }
    }
}