// src/YurttaYe.Domain/Entities/MenuItem.cs

using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; } // Çorba, Ana Yemek, Yan Yemek, Salata/Tatlı, Ek Ürün
        public Gramaj Gramaj { get; private set; }
        public Price? Price { get; private set; } // Opsiyonel, bazı öğeler ücretsiz olabilir (örneğin, Su)
        public Calorie? Calorie { get; private set; } // Opsiyonel, kalori bilgisi her zaman olmayabilir

        private MenuItem() { } // EF Core için

        public MenuItem(string name, string category, Gramaj gramaj, Price? price = null, Calorie? calorie = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty", nameof(category));

            Name = name;
            Category = category;
            Gramaj = gramaj ?? throw new ArgumentNullException(nameof(gramaj));
            Price = price;
            Calorie = calorie;
        }

        public void Update(string name, string category, Gramaj gramaj, Price? price = null, Calorie? calorie = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty", nameof(category));

            Name = name;
            Category = category;
            Gramaj = gramaj ?? throw new ArgumentNullException(nameof(gramaj));
            Price = price;
            Calorie = calorie;
        }
    }
}