using YurttaYe.Domain.ValueObjects;

public class MenuItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public Gramaj Gramaj { get; set; }
    public Price? Price { get; set; }
    public Calorie? Calorie { get; set; }
}