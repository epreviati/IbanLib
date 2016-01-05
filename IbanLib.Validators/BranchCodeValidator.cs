using IbanLib.Countries;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib.Validators
{
    /// <summary>
    ///     BranchCodeValidator class that permits to validate a Branch Code.
    /// </summary>
    public class BranchCodeValidator : ADetailValidator, IBranchCodeValidator
    {
        /// <summary>
        ///     The method returns true or false if the Branch Code is valid or not for the specified Country.
        /// </summary>
        /// <param name="country">
        ///     Country that contains the information to validate the Branch Code.
        /// </param>
        /// <param name="branchCode">
        ///     Branch Code to validate.
        /// </param>
        /// <returns>
        ///     True/False
        /// </returns>
        /// <exception cref="InvalidCountryException">
        ///     If Country is null an <see cref="InvalidCountryException" /> will be throwed.
        /// </exception>
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