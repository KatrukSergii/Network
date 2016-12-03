using System;
using Common.Interface;

namespace Common
{
    /// <summary>
    /// Defines the fake string logger.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class NullStringLogger : ILogger<string>
    {
        /// <summary>
        /// Logs the specified log item.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <param name="logItem">The log item.</param>
        public void Log(string logItem)
        {
            //
            // Do nothing.
            //
        }

        private NullStringLogger()
        {
        }

        private static ILogger<string> instance;

        public static ILogger<string> Instance
        {
            get
            {
                return instance ?? (instance = new NullStringLogger());
            }
        }
    }
}
