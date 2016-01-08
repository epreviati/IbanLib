namespace IbanLib.Countries
{
    /// <summary>
    ///     ICountry interface that defines the structure of a Country and the defines all the methods to calculate the Check
    ///     Codes.
    /// </summary>
    public interface ICountry
    {
        /// <summary>
        ///     Name of the Country.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     ISO3166 code of the Country (EG: "GB", "DE", "IT", "ES", ...)
        /// </summary>
        string Iso3166 { get; }

        /// <summary>
        ///     Define the structure of the Bank Code of the Country.
        /// </summary>
        string BankCodeStructure { get; }

        /// <summary>
        ///     Define the position in the IBAN to the Bank Code of the Country.
        /// </summary>
        int BankCodePosition { get; }

        /// <summary>
        ///     Define the lenght of the Bank Code of the Country.
        /// </summary>
        int BankCodeLength { get; }

        /// <summary>
        ///     Define the lenght that the Bank Code of the Country could have to make a payment.
        ///     (EG: GB -> BankCode.Length = 4 but to make a Faster Payment the BankCode.Length = 0)
        /// </summary>
        int? BankCodeSecondaryLengthForPayment { get; }

        /// <summary>
        ///     Define the structure of the Branch Code of the Country.
        /// </summary>
        string BranchCodeStructure { get; }

        /// <summary>
        ///     Define the position in the IBAN to the Branch Code of the Country.
        /// </summary>
        int? BranchCodePosition { get; }

        /// <summary>
        ///     Define the lenght of the Branch Code of the Country.
        /// </summary>
        int BranchCodeLength { get; }

        /// <summary>
        ///     Define the structure of the Account Number of the Country.
        /// </summary>
        string AccountNumberStructure { get; }

        /// <summary>
        ///     Define the position in the IBAN to the Account Number of the Country.
        /// </summary>
        int AccountNumberPosition { get; }

        /// <summary>
        ///     Define the lenght of the Account Number of the Country.
        /// </summary>
        int AccountNumberLength { get; }

        /// <summary>
        ///     Define the structure of the BBAN of the Country.
        /// </summary>
        string BbanStructure { get; }

        /// <summary>
        ///     Define the lenght of the BBAN of the Country.
        /// </summary>
        int BbanLength { get; }

        /// <summary>
        ///     Define the structure of the IBAN of the Country.
        /// </summary>
        string IbanStructure { get; }

        /// <summary>
        ///     Define the lenght of the IBAN of the Country.
        /// </summary>
        int IbanLength { get; }

        /// <summary>
        ///     Define if the Country belongs or not to the SEPA area.
        /// </summary>
        bool IsSepa { get; }

        /// <summary>
        ///     Define the length of the IBAN National ID length of the Country.
        /// </summary>
        int IbanNationalIdLength { get; }

        /// <summary>
        ///     Starting position of the Account Number of the IBAN that is used to make a SWIFT payment.
        /// </summary>
        int SwiftAccountNumberPosition { get; }

        /// <summary>
        ///     Length of the Account Number of the IBAN that is used to make a SWIFT payment.
        /// </summary>
        int SwiftAccountNumberLength { get; }

        /// <summary>
        ///     Define the eventually position to the Check Code 1.
        /// </summary>
        int? Check1Position { get; }

        /// <summary>
        ///     Define the lenght of the Check Code 1.
        /// </summary>
        int Check1Length { get; }

        /// <summary>
        ///     Define the eventually position to the Check Code 2.
        /// </summary>
        int? Check2Position { get; }

        /// <summary>
        ///     Define the lenght of the Check Code 2.
        /// </summary>
        int Check2Length { get; }

        /// <summary>
        ///     Define the eventually position to the Check Code 3.
        /// </summary>
        int? Check3Position { get; }

        /// <summary>
        ///     Define the lenght of the Check Code 3.
        /// </summary>
        int Check3Length { get; }

        /// <summary>
        ///     The method permits to calculate the National Check Digits for an IBAN.
        /// </summary>
        /// <param name="iban">
        ///     Iban to calculate the National Check Digits.
        /// </param>
        /// <returns>
        ///     The National Check Digits.
        /// </returns>
        string CalculateNationalCheckDigits(string iban);

        /// <summary>
        ///     The method permits to calculate the Check Code 1 for an IBAN starting from the Bank Account, Branch Account and
        ///     Account Number.
        /// </summary>
        /// <param name="bankCode">
        ///     Bank Code to calculate the Check Code 1.
        /// </param>
        /// ///
        /// <param name="branchCode">
        ///     Branch Code to calculate the Check Code 1.
        /// </param>
        /// ///
        /// <param name="accountNumber">
        ///     Account Number to calculate the Check Code 1.
        /// </param>
        /// <returns>
        ///     The Check Code 1.
        /// </returns>
        string CalculateCheck1(string bankCode, string branchCode, string accountNumber);

        /// <summary>
        ///     The method permits to calculate the Check Code 2 for an IBAN starting from the Bank Account, Branch Account and
        ///     Account Number.
        /// </summary>
        /// <param name="bankCode">
        ///     Bank Code to calculate the Check Code 2.
        /// </param>
        /// ///
        /// <param name="branchCode">
        ///     Branch Code to calculate the Check Code 2.
        /// </param>
        /// ///
        /// <param name="accountNumber">
        ///     Account Number to calculate the Check Code 2.
        /// </param>
        /// <returns>
        ///     The Check Code 2.
        /// </returns>
        string CalculateCheck2(string bankCode, string branchCode, string accountNumber);

        /// <summary>
        ///     The method permits to calculate the Check Code 3 for an IBAN starting from the Bank Account, Branch Account and
        ///     Account Number.
        /// </summary>
        /// <param name="bankCode">
        ///     Bank Code to calculate the Check Code 3.
        /// </param>
        /// ///
        /// <param name="branchCode">
        ///     Branch Code to calculate the Check Code 3.
        /// </param>
        /// ///
        /// <param name="accountNumber">
        ///     Account Number to calculate the Check Code 3.
        /// </param>
        /// <returns>
        ///     The Check Code 3.
        /// </returns>
        string CalculateCheck3(string bankCode, string branchCode, string accountNumber);
    }
}