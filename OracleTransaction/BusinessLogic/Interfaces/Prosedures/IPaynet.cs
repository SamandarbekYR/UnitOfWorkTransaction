namespace OracleTransaction.BusinessLogic.Interfaces.Prosedures
{
    public interface IPaynet
    {
        ValueTask Paynet(string senderCardNumber, string receiverPhoneNumber, double sendPrice, string bankName);
    }
}
