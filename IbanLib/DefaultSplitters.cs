using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Exceptions;

namespace IbanLib
{
    /// <summary>
    /// </summary>
    public class DefaultSplitters : ISplitters
    {
        private readonly IBbanSplitter _bbanSplitter;
        private readonly IIbanSplitter _ibanSplitter;

        /// <summary>
        /// </summary>
        /// <param name="ibanSplitter"></param>
        /// <param name="bbanSplitter"></param>
        /// <exception cref="SplitterException"></exception>
        public DefaultSplitters(IIbanSplitter ibanSplitter, IBbanSplitter bbanSplitter)
        {
            CheckArgument<IIbanSplitter>(ibanSplitter, "ibanSplitter");
            CheckArgument<IBbanSplitter>(bbanSplitter, "bbanSplitter");

            _ibanSplitter = ibanSplitter;
            _bbanSplitter = bbanSplitter;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IIbanSplitter GetIbanSplitter()
        {
            return _ibanSplitter;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IBbanSplitter GetBbanSplitter()
        {
            return _bbanSplitter;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="SplitterException"></exception>
        private static void CheckArgument<T>(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new SplitterException(
                    string.Format(
                        "Argument '{0}' of type '{1}' can not be null.",
                        argumentName,
                        typeof (T)));
            }
        }
    }
}