using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OracleTransaction.Entities.Users;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    [Required]
    [Index(IsUnique = true)]
    public string  PhoneNumber { get; set; } = string.Empty;
    public double Balance { get; set; }
    public List<UserCard> UserCards { get; set; }
}
