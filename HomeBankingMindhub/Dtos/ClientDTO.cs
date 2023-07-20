using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeBankingMindhub.Dtos
{
    public class ClientDTO
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<AccountDTO> Accounts { get; set; }
        public ICollection<ClientLoanDTO> Credits { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}
