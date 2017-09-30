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
        VendingMachine vendingMachine;

        [SetUp]
        public void SetUp()
        {
            vendingMachine = new VendingMachine();
        }

        [Test]
        public void WhenWeightEnteredReturnsValue()
        {          
            Assert.AreEqual("$0.05", vendingMachine.GetCoinValue(0.176m));
        }

        [Test]
        public void WhenDimeWeightEnteredReturnsValue()
        {
            Assert.AreEqual("$0.10", vendingMachine.GetCoinValue(0.08m));
        }

        [Test]
        public void WhenQuarterWeightEnteredReturnsValue()
        {
            Assert.AreEqual("$0.25", vendingMachine.GetCoinValue(0.2m));
        }

        [Test]
        public void WhenPennyWeightEnteredReturnsCoinToSlot()
        {
            Assert.AreEqual("INSERT COIN", vendingMachine.GetCoinValue(0.088m));
        }

        [Test]
        public void WhenCoinsInsertedReturnTotalInserted()
        {
            Assert.AreEqual("$0.05", vendingMachine.GetCoinValue(0.176m));
            Assert.AreEqual("$0.10", vendingMachine.GetCoinValue(0.176m));
        }

        [Test]
        public void WhenReturnCoinsPressedReturnCoinsToSlot()
        {
            vendingMachine.GetCoinValue(0.176m);
            vendingMachine.GetCoinValue(0.08m);
            Assert.AreEqual("INSERT COIN", vendingMachine.ReturnCoins());
        }

        [Test]
        public void WhenMachineLoadedReturnsProductsLoaded()
        {
            Assert.AreEqual(3, vendingMachine.LoadMachine(1,1,1));
        }

        [Test]
        public void WhenColaSelectedReturnsColaAvailable()
        {
            vendingMachine.LoadMachine(2, 0, 0);
            Assert.AreEqual(2, vendingMachine.ColaInventory());
        }

        [Test]
        public void WhenChipsSelectedReturnsChipsAvailable()
        {
            vendingMachine.LoadMachine(0, 2, 0);
            Assert.AreEqual(2, vendingMachine.ChipsInventory());
        }

        [Test]
        public void WhenCandySelectedReturnsCandyAvailable()
        {
            vendingMachine.LoadMachine(0, 0, 2);
            Assert.AreEqual(2, vendingMachine.CandyInventory());
        }

        [Test]
        public void WhenColaSelectedChecksPrice()
        {
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);

            vendingMachine.LoadMachine(1, 0, 0);

            Assert.AreEqual("THANK YOU", vendingMachine.PurchaseCola());
        }

        [Test]
        public void WhenColaSelectedAndNoMoneyReturnsPrice()
        {
            vendingMachine.LoadMachine(1, 0, 0);
            Assert.AreEqual("PRICE $1.00", vendingMachine.PurchaseCola());
        }

        [Test]
        public void WhenColaAndNoInventoryReturnsSoldOut()
        {
            Assert.AreEqual("SOLD OUT", vendingMachine.PurchaseCola());
        }

        [Test]
        public void WhenChipsSelectedChecksPrice()
        {
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);

            vendingMachine.LoadMachine(0, 1, 0);

            Assert.AreEqual("THANK YOU", vendingMachine.PurchaseChips());
        }

        [Test]
        public void WhenChipsSelectedAndNoMoneyReturnsPrice()
        {
            vendingMachine.LoadMachine(0, 1, 0);
            Assert.AreEqual("PRICE $0.50", vendingMachine.PurchaseChips());
        }

        [Test]
        public void WhenChipsAndNoInventoryReturnsSoldOut()
        {
            Assert.AreEqual("SOLD OUT", vendingMachine.PurchaseChips());
        }

        [Test]
        public void WhenCandySelectedChecksPrice()
        {
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.08m);
            vendingMachine.GetCoinValue(0.176m);

            vendingMachine.LoadMachine(0, 0, 1);

            Assert.AreEqual("THANK YOU", vendingMachine.PurchaseCandy());
        }

        [Test]
        public void ChangeNeededReturnsChange()
        {
            Assert.AreEqual("$0.25", vendingMachine.DispenseChange(0.25m));
        }

        [Test]
        public void WhenExactChangeNeededReturnsExactChange()
        {
            Assert.AreEqual("EXACT CHANGE ONLY", vendingMachine.ExactChange());
        }

        [Test]
        public void ColaBoughtReturnsCorrectInventory()
        {
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);
            vendingMachine.GetCoinValue(0.2m);

            vendingMachine.LoadMachine(2, 0, 0);

            vendingMachine.SelectProduct(1);

            Assert.AreEqual(1, vendingMachine.ColaInventory());
        }
    }
}
