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


            if (!context.Accounts.Any())
            {
                var myAccount = context.Clients.FirstOrDefault(c => c.Email == "vrralf@gmail.com");
                if (myAccount != null)
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

            if (!context.Loans.Any())
            {
                //Creamos 3 prestamos, Hipotecario, Personal y Automotríz
                var loans = new Loan[]
                {
                    new Loan { Name="Hipotecario",MaxAmount=500000,Payments="12,24,36,48,60"},
                    new Loan { Name="Personal",MaxAmount=100000,Payments="3,12,24"},
                    new Loan { Name="Automotríz",MaxAmount=300000,Payments="6,12,24,36"},
                };
                foreach (var loan in loans)
                {
                    context.Loans.Add(loan);
                }
            }

            //context.SaveChanges();
            if (!context.ClientLoans.Any())
            {
                var myClient = context.Clients.FirstOrDefault(c => c.Email == "vrralf@gmail.com");
                if (myClient != null)
                {
                    var loan1 = context.Loans.FirstOrDefault(l => l.Name == "Hipotecario");
                    var clientLoan1 = new ClientLoan
                    {
                        Amount = 450000,
                        ClientId = myClient.Id,
                        LoanId = loan1.Id,
                        Payments = "60"
                    };
                    context.ClientLoans.Add(clientLoan1);
                    var loan2 = context.Loans.FirstOrDefault(l => l.Name == "Personal");
                    var clientLoan2 = new ClientLoan
                    {
                        Amount = 55000,
                        ClientId = myClient.Id,
                        LoanId = loan2.Id,
                        Payments = "12"
                    };
                    context.ClientLoans.Add(clientLoan2);
                    var loan3 = context.Loans.FirstOrDefault(l => l.Name == "Automotríz");
                    var clientLoan3 = new ClientLoan
                    {
                        Amount = 150000,
                        ClientId = myClient.Id,
                        LoanId = loan3.Id,
                        Payments = "24"
                    };
                    context.ClientLoans.Add(clientLoan3);
                }
            }

            if (!context.Cards.Any())
            {
                var myClient = context.Clients.FirstOrDefault(c => c.Email == "vrralf@gmail.com");
                if (myClient != null)
                {
                    var cards = new Card[]
                    {
                        new Card
                        {
                            ClientId = myClient.Id,
                            CardHolder = myClient.FirstName + " " + myClient.LastName,
                            Type = CardType.DEBIT.ToString(),
                            Color = CardColor.GOLD.ToString(),
                            Number = "4321-1234-1234-1234",
                            Cvv = "123",
                            FromDate = DateTime.Now,
                            ThruDate = DateTime.Now.AddYears(4)
                        },
                        new Card
                        {
                            ClientId = myClient.Id,
                            CardHolder = myClient.FirstName + " " + myClient.LastName,
                            Type = CardType.CREDIT.ToString(),
                            Color = CardColor.TITANIUM.ToString(),
                            Number = "1234-1234-1234-4321",
                            Cvv = "321",
                            FromDate = DateTime.Now,
                            ThruDate = DateTime.Now.AddYears(5)
                        },
                    };
                    foreach (var card in cards)
                    {
                        context.Cards.Add(card);
                    }
                }
            }


            context.SaveChanges();


        }
    }
}
