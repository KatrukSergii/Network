using System;
using Common;
using Server.Interface;

namespace Server.TCP
{
    /// <summary>
    /// Defines the server with using TCP.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class Server : IServer
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Start()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Stop()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<Request> OnRequestRecieved;
    }
}
