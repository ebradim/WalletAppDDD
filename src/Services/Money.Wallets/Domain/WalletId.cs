namespace Money.Wallets.Domain
{
    using global::Domain.Core.Domain;

    public sealed class WalletId : StrongTypeId<Guid>
    {
        public static WalletId Of(Guid value) => new(value);
        public WalletId(Guid value) : base(value)
        {
        }
    }
}
