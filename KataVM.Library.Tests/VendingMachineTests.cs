﻿using NUnit.Framework;
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
            Assert.AreEqual("$0.15", vendingMachine.ReturnCoins());
        }
    }
}
