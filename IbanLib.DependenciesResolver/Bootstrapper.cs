using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace IbanLib.DependenciesResolver
{
    /// <summary>
    ///     Bootstrapper class to initializate the IoC.
    /// </summary>
    public static class Bootstrapper
    {
        # region Naming for installers

        public const string RegisteredDefaultCountryResolver = "IbanLib.DefaultCountryResolver";

        public const string RegisteredBbanSplitter = "IbanLib.Splitters.BbanSplitter";
        public const string RegisteredIbanSplitter = "IbanLib.Splitters.IbanSplitter";

        public const string RegisteredAccountNumberValidator = "IbanLib.Validators.AccountNumberValidator";
        public const string RegisteredBankCodeValidator = "IbanLib.Validators.BankCodeValidator";
        public const string RegisteredBbanValidator = "IbanLib.Validators.BbanValidator";
        public const string RegisteredBranchCodeValidator = "IbanLib.Validators.BranchCodeValidator";
        public const string RegisteredCountryCodeValidator = "IbanLib.Validators.CountryCodeValidator";
        public const string RegisteredIbanValidator = "IbanLib.Validators.IbanValidator";
        public const string RegisteredDefaultValidators = "IbanLib.DefaultValidators";

        # endregion

        #region Boot methods

        /// <summary>
        ///     Bootstrap the IoC.
        /// </summary>
        /// <returns>
        ///     Returns a configured IoC.
        /// </returns>
        public static IWindsorContainer Boot()
        {
            return GetContainer(FromAssembly.InThisApplication());
        }

        /// <summary>
        ///     Bootstrap the IoC.
        /// </summary>
        /// <param name="folder">
        ///     Folder into which installers are searched.
        /// </param>
        /// <returns>
        ///     Returns a configured IoC.
        /// </returns>
        public static IWindsorContainer Boot(string folder)
        {
            return GetContainer(FromAssembly.InDirectory(new AssemblyFilter(folder)));
        }

        /// <summary>
        ///     Bootstrap the IoC.
        /// </summary>
        /// <param name="installers">
        ///     Installers to configure the IoC.
        /// </param>
        /// <returns>
        ///     Returns a configured IoC.
        /// </returns>
        private static IWindsorContainer GetContainer(params IWindsorInstaller[] installers)
        {
            return new WindsorContainer().Install(installers);
        }

        # endregion
    }
}