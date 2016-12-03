using System;
using Client.Interface;
using Common;
using Common.Interface;

namespace Client.TCP
{
    /// <summary>
    /// Defines logic for the client with using TCP.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    class Client : IClient
    {
        /// <summary>
        /// Connects this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Connect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Response Send(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
