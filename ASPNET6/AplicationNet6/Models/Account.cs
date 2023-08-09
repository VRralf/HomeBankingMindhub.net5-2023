namespace AplicationNet6.Models
{
    public class Account
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public Client Client { get; set; }
        public long ClientId { get; set; }

    }
}
