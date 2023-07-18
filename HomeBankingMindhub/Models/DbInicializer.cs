using System;
using System.Linq;

namespace HomeBankingMindhub.Models
{
    public class DbInicializer
    {
        public static void Initialize(HomeBankingContext context)
        {
            if (!context.Clients.Any())
            {
                var Clients = new Client[]
                {
                    new Client{FirstName="Eduardo",LastName="Mendoza",Email="vrralf@gmail.com",Password="123456" },
                    new Client{FirstName="Pepito",LastName="Perez",Email="mail@mail.com",Password="123456"}
                };

                foreach (var client in Clients)
                {
                    context.Clients.Add(client);
                }
            }


            if(!context.Accounts.Any())
            {
                var myAccount = context.Clients.FirstOrDefault(c=>c.Email=="vrralf@gmail.com");
                if (myAccount!=null)
                {
                    var Accounts = new Account[]
                    {
                        new Account{ClientId=myAccount.Id,CreationDate=DateTime.Now,Number=string.Empty,Balance=0}
                    };
                    foreach (var account in Accounts)
                    {
                        context.Accounts.Add(account);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
