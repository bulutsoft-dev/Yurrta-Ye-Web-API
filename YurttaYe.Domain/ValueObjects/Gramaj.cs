namespace YurttaYe.Domain.ValueObjects
{
    public class Gramaj
    {
        public decimal Value { get; private set; }
        public string Unit { get; private set; }

        private Gramaj() { } // EF Core için

        public Gramaj(decimal value, string unit)
        {
            if (value <= 0) throw new ArgumentException("Gramaj must be positive");
            Value = value;
            Unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }
    }
}