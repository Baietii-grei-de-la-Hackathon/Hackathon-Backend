namespace QubHq_Repo.Models;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public Guid? TakenByUserId { get; set; }
    public double Price { get; set; }
}