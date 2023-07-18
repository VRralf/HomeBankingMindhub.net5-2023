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
                        new Account{ClientId=myAccount.Id,CreationDate=DateTime.Now,Number="VIN001",Balance=0}
                    };
                    foreach (var account in Accounts)
                    {
                        context.Accounts.Add(account);
                    }
                }
            }

            if (!context.Transactions.Any())
            {
                var myAccount = context.Accounts.FirstOrDefault(c => c.Number == "VIN001");
                if (myAccount != null)
                {
                    var Transactions = new Transaction[]
                    {
                        //Datos de prueba para la cuenta VIN001
                        new Transaction { AccountId = myAccount.Id, Amount = 10000, Description = "Transferencia recibida", Date = DateTime.Now.AddHours(-5), Type = TransactionType.CREDIT.ToString() },
                        new Transaction { AccountId = myAccount.Id, Amount = -2000, Description = "Compra en Mercado Libre", Date = DateTime.Now.AddHours(-4), Type = TransactionType.DEBIT.ToString() },
                        new Transaction { AccountId = myAccount.Id, Amount = -5000, Description = "Pago de impuestos", Date = DateTime.Now.AddHours(-3), Type = TransactionType.DEBIT.ToString() },
                    };
                    foreach (var transaction in Transactions)
                    {
                        context.Transactions.Add(transaction);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
