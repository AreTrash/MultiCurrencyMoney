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
            var bank = new Bank();
            var reduced = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(7), reduced);
        }

        [Fact]
        public void PlusReturensSum()
        {
            var three = Money.Dollar(3);
            var four = Money.Dollar(4);
            
            var res = three.Plus(four);
            var sum = (Sum)res;
            Assert.Equal(three, sum.augend);
            Assert.Equal(four, sum.addend);
        }

        [Fact]
        public void ReduceSum()
        {
            var sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();
            var res = bank.Reduce(sum, "USD");
            Assert.Equal(Money.Dollar(7), res);
        }

        [Fact]
        public void ReduceMoney()
        {
            var bank = new Bank();
            var res = bank.Reduce(Money.Dollar(1), "USD");
            Assert.Equal(Money.Dollar(1), res);
        }

        [Fact]
        public void ReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var res = bank.Reduce(Money.Franc(2), "USD");
            Assert.Equal(Money.Dollar(1), res);
        }

        [Fact]
        public void Rate()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Assert.Equal(2, bank.Rate("CHF", "USD"));
            Assert.Equal(1, bank.Rate("USD", "USD"));
        }
    }
}