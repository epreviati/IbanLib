namespace IbanLib.Countries
{
    public interface ICountry
    {
        string Name { get; }

        string ISO3166 { get; }

        string BankIdentifierStructure { get; }

        string BranchIdentifierStructure { get; }

        string AccountNumberStructure { get; }

        string BBANStructure { get; }

        int BBANLength { get; }

        string IBANStructure { get; }

        int IBANLength { get; }

        bool IsSEPA { get; }

        int BankIdentifierPosition { get; }

        int BankIdentifierLength { get; }

        int? DifferentBankIdentifierLengthForPayment { get; }

        int? BranchIdentifierPosition { get; }

        int BranchIdentifierLength { get; }

        int IbanNationalIdLength { get; }

        int SwiftAccountNumberPosition { get; }

        int SwiftAccountNumberLength { get; }

        int AccountNumberPosition { get; }

        int AccountNumberLength { get; }

        int? Check1Position { get; }

        int Check1Length { get; }

        int? Check2Position { get; }

        int Check2Length { get; }

        int? Check3Position { get; }

        int Check3Length { get; }

        string CalculateNationalCheckDigits(string iban);
        
        string CalculateCheck1(string bankCode, string branchCode, string accountNumber);

        string CalculateCheck2(string bankCode, string branchCode, string accountNumber);

        string CalculateCheck3(string bankCode, string branchCode, string accountNumber);
    }
}