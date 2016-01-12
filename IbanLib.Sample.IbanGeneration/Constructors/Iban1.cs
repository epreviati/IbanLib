using IbanLib.Countries.Countries;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public class Iban1 : AIban
    {
        public Iban1(string title) : base(title)
        {
            Iban1Gb();
        }

        private static void Iban1Gb()
        {
            WriteLine("IBAN 1 -> Iban1Gb()", 0, 1);

            var bankAccount = new BankAccount
            {
                CountryCode = "GB",
                NationalCheckDigits = "80",
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var iban = new Iban
            {
                Country = new GB(),
                NationalCheckDigits = "80",
                Bban = new Bban
                {
                    BankCode = "NWBK",
                    BranchCode = "50-00-00",
                    AccountNumber = "20504063"
                }
            };

            PrintComparison(iban, bankAccount);
        }
    }
}