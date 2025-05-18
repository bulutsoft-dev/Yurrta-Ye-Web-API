// src/YurttaYe.Domain/Entities/Menu.cs

using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Domain.Entities
{
    public class Menu
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string DayOfWeek { get; private set; }
        public CalorieRange TotalCalorie { get; private set; }
        public List<MenuItem> Items { get; private set; } = new List<MenuItem>();

        private Menu() { } // EF Core için

        public Menu(DateTime date, string dayOfWeek, CalorieRange totalCalorie)
        {
            if (date == default)
                throw new ArgumentException("Date cannot be default", nameof(date));
            if (string.IsNullOrWhiteSpace(dayOfWeek))
                throw new ArgumentException("DayOfWeek cannot be empty", nameof(dayOfWeek));

            Date = date;
            DayOfWeek = dayOfWeek;
            TotalCalorie = totalCalorie ?? throw new ArgumentNullException(nameof(totalCalorie));
        }

        public void AddItem(MenuItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            Items.Add(item);
        }

        public void RemoveItem(int itemId)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
                Items.Remove(item);
        }

        public void UpdateTotalCalorie(CalorieRange totalCalorie)
        {
            TotalCalorie = totalCalorie ?? throw new ArgumentNullException(nameof(totalCalorie));
        }
    }
}