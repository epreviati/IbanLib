using IbanLib.Domain.Validators;

namespace IbanLib.Domain
{
    /// <summary>
    /// </summary>
    public interface IValidators
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        IIbanValidator GetIbanValidator();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IBbanValidator GetBbanValidator();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        ICountryCodeValidator GetCountryCodeValidator();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IBankCodeValidator GetBankCodeValidator();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IBranchCodeValidator GetBranchCodeValidator();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IAccountNumberValidator GetAccountNumberValidator();
    }
}