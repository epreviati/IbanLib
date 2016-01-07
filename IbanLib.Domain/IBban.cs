namespace IbanLib.Domain
{
    /// <summary>
    ///     IBban interface that determines the structrue of the BBAN.
    /// </summary>
    public interface IBban
    {
        string CheckDigits1 { get; set; }

        string BankCode { get; set; }

        string BranchCode { get; set; }

        string CheckDigits2 { get; set; }

        string AccountNumber { get; set; }

        string CheckDigits3 { get; set; }

        /// <summary>
        ///     Return the rappresentation of the BBAN in a string.
        /// </summary>
        /// <returns>
        ///     The BBAN.
        /// </returns>
        string Value();
    }
}