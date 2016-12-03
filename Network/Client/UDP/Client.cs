using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Client.Interface;
using Common;
using Common.Interface;

namespace Client.UDP
{
    /// <summary>
    /// Defines logic for the client with using UDP.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class Client : IClient
    {
        /// <summary>
        /// The logger.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        private readonly ILogger<string> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <param name="logger">The logger.</param>
        public Client(ILogger<string> logger = null)
        {
            this.logger = logger ?? NullStringLogger.Instance;
        }
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

        /// <summary>
        /// Sends this instance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <owner>Sergii Katruk</owner>
        public Response Send(Request request)
        {
            byte[] bytes = new byte[1024];
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                sender.Connect(remoteEP);

                this.logger.Log("Socket connected to {sender.RemoteEndPoint}");

                // Encode the data string into a byte array.
                byte[] msg = request.GetBytes();

                // Send the data through the socket.
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.
                int bytesRec = sender.Receive(bytes);
                this.logger.Log($"Echoed test = {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");

                // Release the socket.
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                this.logger.Log($"ArgumentNullException : {ane}");
            }
            catch (SocketException se)
            {
                this.logger.Log($"SocketException : {se}");
            }
            catch (Exception e)
            {
                this.logger.Log($"Unexpected exception : {e}");
            }
            return new Response();
        }
    }
}
