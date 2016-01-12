namespace IbanLib.Countries.Countries
{
    public class SA : ACountry
    {
        public override string Name
        {
            get { return "Saudi Arabia"; }
        }

        public override string Iso3166
        {
            get { return "SA"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{2}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{18}"; }
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
            get { return 2; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 6; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 18; }
        }
    }
}