namespace QubHq_Repo.Models;

public class Payer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? AccountId { get; set; }
    public User Account { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public double Amount { get; set; }
    public bool DidPay { get; set; }
}