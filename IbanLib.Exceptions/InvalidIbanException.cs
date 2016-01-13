using System;

namespace IbanLib.Exceptions
{
    /// <summary>
    ///     InvalidIbanException class.
    /// </summary>
    public class InvalidIbanException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidIbanException" /> class.
        /// </summary>
        public InvalidIbanException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidIbanException" /> class with a
        ///     specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public InvalidIbanException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:IbanLib.Exceptions.InvalidIbanException" /> class with a
        ///     specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public InvalidIbanException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}