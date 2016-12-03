using System;
using System.Text;
using Common.Interface;

namespace Common
{
    /// <summary>
    /// Defines the request.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class Request : IRequest
    {
        /// <summary>
        /// The default chunk size.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public const int DefaultChunkSize = 1024;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <param name="message">The message.</param>
        public Request(string message)
        {
            this.ChunkSize = Request.DefaultChunkSize;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the size of the chunk.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <value>
        /// The size of the chunk.
        /// </value>
        public int ChunkSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <returns>
        /// The bytes array.
        /// </returns>
        public byte[] GetBytes()
        {
            return Encoding.ASCII.GetBytes(this.Message);
        }

        /// <summary>
        /// The current position.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        private int currentPosition = 0;

        /// <summary>
        /// Resets this instance.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        public void Reset()
        {
            this.currentPosition = 0;
        }
    }
}
