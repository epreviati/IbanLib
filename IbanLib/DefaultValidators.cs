using IbanLib.Domain;
using IbanLib.Domain.Validators;

namespace IbanLib
{
    public class DefaultValidators : IValidators
    {
        private readonly IAccountNumberValidator _accountNumberValidator;
        private readonly IBankCodeValidator _bankCodeValidator;
        private readonly IBbanValidator _bbanValidator;
        private readonly IBranchCodeValidator _branchCodeValidator;
        private readonly ICountryCodeValidator _countryCodeValidator;
        private readonly IIbanValidator _ibanValidator;

        public DefaultValidators(
            IAccountNumberValidator accountNumberValidator,
            IBankCodeValidator bankCodeValidator,
            IBbanValidator bbanValidator,
            IBranchCodeValidator branchCodeValidator,
            ICountryCodeValidator countryCodeValidator,
            IIbanValidator ibanValidator)
        {
            _accountNumberValidator = accountNumberValidator;
            _bankCodeValidator = bankCodeValidator;
            _bbanValidator = bbanValidator;
            _branchCodeValidator = branchCodeValidator;
            _countryCodeValidator = countryCodeValidator;
            _ibanValidator = ibanValidator;
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
    }
}