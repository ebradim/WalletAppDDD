namespace Domain.Core.Domain
{
    using System.Collections.Generic;

    public abstract class StrongTypeId<TKey> : ValueObject<StrongTypeId<TKey>> where TKey : notnull
    {
        protected StrongTypeId(TKey value)
        {
            if (value.Equals(Guid.Empty)) throw new ArgumentException("Invalid id");
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public static bool operator ==(StrongTypeId<TKey>? left, StrongTypeId<TKey>? right)
        {
            return EqualOperator(left, right);
        }
        public static bool operator !=(StrongTypeId<TKey>? left, StrongTypeId<TKey>? right)
        {
            return NotEqualOperator(left, right);
        }
        public TKey Value { get; }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TKey>.Default.GetHashCode(Value);
        }
    }
}
