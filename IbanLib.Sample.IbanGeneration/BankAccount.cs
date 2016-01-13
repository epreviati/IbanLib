namespace IbanLib.Sample.IbanGeneration
{
    public class BankAccount
    {
        public string CountryCode { get; set; }

        public string BankCode { get; set; }

        public string BranchCode { get; set; }

        public string AccountNumber { get; set; }

        public string NationalCheckDigits { get; set; }

        public string CheckDigits1 { get; set; }

        public string CheckDigits2 { get; set; }

        public string CheckDigits3 { get; set; }

        public string Bban()
        {
            return string.Concat(
                CheckDigits1,
                BankCode,
                BranchCode,
                CheckDigits2,
                AccountNumber,
                CheckDigits3);
        }

        public string Iban()
        {
            return string.Concat(
                CountryCode,
                NationalCheckDigits,
                Bban());
        }
    }
}