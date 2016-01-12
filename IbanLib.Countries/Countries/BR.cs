namespace IbanLib.Countries.Countries
{
    public class BR : ACountry
    {
        public override string Name
        {
            get { return "Brazil"; }
        }

        public override string Iso3166
        {
            get { return "BR"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{8}"; }
        }

        public override string BranchCodeStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{10}[A-Z]{1}[0-9A-Z]{1}"; }
        }

        public override int BbanLength
        {
            get { return 25; }
        }

        public override int IbanLength
        {
            get { return 29; }
        }

        public override int BankCodeLength
        {
            get { return 8; }
        }

        public override int? BranchCodePosition
        {
            get { return 12; }
        }

        public override int BranchCodeLength
        {
            get { return 5; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 17; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 12; }
        }
    }
}