using System;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Application.DTOs
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Gramaj Gramaj { get; set; }
        public Price Price { get; set; }
        public Calorie Calorie { get; set; }
        public DateTime Date { get; set; }
    }
}