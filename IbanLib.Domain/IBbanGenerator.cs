using IbanLib.Countries;
using IbanLib.Domain.Splitters;

namespace IbanLib.Domain
{
    /// <summary>
    ///     IBbanGenerator interface that defines the method to generate an IBBAN object from the BBAN in string format.
    /// </summary>
    public interface IBbanGenerator
    {
        /// <summary>
        ///     The methods try to split the string BBAN paramente to the corrispondent IBBAN object.
        /// </summary>
        /// <param name="country">
        ///     Country of the BBAN.
        /// </param>
        /// <param name="bban">
        ///     Rappresenation in string of the BBAN.
        /// </param>
        /// <param name="validators">
        ///     Aggregation of all validators required.
        /// </param>
        /// <param name="bbanSplitter">
        ///     Splitter object that permits to split the BBAN string in the IBBAN object.
        /// </param>
        /// <returns>
        ///     The IBBAN splitted object.
        /// </returns>
        IBban NewBban(ICountry country, string bban, IValidators validators, IBbanSplitter bbanSplitter);
    }
}