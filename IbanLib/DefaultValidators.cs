using IbanLib.Domain;
using IbanLib.Domain.Validators;
using IbanLib.Exceptions;

namespace IbanLib
{
    /// <summary>
    /// </summary>
    public class DefaultValidators : IValidators
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
            CheckArgument<IBankCodeValidator>(bankCodeValidator, "bankCodeValidator");
            CheckArgument<IBranchCodeValidator>(branchCodeValidator, "branchCodeValidator");
            CheckArgument<IAccountNumberValidator>(accountNumberValidator, "accountNumberValidator");
            CheckArgument<ICountryCodeValidator>(countryCodeValidator, "countryCodeValidator");
            CheckArgument<IIbanValidator>(ibanValidator, "ibanValidator");
            CheckArgument<IBbanValidator>(bbanValidator, "bbanValidator");

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
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ValidatorException"></exception>
        private static void CheckArgument<T>(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ValidatorException(
                    string.Format(
                        "Argument '{0}' of type '{1}' can not be null.",
                        argumentName,
                        typeof (T)));
            }
        }
    }
}