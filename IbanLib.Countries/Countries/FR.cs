using System;
using System.Numerics;

namespace IbanLib.Countries.Countries
{
    public class FR : ACountry
    {
        public override string Name
        {
            get { return "France"; }
        }

        public override string ISO3166
        {
            get { return "FR"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string BranchIdentifierStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{11}"; }
        }

        public override string BBANStructure
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", BankIdentifierStructure, BranchIdentifierStructure,
                    AccountNumberStructure, "[0-9]{2}");
            }
        }

        public override int BBANLength
        {
            get { return 23; }
        }

        public override int IBANLength
        {
            get { return 27; }
        }

        public override bool IsSEPA
        {
            get { return true; }
        }

        public override int BankIdentifierLength
        {
            get { return 5; }
        }

        public override int? BranchIdentifierPosition
        {
            get { return 9; }
        }

        public override int BranchIdentifierLength
        {
            get { return 5; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 14; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 13; }
        }

        public override int AccountNumberLength
        {
            get { return 11; }
        }

        public override int Check3Length
        {
            get { return 2; }
        }

        public override int? Check3Position
        {
            get { return AccountNumberPosition + AccountNumberLength; }
        }

        # region Calculate Check 3

        public override string CalculateCheck3(string bankCode, string branchCode, string accountNumber)
        {
            if (!IsValidInputToCalculateChekDigits(bankCode, branchCode, accountNumber))
            {
                return null;
            }

            var concat = string.Concat(bankCode, branchCode, accountNumber);
            concat = concat
                .Replace("J", "1")
                .Replace("A", "1")
                .Replace("B", "2")
                .Replace("K", "2")
                .Replace("S", "2")
                .Replace("C", "3")
                .Replace("L", "3")
                .Replace("T", "3")
                .Replace("D", "4")
                .Replace("M", "4")
                .Replace("U", "4")
                .Replace("E", "5")
                .Replace("N", "5")
                .Replace("V", "5")
                .Replace("F", "6")
                .Replace("O", "6")
                .Replace("W", "6")
                .Replace("G", "7")
                .Replace("P", "7")
                .Replace("X", "7")
                .Replace("H", "8")
                .Replace("Q", "8")
                .Replace("Y", "8")
                .Replace("I", "9")
                .Replace("R", "9")
                .Replace("Z", "9");

            BigInteger bi;
            BigInteger.TryParse(concat, out bi);
            var rib = 97 - ((bi * 100) % 97);
            
            var stringRib = rib.ToString();
            if (Convert.ToInt32(stringRib) < 10)
            {
                stringRib = "0" + stringRib;
            }

            return stringRib;
        }

        # endregion
    }
}