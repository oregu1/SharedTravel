namespace SharedTravel.Models;

public class Category
{
    public int Id { get; set; }
    public CategoryType Type { get; set; }
    public string? CustomName { get; set; }   // заполнено только при Type == Custom
    public string Icon { get; set; } = "";
    public string ColorHex { get; set; } = "#888888";
}