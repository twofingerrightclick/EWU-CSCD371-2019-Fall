using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance
{
    public static class ExtensionActor
    {
        public static void Speak(this Actor actor, TextWriter writer)
        {
            if (actor is null || writer is null){
                throw new ArgumentNullException();
            }
            
            switch (actor) {
                case Penny penny:
                    penny.Speak(writer);
                    break;
                case Raj raj when !raj.WomenPresent:
                    raj.Speak(writer);
                    break;
                case Raj raj when raj.WomenPresent:
                    raj.SpeakWomen(writer);
                    break;
                case Sheldon sheldon:
                    sheldon.Speak(writer);
                    break;
                

            }

        }
    }
}
