using IbanLib.Validators;
using IbanLib.Validators.Validators;

namespace IbanLib.Structures
{
    public class DetailsValidator : IDetailsValidator
    {
        private readonly IIbanValidator _ibanValidator;
        private readonly IBbanValidator _bbanValidator;
        private readonly IAccountNumberValidator _accountNumberValidator;
        private readonly IBankCodeValidator _bankCodeValidator;
        private readonly IBranchCodeValidator _branchCodeValidator;
        private readonly ICountryCodeValidator _countryCodeValidator;

        public DetailsValidator()
            : this(
            
                new IbanValidator(),
                new BbanValidator(), 
                new CountryCodeValidator(),
                new BankCodeValidator(),
                new BranchCodeValidator(),
                new AccountNumberValidator())
        {
        }

        public DetailsValidator(
            IIbanValidator ibanValidator,
            IBbanValidator bbanValidator,
            ICountryCodeValidator countryCodeValidator,
            IBankCodeValidator bankCodeValidator,
            IBranchCodeValidator branchCodeValidator,
            IAccountNumberValidator accountNumberValidator)
        {
            _ibanValidator = ibanValidator;
            _bbanValidator = bbanValidator;
            _countryCodeValidator = countryCodeValidator;
            _bankCodeValidator = bankCodeValidator;
            _branchCodeValidator = branchCodeValidator;
            _accountNumberValidator = accountNumberValidator;
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