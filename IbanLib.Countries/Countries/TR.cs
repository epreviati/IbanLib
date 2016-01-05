namespace IbanLib.Countries.Countries
{
    public class TR : ACountry
    {
        public override string Name
        {
            get { return "Turkey"; }
        }

        public override string Iso3166
        {
            get { return "TR"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string BranchCodeStructure
        {
            get { return "[0-9A-Z]{1}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{16}"; }
        }

        public override int BbanLength
        {
            get { return 22; }
        }

        public override int IbanLength
        {
            get { return 26; }
        }

        public override int BankCodeLength
        {
            get { return 5; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 9; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 17; }
        }

        public override int AccountNumberLength
        {
            get { return 16; }
        }

        public override int AccountNumberPosition
        {
            get { return SwiftAccountNumberPosition + Check2Length; }
        }

        public override int Check2Length
        {
            get { return 1; }
        }

        public override int? Check2Position
        {
            get { return SwiftAccountNumberPosition; }
        }

        public override string CalculateCheck2(string bankCode, string branchCode, string accountNumber)
        {
            if (!IsValidInputToCalculateChekDigits(bankCode, branchCode, accountNumber))
            {
                return null;
            }

            // Reserved for future use.
            return "0";
        }
    }
}