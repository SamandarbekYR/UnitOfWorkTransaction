namespace OracleTransaction.BusinessLogic.DTOs.Users
{
    public class AddUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public double Balance { get; set; }
    }
}
