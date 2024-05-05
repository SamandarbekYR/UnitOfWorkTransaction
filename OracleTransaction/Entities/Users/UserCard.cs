namespace OracleTransaction.Entities.Users;

public class UserCard : BaseEntity
{
    public Guid UserId { get; set; }
    public User Users { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public string Balance {  get; set; } = string.Empty;
}
