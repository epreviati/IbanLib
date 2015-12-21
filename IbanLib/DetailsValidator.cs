using IbanLib.Validators;
using IbanLib.Validators.Validators;

namespace IbanLib
{
    public class DetailsValidator : IDetailsValidator
    {
        private readonly IAccountNumberValidator _accountNumberValidator;
        private readonly IBankCodeValidator _bankCodeValidator;
        private readonly IBranchCodeValidator _branchCodeValidator;
        private readonly ICountryCodeValidator _countryCodeValidator;
        private readonly IIbanValidator _ibanValidator;

        public DetailsValidator()
            : this(
                new CountryCodeValidator(),
                new BankCodeValidator(),
                new BranchCodeValidator(),
                new AccountNumberValidator(),
                new IbanValidator())
        {
        }

        public DetailsValidator(
            ICountryCodeValidator countryCodeValidator,
            IBankCodeValidator bankCodeValidator,
            IBranchCodeValidator branchCodeValidator,
            IAccountNumberValidator accountNumberValidator,
            IIbanValidator ibanValidator)
        {
            _countryCodeValidator = countryCodeValidator;
            _bankCodeValidator = bankCodeValidator;
            _branchCodeValidator = branchCodeValidator;
            _accountNumberValidator = accountNumberValidator;
            _ibanValidator = ibanValidator;
        }

        public ICountryCodeValidator GetCountryCodeValidator()
        {
            return _countryCodeValidator;
        }

        public IIbanValidator GetIbanValidator()
        {
            return _ibanValidator;
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