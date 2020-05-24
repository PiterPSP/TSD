using System;
using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;

namespace Account.Test
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void SeedIncrement_Test()
        {
            var a0 = new Account();
            var a1 = new Account();
            var a2 = new Account();
            Assert.AreEqual(2, actual: Int32.Parse(a2.Number) - Int32.Parse(a0.Number));
            Assert.AreEqual(1, actual: Int32.Parse(a1.Number) - Int32.Parse(a0.Number));
            Assert.AreEqual(1, actual: Int32.Parse(a2.Number) - Int32.Parse(a1.Number));
        }

        [Test]
        public void EmptyConstructor_Test()
        {
            var a = new Account();
            Assert.AreEqual(0, a.Balance);
            Assert.AreEqual("", a.Owner);
        }

        [Test]
        public void Deposit_Test()
        {
            var a = new Account();
            a.Deposit(69);
            Assert.AreEqual(69, a.Balance);
        }

        [Test]
        public void NotEmptyConstructor_Test()
        {
            var a = new Account("name1", 69);
            Assert.AreEqual(69, a.Balance);
            Assert.AreEqual("name1", a.Owner);
        }

        [Test]
        public void DepositException_Test()
        {
            var a = new Account();
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                    a.Deposit(-69);
                }
            );
        }

        [Test]
        public void Withdraw_Test()
        {
            var a = new Account("", 69);
            a.Withdraw((decimal) 6.9);
            Assert.AreEqual(62.1, a.Balance);
        }

        [Test]
        public void WithDrawExceptionOutOfRange_Test()
        {
            var a = new Account("", 69);
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                    a.Withdraw(-69);
                }
            );
        }

        [Test]
        public void WithDrawExceptionInvalidOperation_Test()
        {
            var a = new Account("", 69);
            Assert.Throws<InvalidOperationException>(() => {
                    a.Withdraw(666);
                }
            );
        }
    }
}