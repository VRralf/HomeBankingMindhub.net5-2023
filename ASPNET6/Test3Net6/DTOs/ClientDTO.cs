using Test3Net6.Models;

namespace Test3Net6.DTOs
{
    public class ClientDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<AccountDTO> Accounts { get; set; }
    }
}
