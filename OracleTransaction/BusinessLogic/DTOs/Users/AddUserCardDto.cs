using OracleTransaction.Entities.Users;

namespace OracleTransaction.BusinessLogic.DTOs.Users;

public class AddUserCardDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public double Balance { get; set; }
}
