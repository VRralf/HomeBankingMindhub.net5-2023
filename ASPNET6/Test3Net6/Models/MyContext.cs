using Microsoft.EntityFrameworkCore;

namespace Test3Net6.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options){}
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
