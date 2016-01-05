namespace IbanLib.Countries.Countries
{
    public class MR : FR
    {
        public override string Name
        {
            get { return "Mauritania"; }
        }

        public override string ISO3166
        {
            get { return "MR"; }
        }

        # region Calculate Check Digits

        public override string CalculateNationalCheckDigits(string iban)
        {
            return !IsValidInputToCalculateNationalCheckDigits(iban) ? null : "13";
        }

        # endregion
    }
}