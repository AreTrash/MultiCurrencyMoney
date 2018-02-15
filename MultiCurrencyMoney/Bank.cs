using System.Collections.Generic;

namespace MultiCurrencyMoney
{
    public class Bank
    {
        struct Pair
        {
            string from;
            string to;

            public Pair(string from, string to)
            {
                this.from = from;
                this.to = to;
            }
        }

        readonly Dictionary<Pair, int> rates = new Dictionary<Pair, int>();
        
        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from == to) return 1;
            return rates[new Pair(from, to)];
        }
    }
}