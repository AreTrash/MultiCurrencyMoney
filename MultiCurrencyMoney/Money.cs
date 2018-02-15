using System;

namespace MultiCurrencyMoney
{
    public class Money
    {
        protected int amount;

        private string currency;
        public string Currency => currency;

        public virtual Money Times(int multiplier)
        {
            return new Money(amount * multiplier, Currency);
        }

        public Money(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return amount == money.amount && Currency == money.Currency;
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public override string ToString()
        {
            return $"{amount} {currency}";
        }
    }
}
