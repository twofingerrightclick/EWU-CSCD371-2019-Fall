using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger t, string message, params object [] args)
        {
            if (t==null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            t.Log(LogLevel.Error, String.Format("{0} {1}", message, LogLevel.Error));
        }

        public static void Warning(this BaseLogger t, string message, params object[] args)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            t.Log(LogLevel.Error, String.Format("{0} {1}", message, LogLevel.Warning));
        }

        public static void Information(this BaseLogger t, string message, params object [] args)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            t.Log(LogLevel.Error, String.Format("{0} {1}", message, LogLevel.Information));
        }

        public static void Debug(this BaseLogger t, string message, params object [] args)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            t.Log(LogLevel.Error, String.Format("{0} {1}", message, LogLevel.Debug));
        }
    }
}
