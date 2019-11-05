//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Mailbox
//{
//    public class DataLoader : IDisposable
//    {
//        public Stream StreamSource { get; }
//        private bool disposed = false;

//        public DataLoader(Stream source)
//        {
//            StreamSource = source ?? throw new ArgumentNullException(nameof(source), "source was null");

//        }

//        public void Dispose()
//        {
//            if (!disposed)
//            {
//                StreamSource.Dispose();
//            }

//            disposed = true;
//            //need to read more on the following line
//            GC.SuppressFinalize(this);
//        }

//        public void Dispose(bool dispose)
//        {
//            if (dispose)
//            {
//                Dispose();
//            }
//            //need to read more on the following line
//            GC.SuppressFinalize(this);
//        }

//        ~DataLoader()
//        {
//            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
//            Dispose(false);
//        }

//        public List<Mailbox> Load()
//        {
//            StreamSource.Position = 0;
//            using var sr = new StreamReader(StreamSource);
//            List<Mailbox> MailBoxesFromJson;
//            try
//            {
//                MailBoxesFromJson = JsonConvert.DeserializeObject<List<Mailbox>>(sr.ReadToEnd());
//            }
//            catch (JsonReaderException)
//            {
//                return null!;
//            }

//            return MailBoxesFromJson;



//        }

//        public void Save(List<Mailbox> mailboxes)
//        {
//            StreamSource.Position = 0;

//            using var sw = new StreamWriter(StreamSource, leaveOpen: true);

//            string jsonMailBoxes = JsonConvert.SerializeObject(mailboxes);

//            sw.Write(jsonMailBoxes);


//        }
//    }
//}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    
    public class DataLoader : IDisposable
    {
        public Stream Source { get; }

        public DataLoader(Stream source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            Source.Position = 0;

            try
            {
                using (StreamReader sr = new StreamReader(Source))
                {
                    string? jsonLine;
                    while ((jsonLine = sr.ReadLine()) != null)
                    {
                        Mailbox mailbox = JsonConvert.DeserializeObject<Mailbox>(jsonLine);
                        mailboxes.Add(mailbox);
                    }
                }
            }
            catch (JsonReaderException)
            {
                return null;
            }

            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Position = 0;

            using (StreamWriter sw = new StreamWriter(Source, leaveOpen: true))
            {
                foreach (Mailbox mailbox in mailboxes)
                    sw.WriteLine(JsonConvert.SerializeObject(mailbox));
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Source.Dispose();
                }

                disposedValue = true;
            }
        }

       
        ~DataLoader()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

     
        public void Dispose()
        {

            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
