using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
    /// <summary>
    ///     BankCodeValidator class that permits to validate a Bank Code.
    /// </summary>
    public class BankCodeValidator : ADetailValidator, IBankCodeValidator
    {
        /// <summary>
        ///     The method returns true or false if the Bank Code is valid or not for the specified Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the Bank Code.
        /// </param>
        /// <param name="bankCode">
        ///     Bank Code to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be thrown.
        /// </exception>
        public override bool IsValid(ICountry country, string bankCode)
        {
            CheckCountry(country);

            return IsValidDetailLenght(bankCode, country.BankCodeLength)
                   && IsValidDetailStructure(bankCode, country.BankCodeStructure);
        }
    }
}