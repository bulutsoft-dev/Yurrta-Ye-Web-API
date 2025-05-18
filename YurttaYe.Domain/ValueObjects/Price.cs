namespace YurttaYe.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; }

        private Price() { } // EF Core için

        public Price(decimal value, string currency = "TRY")
        {
            if (value < 0) throw new ArgumentException("Price cannot be negative");
            Value = value;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }
    }
}