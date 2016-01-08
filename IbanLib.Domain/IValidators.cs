using IbanLib.Domain.Validators;

namespace IbanLib.Domain
{
    /// <summary>
    ///     IValidators interface that defines all the validators.
    /// </summary>
    public interface IValidators
    {
        /// <summary>
        ///     The method returns the implementation of the IBankCodeValidator.
        /// </summary>
        /// <returns>
        ///     The IBankCodeValidator object.
        /// </returns>
        IBankCodeValidator GetBankCodeValidator();

        /// <summary>
        ///     The method returns the implementation of the IBranchCodeValidator.
        /// </summary>
        /// <returns>
        ///     The IBranchCodeValidator object.
        /// </returns>
        IBranchCodeValidator GetBranchCodeValidator();

        /// <summary>
        ///     The method returns the implementation of the IAccountNumberValidator.
        /// </summary>
        /// <returns>
        ///     The IAccountNumberValidator object.
        /// </returns>
        IAccountNumberValidator GetAccountNumberValidator();

        /// <summary>
        ///     The method returns the implementation of the ICountryCodeValidator.
        /// </summary>
        /// <returns>
        ///     The ICountryCodeValidator object.
        /// </returns>
        ICountryCodeValidator GetCountryCodeValidator();

        /// <summary>
        ///     The method returns the implementation of the IIBanValidator.
        /// </summary>
        /// <returns>
        ///     The IIBanValidator object.
        /// </returns>
        IIbanValidator GetIbanValidator();

        /// <summary>
        ///     The method returns the implementation of the IIBanValidator.
        /// </summary>
        /// <returns>
        ///     The IIBanValidator object.
        /// </returns>
        IBbanValidator GetBbanValidator();
    }
}