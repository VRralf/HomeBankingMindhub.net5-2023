using AplicationNet6.Models;
using System.Text.Json.Serialization;

namespace AplicationNet6.DTOs
{
    public class ClientDTO
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<AccountDTO>? Accounts { get; set; }
    }
}
