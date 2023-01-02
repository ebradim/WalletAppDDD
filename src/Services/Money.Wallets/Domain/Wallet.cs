namespace Money.Wallets.Domain
{
    using global::Domain.Core.Domain;
    using global::Money.Wallets.Domain.Events;

    public sealed class Wallet: AggregateRoot<WalletId>
    {
        private Wallet(string name, string description, Money money)
        {
            Name = name;
            Description = description;
            Money = money;
        }

        public string Name { get;private set; }
        public string Description { get;private set; }
        public Money Money { get; private set; }

        public static Wallet CreateNew(string name,string description, Money money)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentNullException.ThrowIfNullOrEmpty(description, nameof(description));
            ArgumentNullException.ThrowIfNull(money, nameof(money));

            return new(name, description, money);
        }
        public void Update(string name,string description, decimal amount,string currencyCode)
        {
            var @event = WalletUpdated.Create(name, description, amount, currencyCode);
            AppendEvent(@event);
            Apply(@event);
        
        }

        private void Apply(WalletUpdated @event)
        {
            Name = @event.Name;
            Description = @event.Description;
            Money = Money.Of(@event.Amount, Currency.OfCode(@event.CurrencyCode));
        }
    }
}
