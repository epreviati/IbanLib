namespace IbanLib.Countries.Countries
{
    public class IE : ACountry
    {
        public override string Name
        {
            get { return "Ireland"; }
        }

        public override string Iso3166
        {
            get { return "IE"; }
        }

        public override string BankCodeStructure
        {
            get { return "[A-Z]{4}"; }
        }

        public override string BranchCodeStructure
        {
            get { return "[0-9]{6}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{8}"; }
        }

        public override int BbanLength
        {
            get { return 18; }
        }

        public override int IbanLength
        {
            get { return 22; }
        }

        public override bool IsSepa
        {
            get { return true; }
        }

        public override int BankCodeLength
        {
            get { return 4; }
        }

        public override int? BankCodeSecondaryLengthForPayment
        {
            get { return 0; }
        }

        public override int? BranchCodePosition
        {
            get { return 8; }
        }

        public override int BranchCodeLength
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