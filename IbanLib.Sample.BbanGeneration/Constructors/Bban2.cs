using IbanLib.Countries;
using IbanLib.Countries.Countries;
using IbanLib.Domain;

namespace IbanLib.Sample.BbanGeneration.Constructors
{
    public class Bban2 : ABban
    {
        public Bban2(string title) : base(title)
        {
            Bban2Ad();
            Bban2Ae();
            Bban2At();
            Bban2Az();
            Bban2Be();
            Bban2Bh();
            Bban2Gb();
        }

        private static void Bban2Gb()
        {
            WriteTitle("Bban2Gb()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NWBK",
                BranchCode = "500000",
                AccountNumber = "20504063"
            };

            var bban = GenerateBban(
                new GB(),
                "NWBK",
                "50-00-00",
                "20504063");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban2Ad()
        {
            WriteTitle("Bban2Ad()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "0001",
                BranchCode = "2030",
                AccountNumber = "200359100100"
            };

            var bban = GenerateBban(
                new AD(),
                "0001",
                "2030",
                "200359100100");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban2Ae()
        {
            WriteTitle("Bban2Ae()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "033",
                AccountNumber = "1234567890123456"
            };

            var bban = GenerateBban(
                new AE(),
                "033",
                "1234567890123456");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban2At()
        {
            WriteTitle("Bban2At()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "19043",
                AccountNumber = "00234573201"
            };

            var bban = GenerateBban(
                new AT(),
                "19043",
                "00234573201");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban2Az()
        {
            WriteTitle("Bban2Az()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "NABZ",
                AccountNumber = "00000000137010001944"
            };

            var bban = GenerateBban(
                new AZ(),
                "NABZ",
                "00000000137010001944");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban2Be()
        {
            WriteTitle("Bban2Be()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "539",
                AccountNumber = "0075470"
            };

            var bban = GenerateBban(
                new BE(),
                "539",
                "0075470");

            PrintComparison(bban, bankAccountDetails);
        }

        private static void Bban2Bh()
        {
            WriteTitle("Bban2Bh()");

            var bankAccountDetails = new BankAccountDetails
            {
                BankCode = "BMAG",
                AccountNumber = "00001299123456",
                CheckDigits3 = "34"
            };

            var bban = GenerateBban(
                new BH(),
                "BMAG",
                "00001299123456");

            PrintComparison(bban, bankAccountDetails);
        }

        private static IBban GenerateBban(ICountry country, string bankCode, string branchCode, string accountNumber)
        {
            return new Bban(
                country,
                bankCode,
                branchCode,
                accountNumber,
                Container.Resolve<IValidators>());
        }

        private static IBban GenerateBban(ICountry country, string bankCode, string accountNumber)
        {
            return new Bban(
                country,
                bankCode,
                accountNumber,
                Container.Resolve<IValidators>());
        }

        private static void WriteTitle(string methodName)
        {
            WriteLine(string.Concat("BBAN 2 -> ", methodName), 0, 1);
        }
    }
}