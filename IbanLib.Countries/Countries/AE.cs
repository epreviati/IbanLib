namespace IbanLib.Countries.Countries
{
    public class AE : ACountry
    {
        public override string Name
        {
            get { return "United Arab Emirates"; }
        }

        public override string Iso3166
        {
            get { return "AE"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{3}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{16}"; }
        }

        public override int BbanLength
        {
            get { return 19; }
        }

        public override int IbanLength
        {
            get { return 23; }
        }

        public override int BankCodeLength
        {
            get { return 3; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 7; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 16; }
        }
    }
}