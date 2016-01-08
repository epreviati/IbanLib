using System.Diagnostics;
using IbanLib.Common;
using IbanLib.Domain;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib
{
    /// <summary>
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
        /// </summary>
        /// <param name="accountNumberValidator"></param>
        /// <param name="bankCodeValidator"></param>
        /// <param name="bbanValidator"></param>
        /// <param name="branchCodeValidator"></param>
        /// <param name="countryCodeValidator"></param>
        /// <param name="ibanValidator"></param>
        /// <exception cref="ValidatorException"></exception>
        public DefaultValidators(
            IBankCodeValidator bankCodeValidator,
            IBranchCodeValidator branchCodeValidator,
            IAccountNumberValidator accountNumberValidator,
            ICountryCodeValidator countryCodeValidator,
            IIbanValidator ibanValidator,
            IBbanValidator bbanValidator)
        {
            CheckNotNullArgument<IBankCodeValidator>(bankCodeValidator, "bankCodeValidator");
            Debug.Assert(bankCodeValidator != null, "bankCodeValidator != null");

            CheckNotNullArgument<IBranchCodeValidator>(branchCodeValidator, "branchCodeValidator");
            Debug.Assert(branchCodeValidator != null, "branchCodeValidator != null");

            CheckNotNullArgument<IAccountNumberValidator>(accountNumberValidator,
                "accountNumberValidator");
            Debug.Assert(accountNumberValidator != null, "accountNumberValidator != null");

            CheckNotNullArgument<ICountryCodeValidator>(countryCodeValidator, "countryCodeValidator");
            Debug.Assert(countryCodeValidator != null, "countryCodeValidator != null");

            CheckNotNullArgument<IIbanValidator>(ibanValidator, "ibanValidator");
            Debug.Assert(ibanValidator != null, "ibanValidator != null");

            CheckNotNullArgument<IBbanValidator>(bbanValidator, "bbanValidator");
            Debug.Assert(bbanValidator != null, "bbanValidator != null");

            _bankCodeValidator = bankCodeValidator;
            _branchCodeValidator = branchCodeValidator;
            _accountNumberValidator = accountNumberValidator;
            _countryCodeValidator = countryCodeValidator;
            _ibanValidator = ibanValidator;
            _bbanValidator = bbanValidator;
        }

        public IIbanValidator GetIbanValidator()
        {
            return _ibanValidator;
        }

        public IBbanValidator GetBbanValidator()
        {
            return _bbanValidator;
        }

        public ICountryCodeValidator GetCountryCodeValidator()
        {
            return _countryCodeValidator;
        }

        public IBankCodeValidator GetBankCodeValidator()
        {
            return _bankCodeValidator;
        }

        public IBranchCodeValidator GetBranchCodeValidator()
        {
            return _branchCodeValidator;
        }

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