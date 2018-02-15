using System;

namespace MultiCurrencyMoney
{
    public abstract class Money
    {
        protected int amount;

        public abstract Money Times(int multiplier);

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return amount == money.amount && GetType() == money.GetType();
        }

        public static Money Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Money Franc(int amount)
        {
            return new Franc(amount);
        }
    }

    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            this.amount = amount;
        }

        public override Money Times(int multiplier)
        {
            return new Dollar(amount * multiplier);
        }
    }

    public class Franc : Money
    {
        public Franc(int amount)
        {
            this.amount = amount;
        }

        public override Money Times(int multiplier)
        {
            return new Franc(amount * multiplier);
        }
    }
}
