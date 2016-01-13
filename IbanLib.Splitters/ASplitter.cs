using System;
using IbanLib.Common;
using IbanLib.Countries;
using IbanLib.Domain.Validators;

namespace IbanLib.Splitters
{
    /// <summary>
    ///     Abstract ASplitter base class that defines the basically funcionalities for all the splitter classes.
    /// </summary>
    public abstract class ASplitter : AClass
    {
        protected readonly IDetailValidator Validator;

        protected ASplitter(IDetailValidator validator)
        {
            Validator = validator;
        }

        /// <summary>
        ///     Method that returns a generic error message personalized with the three fields.
        /// </summary>
        /// <param name="fieldName">
        ///     Parameter Field Name.
        /// </param>
        /// <param name="fieldToSplit">
        ///     Parameter Field To split.
        /// </param>
        /// <param name="fieldToExtract">
        ///     Parameter Field To Extract.
        /// </param>
        /// <returns>
        ///     The error message created using the passed parameters.
        /// </returns>
        protected static string GetErrorMessage(string fieldName, string fieldToSplit, string fieldToExtract)
        {
            return string.Format(
                "It is not possible to split the {0} '{1}' to extract the '{2}'.",
                fieldName,
                fieldToSplit,
                fieldToExtract);
        }

        /// <summary>
        ///     The method throws an Exception of type <see cref="TException" /> if the field is not valid for the Country.
        /// </summary>
        /// <typeparam name="TException">
        ///     Type of the Exception that will be thrown.
        /// </typeparam>
        /// <param name="country">
        ///     Country that contains the information to check the Field.
        /// </param>
        /// <param name="field">
        ///     Field to check.
        /// </param>
        /// <param name="fieldName">
        ///     Name of the field to check.
        /// </param>
        /// <exception>
        ///     If the Field is not valid for the Country, an Exception of type <see cref="TException" /> will be thrown.
        /// </exception>
        protected void CheckIsValidField<TException>(ICountry country, string field, string fieldName)
            where TException : Exception, new()
        {
            if (!Validator.IsValid(country, field))
            {
                throw (TException) Activator.CreateInstance(typeof (TException), string.Format(
                    "Parameter {0} '{1}' for country '{2}' is not valid.",
                    fieldName,
                    field,
                    country.Iso3166));
            }
        }
    }
}