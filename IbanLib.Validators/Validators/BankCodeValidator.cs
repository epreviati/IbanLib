using IbanLib.Countries;

namespace IbanLib.Validators.Validators
{
    public class BankCodeValidator : ADetailValidator, IBankCodeValidator
    {
        public override bool IsValid(ICountry country, string bankCode)
        {
            CheckCountry(country);

            return IsValidDetailLenght(bankCode, country.BankIdentifierLength)
                   && IsValidDetailStructure(bankCode, country.BankIdentifierStructure);
        }
    }
}