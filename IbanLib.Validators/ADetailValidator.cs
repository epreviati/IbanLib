using System.Text.RegularExpressions;
using IbanLib.Common;
using IbanLib.Countries;
using IbanLib.Domain.Validators;

namespace IbanLib.Validators
{
    /// <summary>
    ///     ADetailValidator base class that defines the basically funcionalities for all the validators classes.
    /// </summary>
    public abstract class ADetailValidator : AClass, IDetailValidator
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