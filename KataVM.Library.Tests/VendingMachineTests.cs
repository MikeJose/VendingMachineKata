using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVM.Library.Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        [Test]
        public void WhenWeightEnteredReturnsValue()
        {
            VendingMachine vendingMachine = new VendingMachine();

            Assert.AreEqual("$0.05", vendingMachine.GetCoinValue(0.176m));
        }
    }
}
