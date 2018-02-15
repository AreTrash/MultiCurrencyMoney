using System;

namespace MultiCurrencyMoney
{
    public abstract class Money
    {
        protected int amount;

        protected string currency;
        public string Currency => currency;

        public abstract Money Times(int multiplier);

        public Money(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return amount == money.amount && GetType() == money.GetType();
        }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }
    }

    public class Dollar : Money
    {
        public Dollar(int amount, string currency) : base(amount, currency)
        {
        }
        
        public override Money Times(int multiplier)
        {
            return Money.Dollar(amount * multiplier);
        }
    }

    public class Franc : Money
    {
        public Franc(int amount, string currency) : base(amount, currency)
        {
        }
        
        public override Money Times(int multiplier)
        {
            return Money.Franc(amount * multiplier);
        }
    }
}
