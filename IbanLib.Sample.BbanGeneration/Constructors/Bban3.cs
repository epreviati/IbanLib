using IbanLib.Countries.Countries;
using IbanLib.Structures;

namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public class Bban3 : AIban
    {
        public Bban3(string title)
        {
            WriteLine(title, 0, 1);
            Bban3Gb();
        }

        private static void Bban3Gb()
        {
            WriteLine("BBAN 3 -> Bban3Gb()", 0, 1);

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var bban = new Bban(new GB(), "NWBK50000020504063");

            PrintComparison(bban, bankAccountDetails);
        }
    }
}