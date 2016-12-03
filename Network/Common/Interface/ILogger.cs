using System;

namespace Common.Interface
{
    /// <summary>
    /// represents the functionality for logging.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <owner>Sergii Katruk</owner>
    public interface ILogger<T>
    {
        void Log(T logItem);
    }
}
