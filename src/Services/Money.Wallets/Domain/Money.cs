namespace Money.Wallets.Domain
{
    using global::Domain.Core.Domain;
    using System.Collections.Generic;

    public class Money : ValueObject<Money>
    {
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new ArgumentException("You can not sum different currencies");
            return Of(left.Amount+right.Amount, left.Currency);
        }
        public static Money Of(decimal amount,Currency currency)=>new(amount,currency);
        public decimal Amount { get; }
        public Currency Currency { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
