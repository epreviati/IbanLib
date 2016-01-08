using System;
using System.Text.RegularExpressions;
using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;
using IbanLib.Exceptions.Enums;

namespace IbanLib.Common
{
    /// <summary>
    ///     Abstract AClass base class with common methods.
    /// </summary>
    public abstract class AClass
    {
        /// <summary>
        ///     The method throws an <see cref="InvalidCountryException" /> if the Country is null.
        /// </summary>
        /// <param name="country">
        ///     Country to check.
        /// </param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        protected static void CheckNotNullCountry(ICountry country)
        {
            if (country == null)
            {
                throw new InvalidCountryException(
                    string.Format(
                        "Parameter '{0}' of type '{1}' can not be null.",
                        "country",
                        typeof (ICountry).Name));
            }
        }

        /// <summary>
        ///     The method throws an Exception of type <see cref="TException" /> if the Argument is null.
        /// </summary>
        /// <typeparam name="TType">
        ///     Type of the argument.
        /// </typeparam>
        /// <typeparam name="TException">
        ///     Type of the exception that will be thrown.
        /// </typeparam>
        /// <param name="argument">
        ///     Argument to check.
        /// </param>
        /// <param name="argumentName">
        ///     Name of the argument to check.
        /// </param>
        /// <exception>
        ///     If the Argument is null, an Exception of type <see cref="TException" /> will be thrown.
        /// </exception>
        protected static void CheckNotNullArgument<TType, TException>(object argument, string argumentName)
            where TException : Exception
        {
            if (argument == null)
            {
                throw NewException<TException>(
                    string.Format(
                        "Parameter '{0}' of type '{1}' can not be null.",
                        argumentName,
                        typeof (TType).Name));
            }
        }

        /// <summary>
        ///     The method throws an Exception of type <see cref="TException" /> if the Fiel is not valid.
        /// </summary>
        /// <typeparam name="TType">
        ///     Type of the argument.
        /// </typeparam>
        /// <typeparam name="TException">
        ///     Type of the exception that will be thrown.
        /// </typeparam>
        /// <param name="validator">
        ///     Validator that perfmorms the validation.
        /// </param>
        /// <param name="detailType">
        ///     Enum that defines witch detail is under evaluation.
        /// </param>
        /// <param name="country">
        ///     Country to perform the validation.
        /// </param>
        /// <param name="field">
        ///     Field to validate.
        /// </param>
        /// <param name="fieldName">
        ///     Name of the field to validate.
        /// </param>
        /// <exception>
        ///     If the Field is not valid, an Exception of type <see cref="TException" /> will be thrown.
        /// </exception>
        protected static void CheckIsValidArgument<TType, TException>(
            IDetailValidator validator, DetailType detailType,
            ICountry country, string field, string fieldName)
            where TException : InvalidBbanDetailException
        {
            if (!validator.IsValid(country, field))
            {
                throw (TException) Activator.CreateInstance(
                    typeof (TException),
                    detailType,
                    string.Format(
                        "Parameter '{0}' of type '{1}' is not valid.",
                        detailType,
                        typeof (TType).Name));
            }
        }

        /// <summary>
        ///     The method create an Exception of type <see cref="TException" />.
        /// </summary>
        /// <typeparam name="TException">
        ///     Type of the exception that will be thrown.
        /// </typeparam>
        /// <param name="message">
        ///     The message of the Exception.
        /// </param>
        /// <returns>
        ///     The Exception of type <see cref="TException" />.
        /// </returns>
        private static TException NewException<TException>(string message)
            where TException : Exception
        {
            return (TException) Activator.CreateInstance(typeof (TException), message);
        }

        /// <summary>
        ///     The method normalizes the param string doing the following steps:
        ///     1. string.ToUpperInvariant();
        ///     2. string.ReplaceAll("-", string.Empty);
        ///     3. string.ReplaceAll(" ", string.Empty);
        /// </summary>
        /// <param name="str">
        ///     String to normalize.
        /// </param>
        /// <returns>
        ///     Normalized string.
        /// </returns>
        protected static string Normalize(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }

            var strUpperInvariant = str.ToUpperInvariant();
            var strWithoutDashes = Regex.Replace(strUpperInvariant, @"-+", string.Empty);
            var strWithoutSpaces = Regex.Replace(strWithoutDashes, @"\s+", string.Empty);

            return strWithoutSpaces;
        }
    }
}