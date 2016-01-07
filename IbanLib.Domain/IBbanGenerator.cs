using IbanLib.Countries;
using IbanLib.Domain.Splitters;

namespace IbanLib.Domain
{
    /// <summary>
    /// </summary>
    public interface IBbanGenerator
    {
        /// <summary>
        /// </summary>
        /// <param name="country"></param>
        /// <param name="bban"></param>
        /// <param name="validators"></param>
        /// <param name="splitter"></param>
        /// <returns></returns>
        IBban NewBban(ICountry country, string bban, IValidators validators, IBbanSplitter splitter);
    }
}