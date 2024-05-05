namespace OracleTransaction.Entities.Users;

public class UserCard : BaseEntity
{
    public Guid UserId { get; set; }
    public User Users { get; set; } = new User();
    public string Name { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public double Balance {  get; set; }
}
