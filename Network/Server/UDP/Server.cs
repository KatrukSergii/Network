using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
        /// <summary>
        /// Defines whether the server is started.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        private bool isStarted;

        /// <summary>
        /// The logger.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        private readonly ILogger<string> logger;

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <value>
        /// The options.
        /// </value>
        public ServerOptions Options
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Server" /> class.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <param name="logger">The logger.</param>
        /// <param name="options">The options.</param>
        public Server(ILogger<string> logger = null, ServerOptions options = null)
        {
            this.logger = logger ?? NullStringLogger.Instance;
            this.Options = options ?? new ServerOptions
                           {
                               PortNumber = 11001
                           };
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Start()
        {
            this.isStarted = true;
            int chunkSize = 1024;
            byte[] data = new byte[chunkSize];
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, this.Options.PortNumber);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Bind(ip);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = sender;

            while (this.isStarted)
            {
                data = new byte[chunkSize];
                int receivedDataLength = socket.ReceiveFrom(data, ref Remote);

                string recieved = Encoding.ASCII.GetString(data, 0, receivedDataLength);
                EventHandler<Request> onOnRequestRecieved = this.OnRequestReceived;
                onOnRequestRecieved?.Invoke(this, new Request(recieved));
                socket.SendTo(data, receivedDataLength, SocketFlags.None, Remote);
            }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Stop()
        {
            this.isStarted = false;
        }

        /// <summary>
        /// Occurs when request received.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public event EventHandler<Request> OnRequestReceived;
    }
}
