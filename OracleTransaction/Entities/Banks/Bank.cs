namespace OracleTransaction.Entities.Banks
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; } 
    }
}
