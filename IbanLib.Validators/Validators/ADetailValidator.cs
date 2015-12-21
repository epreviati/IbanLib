using System.Text.RegularExpressions;
using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Validators.Validators
{
    public abstract class ADetailValidator : IDetailValidator
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="field"></param>
        /// <returns>true or false</returns>
        public abstract bool IsValid(ICountry country, string field);

        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <returns>true or false</returns>
        /// <exception cref="InvalidCountryException"></exception>
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
        /// </summary>
        /// <param name="field"></param>
        /// <param name="lenght"></param>
        /// <returns>true or false</returns>
        protected bool IsValidDetailLenght(string field, long lenght)
        {
            return !string.IsNullOrWhiteSpace(field)
                ? field.Length == lenght
                : 0 == lenght;
        }

        /// <summary>
        /// </summary>
        /// <param name="field"></param>
        /// <param name="regExpression"></param>
        /// <returns>true or false</returns>
        protected bool IsValidDetailStructure(string field, string regExpression)
        {
            var fieldToCheck = string.IsNullOrWhiteSpace(field)
                ? string.Empty
                : field;

            return Regex.IsMatch(fieldToCheck, "^" + regExpression + "$");
        }
    }
}