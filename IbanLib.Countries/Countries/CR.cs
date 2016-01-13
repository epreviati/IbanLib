namespace IbanLib.Countries.Countries
{
    public class CR : ACountry
    {
        public override string Name
        {
            get { return "Costa Rica"; }
        }

        public override string Iso3166
        {
            get { return "CR"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{3}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9]{14}"; }
        }

        public override int BbanLength
        {
            get { return 17; }
        }

        public override int IbanLength
        {
            get { return 21; }
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
            get { return 14; }
        }
    }
}