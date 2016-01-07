using System.Text.RegularExpressions;
using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
    /// <summary>
    ///     ADetailValidator base class that defines the basically funcionalities for all the validators classes.
    /// </summary>
    public abstract class ADetailValidator : IDetailValidator
    {
        /// <summary>
        ///     The method returns true or false if the Field is valid or not for the specified Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the Field.
        /// </param>
        /// <param name="field">
        ///     Field to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        public abstract bool IsValid(ICountry country, string field);

        /// <summary>
        ///     The method throws an <see cref="InvalidCountryException" /> if the Country is null.
        /// </summary>
        /// <param name="country">
        ///     Country to check.
        /// </param>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null the exception will be thrown.
        /// </exception>
        protected void CheckCountry(ICountry country)
        {
            if (country == null)
            {
                throw new InvalidCountryException(
                    string.Format(
                        "The parameter {0} of type {1} can not be null.",
                        "country",
                        typeof (ICountry).Name));
            }
        }

        /// <summary>
        ///     The method returns true or false if the lenght of the Field corrispond or not with the requested Lenght.
        /// </summary>
        /// <param name="field">
        ///     Field to check the lenght.
        /// </param>
        /// <param name="lenght">
        ///     Lenght that has to be the field.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        protected bool IsValidDetailLenght(string field, long lenght)
        {
            return !string.IsNullOrWhiteSpace(field)
                ? field.Length == lenght
                : 0 == lenght;
        }

        /// <summary>
        ///     The method returns true or false if the structure of the Field match or not with the requested Regular Expression.
        /// </summary>
        /// <param name="field">
        ///     Field to check the structure.
        /// </param>
        /// <param name="regExpression">
        ///     Regular Expression tha determine wich structure has to have the field.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        protected bool IsValidDetailStructure(string field, string regExpression)
        {
            var fieldToCheck = string.IsNullOrWhiteSpace(field)
                ? string.Empty
                : field;

            return Regex.IsMatch(fieldToCheck, "^" + regExpression + "$");
        }
    }
}