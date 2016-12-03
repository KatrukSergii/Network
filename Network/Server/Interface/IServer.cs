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

        event EventHandler<Request> OnRequestRecieved;
    }
}
