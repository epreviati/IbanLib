using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IbanLib.Domain;

namespace IbanLib.DependenciesResolver.Installers
{
    /// <summary>
    ///     Setup the installers.
    /// </summary>
    public class BbanGeneratorInstaller : IWindsorInstaller
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
                Component.For<IBbanGenerator>()
                    .ImplementedBy<DefaultBbanGenerator>()
                    .Named(Bootstrapper.RegisteredBbanSplitter));
        }
    }
}