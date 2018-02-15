using System;
using Xunit;

namespace MultiCurrencyMoney
{
    public class MoneyTest
    {
        [Fact]
        public void Multiplication()
        {
            var five = Money.Dollar(5);
            Assert.Equal(Money.Dollar(10), five.Times(2));
            Assert.Equal(Money.Dollar(15), five.Times(3));
        }

        [Fact]
        public void Equality()
        {
            Assert.True(Money.Dollar(5).Equals(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.False(Money.Dollar(5).Equals(Money.Franc(5)));
        }

        [Fact]
        public void Currency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency);
            Assert.Equal("CHF", Money.Franc(1).Currency);
        }

        [Fact]
        public void SimpleAddition()
        {
            var sum = Money.Dollar(3).Plus(Money.Dollar(4));
            Assert.Equal(Money.Dollar(7), sum);
        }
    }
}