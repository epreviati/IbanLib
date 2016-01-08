using IbanLib.Countries.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;

namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public class Bban3 : ABban
    {
        public Bban3(string title) : base(title)
        {
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

            var bban = new Bban(
                new GB(),
                "NWBK50000020504063",
                Container.Resolve<IValidators>(),
                Container.Resolve<IBbanSplitter>());

            PrintComparison(bban, bankAccountDetails);
        }
    }
}