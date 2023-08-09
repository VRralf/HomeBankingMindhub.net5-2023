using Microsoft.EntityFrameworkCore;

namespace AplicationNet6.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
