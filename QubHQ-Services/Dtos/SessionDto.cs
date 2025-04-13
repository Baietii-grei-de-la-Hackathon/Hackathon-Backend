using QubHq_Repo.Models;

namespace QubHQ_Services.Dtos;

public class SessionDto
{
    public Guid Id { get; set; }
    public List<Item>? Items { get; set; }
    public List<string> Users { get; set; }
}