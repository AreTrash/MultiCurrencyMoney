namespace MultiCurrencyMoney
{
    public class Sum : IExpression
    {
        public Money augend;
        public Money addend;

        public Sum(Money augend, Money addend)
        {
            this.augend = augend;
            this.addend = addend;
        }

        public Money Reduce(string to)
        {
            var amount = augend.amount + addend.amount;
            return new Money(amount, to);
        }
    }
}