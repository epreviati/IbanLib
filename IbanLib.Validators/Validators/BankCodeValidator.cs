using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Validators.Validators
{
    public class BankCodeValidator : ADetailValidator, IBankCodeValidator
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCountryException"></exception>
        public override bool IsValid(ICountry country, string bankCode)
        {
            CheckCountry(country);

            return IsValidDetailLenght(bankCode, country.BankIdentifierLength)
                   && IsValidDetailStructure(bankCode, country.BankIdentifierStructure);
        }
    }
}