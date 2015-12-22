using IbanLib.Countries.Countries;
using IbanLib.Structures;

namespace IbanLib.Sample.IbanGeneration.Constructors
{
    public class Iban2 : AIban
    {
        public Iban2(string title)
        {
            WriteLine(title, 0, 1);
            Iban2Gb();
        }

        private static void Iban2Gb()
        {
            WriteLine("IBAN 2 -> Iban2Gb()", 0, 1);

            var bankAccount = new BankAccount
            {
                CountryCode = "GB",
                NationalCheckDigits = "80",
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var country = new GB();
            var bban = new Bban
            {
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };
            var iban = new Iban(country, bban);

            PrintComparison(iban, bankAccount);
        }
    }
}