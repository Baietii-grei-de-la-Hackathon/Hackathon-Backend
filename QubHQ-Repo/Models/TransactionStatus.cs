using QubHq_Repo.Enums;

namespace QubHq_Repo.Models;

public class TransactionStatus
{
    public int Id { get; set; }  // Matches enum value
    public string Name { get; set; }  // Matches enum name
    public ICollection<Transaction> Transactions { get; set; }
}