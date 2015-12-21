using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Validators.Validators
{
    public class AccountNumberValidator : ADetailValidator, IAccountNumberValidator
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCountryException"></exception>
        public override bool IsValid(ICountry country, string accountNumber)
        {
            CheckCountry(country);

            return IsValidDetailLenght(accountNumber, country.AccountNumberLength)
                   && IsValidDetailStructure(accountNumber, country.AccountNumberStructure);
        }
    }
}