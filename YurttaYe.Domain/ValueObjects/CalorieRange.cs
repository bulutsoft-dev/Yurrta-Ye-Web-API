namespace YurttaYe.Domain.ValueObjects
{
    public class CalorieRange
    {
        public Calorie Min { get; private set; }
        public Calorie Max { get; private set; }

        private CalorieRange() { } // EF Core için

        public CalorieRange(Calorie min, Calorie max)
        {
            Min = min ?? throw new ArgumentNullException(nameof(min));
            Max = max ?? throw new ArgumentNullException(nameof(max));
            if (min.Value > max.Value) throw new ArgumentException("Min calorie cannot be greater than max");
        }
    }
}