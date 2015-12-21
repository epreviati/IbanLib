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
    }
}