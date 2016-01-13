namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public class Bban1 : ABban
    {
        public Bban1(string title) : base(title)
        {
            Bban1Ad();
            Bban1Ae();
            Bban1At();
            Bban1Az();
            Bban1Be();
            Bban1Bh();
            Bban1Gb();
        }

        private static void Bban1Gb()
        {
            WriteTitle("Bban1Gb()");

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

        private static void Bban1Ad()
        {
            WriteTitle("Bban1Ad()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "0001",
                BranchCode = "2030",
                AccountNumber = "200359100100"
            };

            var bban = new Bban
            {
                BankCode = "0001",
                BranchCode = "2030",
                AccountNumber = "200359100100"
            };

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban1Ae()
        {
            WriteTitle("Bban1Ae()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "033",
                AccountNumber = "1234567890123456"
            };

            var bban = new Bban
            {
                BankCode = "033",
                AccountNumber = "1234567890123456"
            };

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban1At()
        {
            WriteTitle("Bban1At()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "19043",
                AccountNumber = "00234573201"
            };

            var bban = new Bban
            {
                BankCode = "19043",
                AccountNumber = "00234573201"
            };

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban1Az()
        {
            WriteTitle("Bban1Az()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NABZ",
                AccountNumber = "00000000137010001944"
            };

            var bban = new Bban
            {
                BankCode = "NABZ",
                AccountNumber = "00000000137010001944"
            };

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban1Be()
        {
            WriteTitle("Bban1Be()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "539",
                AccountNumber = "0075470",
                CheckDigits3 = "34"
            };

            var bban = new Bban
            {
                BankCode = "539",
                AccountNumber = "0075470",
                CheckDigits3 = "34"
            };

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban1Bh()
        {
            WriteTitle("Bban1Bh()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "BMAG",
                AccountNumber = "00001299123456"
            };

            var bban = new Bban
            {
                BankCode = "BMAG",
                AccountNumber = "00001299123456"
            };

            PrintComparison(bban, bankAccountDetails);
        }

        private static void WriteTitle(string methodName)
        {
            WriteLine(string.Concat("BBAN 1 -> ", methodName), 0, 1);
        }
    }
}