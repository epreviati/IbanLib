using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
    /// <summary>
    ///     AccountNumberValidator class that permits to validate an Account Number.
    /// </summary>
    public class AccountNumberValidator : ADetailValidator, IAccountNumberValidator
    {
        /// <summary>
        ///     The method returns true or false if the Account Number is valid or not for the specified Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the Account Number.
        /// </param>
        /// <param name="accountNumber">
        ///     Account Number to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        public override bool IsValid(ICountry country, string accountNumber)
        {
            CheckCountry(country);

            return IsValidDetailLenght(accountNumber, country.AccountNumberLength)
                   && IsValidDetailStructure(accountNumber, country.AccountNumberStructure);
        }
    }
}