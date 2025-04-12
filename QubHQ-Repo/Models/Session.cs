namespace QubHq_Repo.Models;

public class Session
{
    public Guid Id { get; set; }
    public List<Item> Items { get; set; }
    public List<string> Users { get; set; }
}