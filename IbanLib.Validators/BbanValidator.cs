using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
    public class BbanValidator : ADetailValidator, IBbanValidator
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="iban"></param>
        /// <returns>true or false</returns>
        /// <exception cref="InvalidCountryException"></exception>
        public override bool IsValid(ICountry country, string iban)
        {
            CheckCountry(country);

            return IsValidDetailLenght(iban, country.BBANLength)
                   && IsValidDetailStructure(iban, country.BBANStructure);
        }
    }
}