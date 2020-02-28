// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary2;
using NUnit.Framework;

namespace NUnit.Tests1
{
    [TestFixture]
    public class VendingMachineTests
    {
        private VendingMachine vm = new VendingMachine();

        [Test]
        public void WhenWrongBillGiven_ThenGetFalseResult()
        {
            //force Error
            Assert.That(vm.ProcessBillOrCoin(99,MoneyTypeEnum.Bill), Is.EqualTo(false));
        }

        [Test]
        public void WhenWrongCoinGiven_ThenGetFalseResult()
        {
            //force Error
            Assert.That(vm.ProcessBillOrCoin(30, MoneyTypeEnum.Coin), Is.EqualTo(false));
        }

        [Test]
        public void WhenCorrectBillGiven_ThenGetTrueResult()
        {
            Assert.That(vm.ProcessBillOrCoin(100, MoneyTypeEnum.Bill), Is.EqualTo(true));
            Assert.That(vm.ProcessBillOrCoin(50, MoneyTypeEnum.Bill), Is.EqualTo(true));
            Assert.That(vm.ProcessBillOrCoin(20, MoneyTypeEnum.Bill), Is.EqualTo(true));
        }

        [Test]
        public void WhenCorrectCoinGiven_ThenGetTrueResult()
        {
            Assert.That(vm.ProcessBillOrCoin(1, MoneyTypeEnum.Coin), Is.EqualTo(true));
            Assert.That(vm.ProcessBillOrCoin(5, MoneyTypeEnum.Coin), Is.EqualTo(true));
            Assert.That(vm.ProcessBillOrCoin(10, MoneyTypeEnum.Coin), Is.EqualTo(true));
            Assert.That(vm.ProcessBillOrCoin(25, MoneyTypeEnum.Coin), Is.EqualTo(true));
            Assert.That(vm.ProcessBillOrCoin(50, MoneyTypeEnum.Coin), Is.EqualTo(true));
        }


        [Test]
        public void WhenSelectWrongProduct_ThenGetFalseResult()
        {
            Assert.That(vm.SelectProduct(ProductEnum.Other), Is.EqualTo(false));
        }

        [Test]
        public void WhenCustomerCancels_ThenGet_WrongRefundAmount()
        {
            Assert.That(vm.CancelOrder(100), Is.LessThan(110));
        }

        [Test]
        public void WhenCustomerCancels_ThenGet_CorrectRefundAmount()
        {
            Assert.That(vm.CancelOrder(100), Is.EqualTo(100));
        }

        [Test]
        public void WhenCustomerSelectProduct_ThenGet_WrongProduct()
        {
            Assert.AreNotEqual(vm.GetProduct(ProductEnum.Coke), ProductEnum.BottledWater);
        }

        [Test]
        public void WhenCustomerSelectProduct_ThenGet_CorrectProduct()
        {
            Assert.AreEqual(vm.GetProduct(ProductEnum.Coke), ProductEnum.Coke);
        }

        [Test]
        public void WhenCustomerPays_ThenGet_WrongChange()
        {
            Assert.AreNotEqual(vm.GetChange(ProductEnum.Coke, 100), 100);
        }

        [Test]
        public void WhenCustomerPays_ThenGet_CorrectChange()
        {
            Assert.AreEqual(vm.GetChange(ProductEnum.Coke, 100), 75);
            Assert.AreEqual(vm.GetChange(ProductEnum.Pepsi, 100), 65);

        }

        [Test]
        public void WhenCustomerPaysExactAmount_ThenGet_ZeroChange()
        {
            var bills = 10;
            var coins = .50;
            var totalPaid = bills + coins;
            Assert.AreEqual(vm.GetChange(ProductEnum.ChewingGum, totalPaid), 0);
        }

        [Test]
        public void WhenCustomerPaysInsufficientAmount_ThenGet_FalseResult()
        {
            var bills = 10;
            var coins = .50;
            var totalPaid = bills + coins;
            Assert.AreEqual(vm.IsPaidAmountSufficient(ProductEnum.Pepsi, totalPaid), false);
        }

        [Test]
        public void WhenCustomerPaysSufficientAmount_ThenGet_TrueResult()
        {
            var bills = 20;
            var coins = .25;
            var totalPaid = bills + coins;
            Assert.AreEqual(vm.IsPaidAmountSufficient(ProductEnum.ChocolateBar, totalPaid), true);
        }

    }


    
}
