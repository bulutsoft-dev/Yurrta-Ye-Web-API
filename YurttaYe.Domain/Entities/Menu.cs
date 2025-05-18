using System;
using System.Collections.Generic;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Domain.Entities
{
    public class Menu
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string DayOfWeek { get; private set; }
        public CalorieRange TotalCalorie { get; private set; }
        public List<MenuItem> Items { get; private set; } = new();

        private Menu() { } // EF Core için

        public Menu(DateTime date, string dayOfWeek, CalorieRange totalCalorie)
        {
            Date = date;
            DayOfWeek = dayOfWeek ?? throw new ArgumentNullException(nameof(dayOfWeek));
            TotalCalorie = totalCalorie ?? throw new ArgumentNullException(nameof(totalCalorie));
        }

        public void AddItem(MenuItem item)
        {
            if (item != null)
                Items.Add(item);
        }

        public void Update(DateTime date, string dayOfWeek, CalorieRange totalCalorie)
        {
            Date = date;
            DayOfWeek = dayOfWeek ?? DayOfWeek;
            TotalCalorie = totalCalorie ?? TotalCalorie;
        }
    }
}