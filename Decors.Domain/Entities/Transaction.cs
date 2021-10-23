namespace Decors.Domain.Entities
{
    public class Transaction: EntityBase
    {
        public string TransactionRef { get; set; }
        public string TransactionStatus { get; set; }
        public decimal Amount { get; set; }
    }
}
