namespace QubHQ_Services.Dtos;

public class ItemDto
{
    public Guid Id { get; set; }
    public Guid TransactionId { get; set; }
    public string Name { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public double Price { get; set; }
}