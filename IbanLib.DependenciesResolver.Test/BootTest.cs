using System;
using Castle.Windsor;
using IbanLib.Domain;
using IbanLib.Domain.Splitters;
using IbanLib.Domain.Validators;
using NUnit.Framework;

namespace IbanLib.DependenciesResolver.Test
{
    [TestFixture]
    public class BootTest
    {
        private static void Test_Boot(IWindsorContainer container)
        {
            Assert.IsNotNull(container.Resolve<IBban>());
            Assert.IsNotNull(container.Resolve<ICountryResolver>());
            Assert.IsNotNull(container.Resolve<IIban>());
            Assert.IsNotNull(container.Resolve<IValidators>());
            Assert.IsNotNull(container.Resolve<IBbanSplitter>());
            Assert.IsNotNull(container.Resolve<IIbanSplitter>());
            Assert.IsNotNull(container.Resolve<IAccountNumberValidator>());
            Assert.IsNotNull(container.Resolve<IBankCodeValidator>());
            Assert.IsNotNull(container.Resolve<IBbanValidator>());
            Assert.IsNotNull(container.Resolve<IBranchCodeValidator>());
            Assert.IsNotNull(container.Resolve<ICountryCodeValidator>());
            Assert.IsNotNull(container.Resolve<IIbanValidator>());
        }

        [Test]
        public void Test_Folder_Boot()
        {
            Test_Boot(Bootstrapper.Boot());
        }

        [Test]
        public void Test_Simple_Boot()
        {
            Test_Boot(Bootstrapper.Boot(AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}