using Test3Net6.Models;

namespace Test3Net6.DTOs
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}