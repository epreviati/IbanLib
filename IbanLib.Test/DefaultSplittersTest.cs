using System;
using IbanLib.Domain.Splitters;
using IbanLib.Exceptions;
using IbanLib.Test.Common;
using Moq;
using NUnit.Framework;

namespace IbanLib.Test
{
    public class DefaultSplittersTest
    {
        [Test]
        public void Constructor_Not_Valid_IBbanSplitter_Parameter()
        {
            Action action = () => new DefaultSplitters(
                new Mock<IIbanSplitter>().Object,
                null);

            TestUtil.ExpectedException<SplitterException>(action);
        }

        [Test]
        public void Constructor_Not_Valid_IIbanSplitter_Parameter()
        {
            Action action = () => new DefaultSplitters(
                null,
                new Mock<IBbanSplitter>().Object);

            TestUtil.ExpectedException<SplitterException>(action);
        }

        [Test]
        public void Constructor_Valid()
        {
            new DefaultSplitters(
                new Mock<IIbanSplitter>().Object,
                new Mock<IBbanSplitter>().Object);
        }

        [Test]
        public void Getters_Works_Properly()
        {
            var ibanSplitter = new Mock<IIbanSplitter>().Object;
            var bbanSplitter = new Mock<IBbanSplitter>().Object;

            var validators = new DefaultSplitters(
                ibanSplitter,
                bbanSplitter);

            Assert.IsNotNull(validators.GetIbanSplitter());
            Assert.AreEqual(ibanSplitter, validators.GetIbanSplitter());

            Assert.IsNotNull(validators.GetBbanSplitter());
            Assert.AreEqual(bbanSplitter, validators.GetBbanSplitter());
        }
    }
}