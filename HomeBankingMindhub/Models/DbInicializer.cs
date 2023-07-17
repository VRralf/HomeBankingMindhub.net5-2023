using System;
using System.Linq;

namespace HomeBankingMindhub.Models
{
    public class DbInicializer
    {
        public static void Initialize(HomeBankingContext context)
        {
            if(context.Clients.Any()) { return ; }

            var Clients = new Client[]
            {
                new Client{FirstName="Eduardo",LastName="Mendoza",Email="vrralf@gmail.com",Password="123456" },
                new Client{FirstName="Pepito",LastName="Perez",Email="mail@mail.com",Password="123456"}
            };

            foreach (var client in Clients)
            {
                context.Clients.Add(client);
            }

            context.SaveChanges();
        }
    }
}
