using QubHq_Repo.Enums;
using QubHq_Repo.GenericEnumFunctions;

namespace QubHq_Repo.Models;

public class TransactionStatus : IEnumModel<TransactionStatus, TransactionStatusEnum>
{
    public TransactionStatusEnum Id { get; set; }
    public string Name { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}