using IbanLib.Countries;

namespace IbanLib.Validators.Validators
{
    public class AccountNumberValidator : ADetailValidator, IAccountNumberValidator
    {
        public override bool IsValid(ICountry country, string accountNumber)
        {
            CheckCountry(country);

            return IsValidDetailLenght(accountNumber, country.AccountNumberLength)
                   && IsValidDetailStructure(accountNumber, country.AccountNumberStructure);
        }
    }
}