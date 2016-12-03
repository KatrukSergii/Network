using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Common;
using Common.Interface;
using Server.Interface;

namespace Server.UDP
{
    /// <summary>
    /// Defines the server with using UDP.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class Server : IServer
    {
        private readonly ILogger<string> logger;

        public Server(ILogger<string> logger = null)
        {
            this.logger = logger ?? NullStringLogger.Instance;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Start()
        {
            this.started = true;
            int receivedDataLength;
            byte[] data = new byte[1024];
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 11001);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Bind(ip);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = sender;

            while (this.started)
            {
                data = new byte[1024];
                receivedDataLength = socket.ReceiveFrom(data, ref Remote);

                string recieved = Encoding.ASCII.GetString(data, 0, receivedDataLength);
                EventHandler<Request> onOnRequestRecieved = this.OnRequestRecieved;
                onOnRequestRecieved?.Invoke(this, new Request(recieved));
                socket.SendTo(data, receivedDataLength, SocketFlags.None, Remote);
            }
        }

        private bool started;

        /// <summary>
        /// Stops this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Stop()
        {
            this.started = false;
        }

        public event EventHandler<Request> OnRequestRecieved;
    }
}
