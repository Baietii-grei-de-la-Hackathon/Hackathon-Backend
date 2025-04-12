using QubHq_Repo.Enums;

namespace QubHq_Repo.Models;

public class TransactionStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}