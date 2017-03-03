using System;

namespace Server
{
    /// <summary>
    /// Contains the configuration options for server.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class ServerOptions
    {
        /// <summary>
        /// Gets or sets the port number used for listening.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <value>
        /// The port number used for listening.
        /// </value>
        public int PortNumber
        {
            get;
            set;
        }
    }
}
