namespace QubHq_Repo.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public Guid TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public double Amount { get; set; }
    public bool DidPay { get; set; }
    public bool IsPayee { get; set; }
}