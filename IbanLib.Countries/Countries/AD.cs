namespace IbanLib.Countries.Countries
{
    public class AD : ACountry
    {
        public override string Name
        {
            get { return "Andorra"; }
        }

        public override string Iso3166
        {
            get { return "AD"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string BranchCodeStructure
        {
            get { return "[0-9]{4}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{12}"; }
        }

        public override int BbanLength
        {
            get { return 20; }
        }

        public override int IbanLength
        {
            get { return 24; }
        }

        public override int BankCodeLength
        {
            get { return 4; }
        }

        public override int? BranchCodePosition
        {
            get { return 8; }
        }

        public override int BranchCodeLength
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
    }
}