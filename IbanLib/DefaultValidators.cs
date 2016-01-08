using IbanLib.Common;
using IbanLib.Domain;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib
{
    /// <summary>
    ///     DefaultValidators that contains all the validators.
    /// </summary>
    public class DefaultValidators : AClass, IValidators
    {
        private readonly IAccountNumberValidator _accountNumberValidator;
        private readonly IBankCodeValidator _bankCodeValidator;
        private readonly IBbanValidator _bbanValidator;
        private readonly IBranchCodeValidator _branchCodeValidator;
        private readonly ICountryCodeValidator _countryCodeValidator;
        private readonly IIbanValidator _ibanValidator;

        /// <summary>
        ///     Constructor that permits to set all the validator.
        /// </summary>
        /// <param name="bankCodeValidator">
        ///     Objects that contains the rules to validate a Bank Code.
        /// </param>
        /// <param name="branchCodeValidator">
        ///     Objects that contains the rules to validate a Branch Code.
        /// </param>
        /// <param name="accountNumberValidator">
        ///     Objects that contains the rules to validate an Account Number.
        /// </param>
        /// <param name="countryCodeValidator">
        ///     Objects that contains the rules to validate a Country Code.
        /// </param>
        /// <param name="ibanValidator">
        ///     Objects that contains the rules to validate an IBAN.
        /// </param>
        /// <param name="bbanValidator">
        ///     Objects that contains the rules to validate a BBAN.
        /// </param>
        /// <exception cref="ValidatorException">
        ///     If any validator is not valid a <see cref="ValidatorException" /> will be thrown.
        /// </exception>
        public DefaultValidators(
            IBankCodeValidator bankCodeValidator,
            IBranchCodeValidator branchCodeValidator,
            IAccountNumberValidator accountNumberValidator,
            ICountryCodeValidator countryCodeValidator,
            IIbanValidator ibanValidator,
            IBbanValidator bbanValidator)
        {
            CheckNotNullArgument<IBankCodeValidator>(bankCodeValidator, "bankCodeValidator");
            CheckNotNullArgument<IBranchCodeValidator>(branchCodeValidator, "branchCodeValidator");
            CheckNotNullArgument<IAccountNumberValidator>(accountNumberValidator, "accountNumberValidator");
            CheckNotNullArgument<ICountryCodeValidator>(countryCodeValidator, "countryCodeValidator");
            CheckNotNullArgument<IIbanValidator>(ibanValidator, "ibanValidator");
            CheckNotNullArgument<IBbanValidator>(bbanValidator, "bbanValidator");

            _bankCodeValidator = bankCodeValidator;
            _branchCodeValidator = branchCodeValidator;
            _accountNumberValidator = accountNumberValidator;
            _countryCodeValidator = countryCodeValidator;
            _ibanValidator = ibanValidator;
            _bbanValidator = bbanValidator;
        }

        /// <summary>
        ///     The method returns the IbanValidator.
        /// </summary>
        /// <returns>
        ///     The IanValidator object.
        /// </returns>
        public IIbanValidator GetIbanValidator()
        {
            return _ibanValidator;
        }

        /// <summary>
        ///     The method returns the BbanValidator.
        /// </summary>
        /// <returns>
        ///     The BanValidator object.
        /// </returns>
        public IBbanValidator GetBbanValidator()
        {
            return _bbanValidator;
        }

        /// <summary>
        ///     The method returns the CountryCodeValidator.
        /// </summary>
        /// <returns>
        ///     The CountryCodeValidator object.
        /// </returns>
        public ICountryCodeValidator GetCountryCodeValidator()
        {
            return _countryCodeValidator;
        }

        /// <summary>
        ///     The method returns the BankCodeValidator.
        /// </summary>
        /// <returns>
        ///     The BankCodeValidator object.
        /// </returns>
        public IBankCodeValidator GetBankCodeValidator()
        {
            return _bankCodeValidator;
        }

        /// <summary>
        ///     The method returns the BranchCodeValidator.
        /// </summary>
        /// <returns>
        ///     The BranchCodeValidator object.
        /// </returns>
        public IBranchCodeValidator GetBranchCodeValidator()
        {
            return _branchCodeValidator;
        }

        /// <summary>
        ///     The method returns the AccountNumberValidator.
        /// </summary>
        /// <returns>
        ///     The AccountNumberValidator object.
        /// </returns>
        public IAccountNumberValidator GetAccountNumberValidator()
        {
            return _accountNumberValidator;
        }


        /// <summary>
        /// </summary>
        /// <typeparam name="TType">
        ///     Type of the argument.
        /// </typeparam>
        /// <param name="argument">
        ///     Argument to check.
        /// </param>
        /// <param name="argumentName">
        ///     Name of the argument to check.
        /// </param>
        /// <exception cref="ValidatorException">
        ///     If the Argument is null, an Exception of type <see cref="ValidatorException" /> will be thrown.
        /// </exception>
        private static void CheckNotNullArgument<TType>(object argument, string argumentName)
        {
            CheckNotNullArgument<TType, ValidatorException>(argument, argumentName);
        }
    }
}