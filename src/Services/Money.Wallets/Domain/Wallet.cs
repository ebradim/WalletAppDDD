namespace Money.Wallets.Domain
{
    using global::Domain.Core.Domain;

    public sealed class Wallet: AggregateRoot<WalletId>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Money { get; set; }

    }
}
