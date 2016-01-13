using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;

namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public class Bban3 : ABban
    {
        public Bban3(string title) : base(title)
        {
            Bban3Ad();
            Bban3Ae();
            Bban3At();
            Bban3Az();
            Bban3Be();
            Bban3Bh();
            Bban3Gb();
        }

        private static void Bban3Gb()
        {
            WriteTitle("Bban3Ad()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var bban = GenerateBban(
                new GB(),
                "NWBK50000020504063");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban3Ad()
        {
            WriteTitle("Bban3Ad()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "0001",
                BranchCode = "2030",
                AccountNumber = "200359100100"
            };

            var bban = GenerateBban(
                new AD(),
                "00012030200359100100");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban3Ae()
        {
            WriteTitle("Bban3Ae()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "033",
                AccountNumber = "1234567890123456"
            };

            var bban = GenerateBban(
                new AE(),
                "0331234567890123456");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban3At()
        {
            WriteTitle("Bban3Ae()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "19043",
                AccountNumber = "00234573201"
            };

            var bban = GenerateBban(
                new AT(),
                "1904300234573201");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban3Az()
        {
            WriteTitle("Bban3Az()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NABZ",
                AccountNumber = "00000000137010001944"
            };

            var bban = GenerateBban(
                new AZ(),
                "NABZ00000000137010001944");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban3Be()
        {
            WriteTitle("Bban3Be()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "539",
                AccountNumber = "0075470",
                CheckDigits3 = "34"
            };

            var bban = GenerateBban(
                new BE(),
                "539007547034");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban3Bh()
        {
            WriteTitle("Bban3Bh()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "BMAG",
                AccountNumber = "00001299123456"
            };

            var bban = GenerateBban(
                new BH(),
                "BMAG00001299123456");

            PrintComparison(bban, bankAccountDetails);
        }

        private static IBban GenerateBban(ICountry country, string bban)
        {
            return new Bban(
                country,
                bban,
                Container.Resolve<IValidators>(),
                Container.Resolve<IBbanSplitter>());
        }

        private static void WriteTitle(string methodName)
        {
            WriteLine(string.Concat("BBAN 3 -> ", methodName), 0, 1);
        }
    }
}