namespace MultiCurrencyMoney
{
    public interface IExpression
    {
        Money Reduce(string to);
    }
}