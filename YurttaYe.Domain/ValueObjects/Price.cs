// src/YurttaYe.Domain/ValueObjects/Price.cs
namespace YurttaYe.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; } = "TRY"; // Varsayılan: Türk Lirası

        private Price() { } // EF Core için

        public Price(decimal value, string currency = "TRY")
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative", nameof(value));
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency cannot be empty", nameof(currency));

            Value = value;
            Currency = currency;
        }

        public override bool Equals(object obj)
        {
            if (obj is Price other)
                return Value == other.Value && Currency == other.Currency;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Currency);
        }
    }
}