// src/YurttaYe.Domain/ValueObjects/CalorieRange.cs
namespace YurttaYe.Domain.ValueObjects
{
    public class CalorieRange
    {
        public Calorie Min { get; private set; }
        public Calorie Max { get; private set; }

        private CalorieRange() { } // EF Core için

        public CalorieRange(Calorie min, Calorie max)
        {
            if (min == null || max == null)
                throw new ArgumentNullException("Min and Max calorie cannot be null");
            if (min.Value > max.Value)
                throw new ArgumentException("Min calorie cannot be greater than Max calorie");

            Min = min;
            Max = max;
        }

        public override bool Equals(object obj)
        {
            if (obj is CalorieRange other)
                return Min.Equals(other.Min) && Max.Equals(other.Max);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Min, Max);
        }
    }
}