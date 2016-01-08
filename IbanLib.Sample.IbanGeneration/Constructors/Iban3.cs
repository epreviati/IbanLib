using IbanLib.Domain;
using IbanLib.Domain.Splitters;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public class Iban3 : AIban
    {
        public Iban3(string title) : base(title)
        {
            Iban3Gb();
        }

        private static void Iban3Gb()
        {
            WriteLine("IBAN 3 -> Iban3Gb()", 0, 1);

            var bankAccount = new BankAccount
            {
                CountryCode = "GB",
                NationalCheckDigits = "80",
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var iban = GenerateIban("GB80NWBK50000020504063");

            PrintComparison(iban, bankAccount);
        }

        private static IIban GenerateIban(string iban)
        {
            return new Iban(iban,
                Container.Resolve<ICountryResolver>(),
                Container.Resolve<IBban>(),
                Container.Resolve<IValidators>(),
                Container.Resolve<IIbanSplitter>(),
                Container.Resolve<IBbanSplitter>());
        }
    }
}