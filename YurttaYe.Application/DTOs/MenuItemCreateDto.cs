// src/YurttaYe.Application/DTOs/MenuItemCreateDto.cs
namespace YurttaYe.Application.DTOs
{
    public class MenuItemCreateDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal GramajValue { get; set; }
        public string GramajUnit { get; set; } // "g" veya "ml"
        public decimal? PriceValue { get; set; }
        public string PriceCurrency { get; set; } = "TRY";
        public decimal? CalorieValue { get; set; }
    }
}