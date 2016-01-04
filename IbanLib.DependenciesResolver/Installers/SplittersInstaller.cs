using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Splitters;

namespace IbanLib.DependenciesResolver.Installers
{
    /// <summary>
    ///     Setup the installers.
    /// </summary>
    public class SplittersInstaller : IWindsorInstaller
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
                Component.For<IBbanSplitter>()
                    .ImplementedBy<BbanSplitter>()
                    .Named(Bootstrapper.RegisteredBbanSplitter));

            container.Register(
                Component.For<IIbanSplitter>()
                    .ImplementedBy<IbanSplitter>()
                    .Named(Bootstrapper.RegisteredIbanSplitter));

            container.Register(
                Component.For<ISplitters>()
                    .ImplementedBy<DefaultSplitters>()
                    .Named(Bootstrapper.RegisteredDefaultSplitters));
        }
    }
}