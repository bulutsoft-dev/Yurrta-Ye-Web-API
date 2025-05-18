// src/YurttaYe.Domain/ValueObjects/Calorie.cs
namespace YurttaYe.Domain.ValueObjects
{
    public class Calorie
    {
        public decimal Value { get; private set; } // Kilokalori (kkal)

        private Calorie() { } // EF Core için

        public Calorie(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("Calorie value cannot be negative", nameof(value));

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Calorie other)
                return Value == other.Value;
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}