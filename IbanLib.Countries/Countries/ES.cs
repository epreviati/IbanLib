using System;

namespace IbanLib.Countries.Countries
{
    public class ES : ACountry
    {
        public override string Name
        {
            get { return "Spain"; }
        }

        public override string ISO3166
        {
            get { return "ES"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string BranchIdentifierStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{10}"; }
        }

        public override string BBANStructure
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", BankIdentifierStructure, BranchIdentifierStructure,
                    "[0-9]{1}[0-9]{1}", AccountNumberStructure);
            }
        }

        public override int BBANLength
        {
            get { return 20; }
        }

        public override int IBANLength
        {
            get { return 24; }
        }

        public override bool IsSEPA
        {
            get { return true; }
        }

        public override int BankIdentifierLength
        {
            get { return 4; }
        }

        public override int? BranchIdentifierPosition
        {
            get { return 8; }
        }

        public override int BranchIdentifierLength
        {
            get { return 4; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 12; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 12; }
        }

        public override int AccountNumberLength
        {
            get { return 10; }
        }

        public override int AccountNumberPosition
        {
            get { return SwiftAccountNumberPosition + Check2Length; }
        }

        public override int Check2Length
        {
            get { return 2; }
        }

        public override int? Check2Position
        {
            get { return SwiftAccountNumberPosition; }
        }

        # region Calculate Check 3

        public override string CalculateCheck2(string bankCode, string branchCode, string accountNumber)
        {
            if (!IsValidInputToCalculateChekDigits(bankCode, branchCode, accountNumber))
            {
                return null;
            }

            var bankIdentifier = string.Concat(bankCode, branchCode);
            var q = Convert.ToInt32(bankIdentifier[7])*6;
            var w = Convert.ToInt32(bankIdentifier[6])*3;
            var e = Convert.ToInt32(bankIdentifier[5])*7;
            var r = Convert.ToInt32(bankIdentifier[4])*9;
            var t = Convert.ToInt32(bankIdentifier[3])*10;
            var y = Convert.ToInt32(bankIdentifier[2])*5;
            var u = Convert.ToInt32(bankIdentifier[1])*8;
            var i = Convert.ToInt32(bankIdentifier[0])*4;

            var bankIdentifierSum = q + w + e + r + t + y + u + i;
            var firstNumber = 11 - (bankIdentifierSum%11);
            switch (firstNumber)
            {
                case 10:
                    firstNumber = 1;
                    break;
                case 11:
                    firstNumber = 0;
                    break;
            }

            var acctNumber = accountNumber;
            var a = Convert.ToInt32(acctNumber[9])*6;
            var s = Convert.ToInt32(acctNumber[8])*3;
            var d = Convert.ToInt32(acctNumber[7])*7;
            var f = Convert.ToInt32(acctNumber[6])*9;
            var g = Convert.ToInt32(acctNumber[5])*10;
            var h = Convert.ToInt32(acctNumber[4])*5;
            var j = Convert.ToInt32(acctNumber[3])*8;
            var l = Convert.ToInt32(acctNumber[2])*4;
            var z = Convert.ToInt32(acctNumber[1])*2;
            var x = Convert.ToInt32(acctNumber[0])*1;

            var accountSum = a + s + d + f + g + h + j + l + z + x;
            var secondNumber = 11 - (accountSum%11);
            switch (secondNumber)
            {
                case 10:
                    secondNumber = 1;
                    break;
                case 11:
                    secondNumber = 0;
                    break;
            }

            return string.Concat(firstNumber, secondNumber);
        }

        # endregion
    }
}