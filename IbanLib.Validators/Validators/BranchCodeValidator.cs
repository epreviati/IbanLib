using IbanLib.Countries;
using IbanLib.Exceptions;

namespace IbanLib.Validators.Validators
{
    public class BranchCodeValidator : ADetailValidator, IBranchCodeValidator
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="branchCode"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCountryException"></exception>
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