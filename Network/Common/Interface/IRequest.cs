using System;

namespace Common.Interface
{
    /// <summary>
    /// Represents the functionality for request processing.
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public interface IRequest
    {
        /// <summary>
        /// Gets or sets the size of the chunk.
        /// </summary>
        /// <value>
        /// The size of the chunk.
        /// </value>
        /// <owner>Sergii Katruk</owner>
        int ChunkSize { get; set; }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <owner>Sergii Katruk</owner>
        /// <returns>The bytes array.</returns>
        byte[] GetBytes();
    }
}
