namespace Money.Wallets.Domain
{
    using global::Domain.Core.Domain;
    using System.Collections.Generic;

    public sealed class Currency : ValueObject<Currency>
    {
        public Currency(string code, string symbol)
        {
            Code = code;
            Symbol = symbol;
        }

        public string Code { get; }
        public string Symbol { get; }
        public static Currency EgyptianPound => new("EGP", "L.E");
        public static Currency USDollar => new("USD", "$");
        public static Currency OfCode(string code)
        {
            return code switch
            {
                "EGP" => new(EgyptianPound.Code, EgyptianPound.Symbol),
                "USD" => new(USDollar.Code, USDollar.Symbol),
                _ => throw new NotImplementedException(),
            };
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
            yield return Symbol;
        }
    }
}
