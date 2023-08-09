namespace Test3Net6.Models
{
    public class DbInicializer
    {
        public static void Initialize(MyContext context)
        {
            if (!context.Clients.Any())
            {
                // create a new client and save in the database
                context.Add(new Client
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "mail@mail.com",
                    Phone = "",
                });
                
                context.Add(new Client
                {
                    FirstName = "John2",
                    LastName = "Doe2",
                    Email = "",
                    Phone = "",
                });
            }

            if (!context.Accounts.Any())
            {
                var client = context.Clients.FirstOrDefault(c => c.Email == "mail@mail.com");
                if (client != null)
                {
                    context.Add(new Account
                    {
                        ClientId = client.Id,
                        AccountNumber = "123456789",
                        Balance = 1000,
                        AccountType = "",
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
