namespace Test3Net6.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
    }
}
