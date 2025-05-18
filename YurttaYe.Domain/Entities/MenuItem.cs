// src/YurttaYe.Domain/Entities/MenuItem.cs

using System;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public Gramaj Gramaj { get; private set; }
        public Price Price { get; private set; }
        public Calorie Calorie { get; private set; }
        public DateTime Date { get; private set; }
        public int MenuId { get; private set; }
        public Menu Menu { get; private set; }

        private MenuItem() { } // EF Core için

        public MenuItem(string name, string category, Gramaj gramaj, Price price, Calorie calorie, DateTime date)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Gramaj = gramaj ?? throw new ArgumentNullException(nameof(gramaj));
            Price = price;
            Calorie = calorie;
            Date = date;
        }

        public void Update(string name, string category, Gramaj gramaj, Price price, Calorie calorie)
        {
            Name = name ?? Name;
            Category = category ?? Category;
            Gramaj = gramaj ?? Gramaj;
            Price = price ?? Price;
            Calorie = calorie ?? Calorie;
        }
    }
}