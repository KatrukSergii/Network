using System;
using Common;

namespace Server.Interface
{
    /// <summary>
    /// Defines the common logic for server.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public interface IServer
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        void Start();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        void Stop();

        /// <summary>
        /// Occurs when received.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        event EventHandler<Request> OnRequestReceived;

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <value>
        /// The options.
        /// </value>
        ServerOptions Options
        {
            get;
        }
    }
}
