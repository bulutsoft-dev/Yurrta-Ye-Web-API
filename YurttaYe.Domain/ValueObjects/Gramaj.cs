// src/YurttaYe.Domain/ValueObjects/Gramaj.cs
namespace YurttaYe.Domain.ValueObjects
{
    public class Gramaj
    {
        public decimal Value { get; private set; } // Gram veya mililitre
        public string Unit { get; private set; } // g, ml

        private Gramaj() { } // EF Core için

        public Gramaj(decimal value, string unit)
        {
            if (value <= 0)
                throw new ArgumentException("Gramaj value must be positive", nameof(value));
            if (string.IsNullOrWhiteSpace(unit) || (unit != "g" && unit != "ml"))
                throw new ArgumentException("Unit must be 'g' or 'ml'", nameof(unit));

            Value = value;
            Unit = unit;
        }

        public override bool Equals(object obj)
        {
            if (obj is Gramaj other)
                return Value == other.Value && Unit == other.Unit;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Unit);
        }
    }
}