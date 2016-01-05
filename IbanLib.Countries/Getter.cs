using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Threading;
using IbanLib.Countries.Countries;

namespace IbanLib.Countries
{
    /// <summary>
    ///     Util class for Countries.
    /// </summary>
    public class Getter
    {
        private static readonly Lazy<ConcurrentDictionary<string, Type>> AllCountriesType =
            new Lazy<ConcurrentDictionary<string, Type>>(() => new ConcurrentDictionary<string, Type>(
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsClass
                                && x.Name != typeof (ACountry).Name
                                && x.Namespace == typeof (ACountry).Namespace)
                    .ToDictionary(
                        x => x.Name.ToUpperInvariant(),
                        x => x)),
                LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<ConcurrentDictionary<string, ICountry>> AllCountries =
            new Lazy<ConcurrentDictionary<string, ICountry>>(
                () => new ConcurrentDictionary<string, ICountry>(),
                LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        ///     The method returns the corrispondent implementation of the interface ICountry or null searched bt the Country Code.
        /// </summary>
        /// <param name="countryCode">
        ///     The Country Code requested.
        /// </param>
        /// <returns>
        ///     The implementation of ICountry that corrisponds with the requested country code.
        /// </returns>
        public static ICountry GetCountry(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                return null;
            }

            countryCode = countryCode.ToUpperInvariant();

            ICountry country;
            if (AllCountries.Value.TryGetValue(countryCode, out country))
            {
                return country;
            }

            Type type;
            if (!AllCountriesType.Value.TryGetValue(countryCode, out type))
            {
                return null;
            }

            country = (ICountry) Activator.CreateInstance(type);
            AllCountries.Value.TryAdd(countryCode, country);

            return country;
        }
    }
}