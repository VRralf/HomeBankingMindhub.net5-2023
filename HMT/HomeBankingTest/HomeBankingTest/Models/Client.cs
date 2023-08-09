using System.Collections;
using System.Collections.Generic;

namespace HomeBankingTest.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        ICollection<Account> Accounts { get; set; }
    }
}
