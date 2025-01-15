namespace TestMVC.Models;

public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int SerialNumberId { get; set; }
    public SerialNumber? SerialNumber { get; set; }
}
