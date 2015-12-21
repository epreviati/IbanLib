namespace IbanLib.Countries.Countries
{
    public class GB : ACountry
    {
        public override string Name
        {
            get { return "United Kingdom"; }
        }

        public override string ISO3166
        {
            get { return "GB"; }
        }

        public override string BankIdentifierStructure
        {
            get { return "[A-Z]{4}"; }
        }

        public override string BranchIdentifierStructure
        {
            get { return "[0-9]{6}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{8}"; }
        }

        public override int BBANLength
        {
            get { return 18; }
        }

        public override int IBANLength
        {
            get { return 22; }
        }

        public override bool IsSEPA
        {
            get { return true; }
        }

        public override int BankIdentifierLength
        {
            get { return 4; }
        }

        public override int? DifferentBankIdentifierLengthForPayment
        {
            get { return 0; }
        }

        public override int? BranchIdentifierPosition
        {
            get { return 8; }
        }

        public override int BranchIdentifierLength
        {
            get { return 6; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 14; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 8; }
        }
    }
}