using System;
using Common;
using Common.Interface;

namespace Client.Interface
{
    /// <summary>
    /// Holds the common functionality for client.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public interface IClient
    {
        /// <summary>
        /// Connects this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        void Connect();
        
        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        void Disconnect();

        /// <summary>
        /// Sends this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Response Send(Request request);
    }
}
