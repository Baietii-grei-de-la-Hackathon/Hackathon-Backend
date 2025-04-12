using QubHq_Repo.Enums;

namespace QubHQ_Services.Dtos;

public class TransactionDto
{
    public Guid? Id { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public List<UserDto> UserDtos { get; set; }
    public int TransactionStatusId { get; set; }
    public string Status { get; set; }
    public bool PaidToRestaurant { get; set; }
    public string Passcode { get; set; }
}