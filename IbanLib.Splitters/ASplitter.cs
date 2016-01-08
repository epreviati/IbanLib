using IbanLib.Common;

namespace IbanLib.Splitters
{
    /// <summary>
    ///     Abstract ASplitter base class that defines the basically funcionalities for all the splitter classes.
    /// </summary>
    public abstract class ASplitter : AClass
    {
        /// <summary>
        ///     Method that returns a generic error message personalized with the three fields.
        /// </summary>
        /// <param name="fieldName">
        ///     Parameter Field Name.
        /// </param>
        /// <param name="fieldToSplit">
        ///     Parameter Field To split.
        /// </param>
        /// <param name="fieldToExtract">
        ///     Parameter Field To Extract.
        /// </param>
        /// <returns>
        ///     The error message created using the passed parameters.
        /// </returns>
        protected static string GetErrorMessage(string fieldName, string fieldToSplit, string fieldToExtract)
        {
            return string.Format(
                "It is not possible to split the {0} '{1}' to extract the '{2}'.",
                fieldName,
                fieldToSplit,
                fieldToExtract);
        }
    }
}