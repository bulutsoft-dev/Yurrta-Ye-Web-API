namespace YurttaYe.Application.DTOs
{
    public class MenuItemCreateDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal GramajValue { get; set; }
        public string GramajUnit { get; set; }
        public decimal? PriceValue { get; set; }
        public string PriceCurrency { get; set; } = "TRY";
        public decimal? CalorieValue { get; set; }
        public System.DateTime Date { get; set; }
    }
}