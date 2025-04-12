using QubHq_Repo.Enums;

namespace QubHq_Repo.Models;

public class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string PayeeId { get; set; }
    public User Payee { get; set; }
    public List<Payer> Payers { get; set; }
    public TransactionStatusEnum Status { get; set; }
}