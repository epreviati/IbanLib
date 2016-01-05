using System.Text.RegularExpressions;

namespace IbanLib
{
    /// <summary>
    /// </summary>
    internal class Util
    {
        /// <summary>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Normalize(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }

            var strUpperInvariant = str.ToUpperInvariant();
            var strWithoutDashes = Regex.Replace(strUpperInvariant, @"-+", string.Empty);
            var strWithoutSpaces = Regex.Replace(strWithoutDashes, @"\s+", string.Empty);
            return strWithoutSpaces;
        }
    }
}