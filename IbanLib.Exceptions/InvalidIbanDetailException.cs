using System;
using IbanLib.Exceptions.Enums;

namespace IbanLib.Exceptions
{
    /// <summary>
    ///     InvalidIbanDetailException class.
    /// </summary>
    public class InvalidIbanDetailException : InvalidBbanDetailException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidIbanDetailException" /> class.
        /// </summary>
        /// <param name="type">The enum value that specifies the detail.</param>
        public InvalidIbanDetailException(DetailType type)
            : base(type)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidIbanException" /> class with a
        ///     specified error message.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message">The message that describes the error.</param>
        public InvalidIbanDetailException(DetailType type, string message)
            : base(type, message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidIbanException" /> class with a
        ///     specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public InvalidIbanDetailException(DetailType type, string message, Exception innerException)
            : base(type, message, innerException)
        {
        }
    }
}