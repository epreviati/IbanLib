using IbanLib.Countries;

namespace IbanLib.Validators.Validators
{
    public class BranchCodeValidator : ADetailValidator, IBranchCodeValidator
    {
        public override bool IsValid(ICountry country, string branchCode)
        {
            CheckCountry(country);

            if (country.BranchIdentifierLength > 0)
            {
                return IsValidDetailLenght(branchCode, country.BranchIdentifierLength)
                       && IsValidDetailStructure(branchCode, country.BranchIdentifierStructure);
            }

            return string.IsNullOrWhiteSpace(branchCode);
        }
    }
}