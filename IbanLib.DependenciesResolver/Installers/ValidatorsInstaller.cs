using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IbanLib.Domain;
using IbanLib.Domain.Validators;
using IbanLib.Validators;

namespace IbanLib.DependenciesResolver.Installers
{
    /// <summary>
    ///     Setup the installers.
    /// </summary>
    public class ValidatorsInstaller : IWindsorInstaller
    {
        /// <summary>
        ///     Register components into Castle.
        /// </summary>
        /// <param name="container">
        ///     Container.
        /// </param>
        /// <param name="store">
        ///     Store.
        /// </param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IAccountNumberValidator>()
                    .ImplementedBy<AccountNumberValidator>()
                    .Named(Bootstrapper.RegisteredAccountNumberValidator));

            container.Register(
                Component.For<IBankCodeValidator>()
                    .ImplementedBy<BankCodeValidator>()
                    .Named(Bootstrapper.RegisteredBankCodeValidator));

            container.Register(
                Component.For<IBbanValidator>()
                    .ImplementedBy<BbanValidator>()
                    .Named(Bootstrapper.RegisteredBbanValidator));

            container.Register(
                Component.For<IBranchCodeValidator>()
                    .ImplementedBy<BranchCodeValidator>()
                    .Named(Bootstrapper.RegisteredBranchCodeValidator));

            container.Register(
                Component.For<ICountryCodeValidator>()
                    .ImplementedBy<CountryCodeValidator>()
                    .Named(Bootstrapper.RegisteredCountryCodeValidator));

            container.Register(
                Component.For<IIbanValidator>()
                    .ImplementedBy<IbanValidator>()
                    .Named(Bootstrapper.RegisteredIbanValidator));

            container.Register(
                Component.For<IValidators>()
                    .ImplementedBy<DefaultValidators>()
                    .Named(Bootstrapper.RegisteredDefaultValidators));
        }
    }
}