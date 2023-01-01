namespace Domain.Core.Domain
{
    using System;
    using System.Collections.Generic;

    public abstract class StrongTypeId<TKey> : ValueObject<StrongTypeId<TKey>> where TKey : notnull
    {
        public StrongTypeId(TKey value)
        {
            if (value.Equals(Guid.Empty))
                throw new ArgumentException("Id must be provided");
            Value = value;
        }

        public TKey Value { get; }
        public static bool operator ==(StrongTypeId<TKey>? left, StrongTypeId<TKey>? right)
        {
            //var comparer = Comparer<TKey>.Default;
            //return comparer.Compare(left.Value ,right.Value) == 0;
            return left is not null && right is not null && Equals(left, right);
        }
        public static bool operator !=(StrongTypeId<TKey>? left, StrongTypeId<TKey>? right)
        {
            //var comparer = Comparer<TKey>.Default;
            //return comparer.Compare(left.Value ,right.Value) != 0;
            return left is not null && right is not null && !Equals(left, right);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

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
