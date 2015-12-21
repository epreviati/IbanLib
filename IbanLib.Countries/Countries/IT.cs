namespace IbanLib.Countries.Countries
{
    public class IT : ACountry
    {
        public override string Name
        {
            get { return "Italy"; }
        }

        public override string ISO3166
        {
            get { return "IT"; }
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
            get { return "[0-9A-Z]{12}"; }
        }

        public override string BBANStructure
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", "[A-Z]{1}", BankIdentifierStructure, BranchIdentifierStructure,
                    AccountNumberStructure);
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

        public override int BankIdentifierPosition
        {
            get { return 5; }
        }

        public override int BankIdentifierLength
        {
            get { return 5; }
        }

        public override int? BranchIdentifierPosition
        {
            get { return 10; }
        }

        public override int BranchIdentifierLength
        {
            get { return 5; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 15; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 12; }
        }

        public override int Check1Length
        {
            get { return 1; }
        }

        public override int? Check1Position
        {
            get { return 4; }
        }
    }
}