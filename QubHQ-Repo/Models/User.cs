using Microsoft.AspNetCore.Identity;

namespace QubHq_Repo.Models;

public class User : IdentityUser
{
    public string Name { get; set; }
    public string Iban { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Payer> Payees { get; set; }
    
}