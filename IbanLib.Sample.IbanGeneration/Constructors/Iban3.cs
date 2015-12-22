using IbanLib.Structures;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public class Iban3 : AIban
    {
        public Iban3(string title)
        {
            WriteLine(title, 0, 1);
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

            var iban = new Iban("GB80NWBK50000020504063");

            PrintComparison(iban, bankAccount);
        }
    }
}