namespace YurttaYe.Domain.ValueObjects
{
    public class Calorie
    {
        public decimal Value { get; private set; }

        private Calorie() { } // EF Core için

        public Calorie(decimal value)
        {
            if (value < 0) throw new ArgumentException("Calorie cannot be negative");
            Value = value;
        }
    }
}