using System;
using IbanLib.Exceptions.Enums;

namespace IbanLib.Exceptions
{
    /// <summary>
    ///     InvalidBbanDetailException class.
    /// </summary>
    public class InvalidBbanDetailException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidBbanDetailException" /> class.
        /// </summary>
        /// <param name="type">The enum value that specifies the detail.</param>
        public InvalidBbanDetailException(DetailType type)
        {
            DetailType = type;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidBbanDetailException" /> class with a
        ///     specified error message.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message">The message that describes the error.</param>
        public InvalidBbanDetailException(DetailType type, string message)
            : base(message)
        {
            DetailType = type;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidBbanDetailException" /> class with a
        ///     specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public InvalidBbanDetailException(DetailType type, string message, Exception innerException)
            : base(message, innerException)
        {
            DetailType = type;
        }

        public DetailType DetailType { get; private set; }
    }
}