namespace AplicationNet6.Models
{
    public class DbInicializer
    {
        public static void Initialize(MyContext context)
        {
            if(!context.Clients.Any())
            {
                context.Add(new Client
                {
                    Name = "Eduardo",
                    Email = "mail@mail.com",
                });
            }

            if(!context.Accounts.Any())
            {
                var client = context.Clients.FirstOrDefault(c => c.Email == "mail@mail.com");
                if(client != null)
                {
                    context.Add(new Account
                    {
                        Name = "VIN001",
                        Balance = 1000,
                        ClientId = client.Id,
                    });
                }
            }
            context.SaveChanges();
        }
    }
}
