namespace IbanLib.Countries.Countries
{
    public class RO : ACountry
    {
        public override string Name
        {
            get { return "Romania"; }
        }

        public override string Iso3166
        {
            get { return "RO"; }
        }

        public override string BankCodeStructure
        {
            get { return "[A-Z]{4}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{16}"; }
        }

        public override int BbanLength
        {
            get { return 20; }
        }

        public override int IbanLength
        {
            get { return 24; }
        }

        public override bool IsSepa
        {
            get { return true; }
        }

        public override int BankCodeLength
        {
            get { return 4; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 8; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 16; }
        }
    }
}