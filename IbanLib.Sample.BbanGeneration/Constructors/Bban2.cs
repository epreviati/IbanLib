using IbanLib.Countries.Countries;
using IbanLib.Domain;

namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public class Bban2 : ABban
    {
        public Bban2(string title) : base(title)
        {
            Bban2Gb();
        }

        private static void Bban2Gb()
        {
            WriteLine("BBAN 2 -> Bban2Gb()", 0, 1);

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var bban = new Bban(new GB(), "NWBK", "50-00-00", "20504063", Container.Resolve<IValidators>());

            PrintComparison(bban, bankAccountDetails);
        }
    }
}