namespace Money.Wallets.Domain.Events
{
    using global::Domain.Core.Domain;

    public record class WalletUpdated : IDomainEvent
    {
        private WalletUpdated(string name, string description, decimal amount, string currencyCode)
        {
            Name = name;
            Description = description;
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public string CurrencyCode { get; private set; }

        public static WalletUpdated Create(string name,string description, decimal amount, string currencyCode)
        {
            return new(name, description, amount, currencyCode);
        }

    }
}
