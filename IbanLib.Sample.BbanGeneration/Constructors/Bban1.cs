namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public class Bban1 : ABban
    {
        public Bban1(string title) : base(title)
        {
            Bban1Gb();
        }

        private static void Bban1Gb()
        {
            WriteLine("BBAN 1 -> Bban1Gb()", 0, 1);

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var bban = new Bban
            {
                BankCode = "NWBK",
                BranchCode = "50-00-00",
                AccountNumber = "20504063"
            };

            PrintComparison(bban, bankAccountDetails);
        }
    }
}