using QubHq_Repo.Enums;

namespace QubHq_Repo.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public List<User> Users { get; set; }
    public int TransactionStatusId { get; set; }
    public TransactionStatus Status { get; set; }
    public bool PaidToRestaurant { get; set; }
    public string Passcode { get; set; }
}   