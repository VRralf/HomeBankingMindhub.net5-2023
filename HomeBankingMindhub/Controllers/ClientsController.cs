using HomeBankingMindhub.Dtos;
using HomeBankingMindhub.Models;
using HomeBankingMindhub.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeBankingMindhub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClientRepository _clientRepository;
        private AccountsController _accountsController;
        private CardsController _cardsController;
        public ClientsController(IClientRepository clientRepository, AccountsController accountsController, CardsController cardsController)
        {
            _clientRepository = clientRepository;
            _accountsController = accountsController;
            _cardsController = cardsController;
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _clientRepository.GetAllClients();
                var clientsDTO = new List<ClientDTO>();
                foreach(Client client in clients)
                {
                      var clientDTO = new ClientDTO
                      {
                          Id= client.Id,
                          FirstName = client.FirstName,
                          LastName = client.LastName,
                          Email = client.Email,
                          Accounts = client.Accounts.Select(ac=>new AccountDTO
                          {
                              Id = ac.Id,
                              Number = ac.Number,
                              Balance = ac.Balance,
                              CreationDate = ac.CreationDate,
                          }).ToList(),
                          Credits = client.ClientLoans.Select(cl => new ClientLoanDTO
                          {
                              Id = cl.Id,
                              LoanId = cl.LoanId,
                              Name = cl.Loan.Name,
                              Amount = cl.Amount,
                              Payments = int.Parse(cl.Payments),
                          }).ToList(),
                          Cards = client.Cards.Select(ca=> new CardDTO
                          {
                              Id = ca.Id,
                              Number = ca.Number,
                              Type = ca.Type,
                              CardHolder = ca.CardHolder,
                              FromDate = ca.FromDate,
                              ThruDate = ca.ThruDate,
                              Color = ca.Color,
                              Cvv = ca.Cvv,
                          }).ToList(),
                      };
                      clientsDTO.Add(clientDTO);
                }
                return Ok(clientsDTO);

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var client = _clientRepository.FindById(id);
                if(client == null)
                {
                    return NotFound();
                }
                var clientDTO = new ClientDTO
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    Accounts = client.Accounts.Select(ac => new AccountDTO
                    {
                        Id = ac.Id,
                        Number = ac.Number,
                        Balance = ac.Balance,
                        CreationDate = ac.CreationDate,
                        //Transactions = ac.Transactions.Select(tr => new TransactionDTO
                        //{
                        //    Id = tr.Id,
                        //    Amount = tr.Amount,
                        //    Date = tr.Date,
                        //    Description = tr.Description,
                        //    Type = tr.Type
                        //}).ToList()
                    }).ToList(),
                    Credits = client.ClientLoans.Select(cl => new ClientLoanDTO
                    {
                        Id = cl.Id,
                        LoanId = cl.LoanId,
                        Name = cl.Loan.Name,
                        Amount = cl.Amount,
                        Payments = int.Parse(cl.Payments),
                    }).ToList(),
                    Cards = client.Cards.Select(ca => new CardDTO
                    {
                        Id = ca.Id,
                        Number = ca.Number,
                        Type = ca.Type,
                        CardHolder = ca.CardHolder,
                        FromDate = ca.FromDate,
                        ThruDate = ca.ThruDate,
                        Color = ca.Color,
                        Cvv = ca.Cvv,
                    }).ToList(),

                };
                return Ok(clientDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("current")]
        public IActionResult GetCurrent()
        {
            try
            {
                //Obtener el email del usuario logueado o null en su defecto
                string email = User.FindFirst("Client") != null ? User.FindFirst("Client").Value : string.Empty;
                if(email == string.Empty)
                {
                    return Unauthorized();
                }
                Client client = _clientRepository.FindByEmail(email);
                if(client == null)
                {
                    return NotFound();
                }
                var clientDTO = new ClientDTO
                {
                    Id = client.Id,
                    Email = client.Email,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Accounts = client.Accounts.Select(ac => new AccountDTO
                    {
                        Id = ac.Id,
                        Number = ac.Number,
                        Balance = ac.Balance,
                        CreationDate = ac.CreationDate,
                    }).ToList(),
                    Credits = client.ClientLoans.Select(cl => new ClientLoanDTO
                    {
                        Id = cl.Id,
                        LoanId = cl.LoanId,
                        Name = cl.Loan.Name,
                        Amount = cl.Amount,
                        Payments = int.Parse(cl.Payments),
                    }).ToList(),
                    Cards = client.Cards.Select(ca => new CardDTO
                    {
                        Id = ca.Id,
                        Number = ca.Number,
                        Type = ca.Type,
                        CardHolder = ca.CardHolder,
                        FromDate = ca.FromDate,
                        ThruDate = ca.ThruDate,
                        Color = ca.Color,
                        Cvv = ca.Cvv,
                    }).ToList(),
                };
                return Ok(clientDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            try
            {
                //Validamos los datos del cliente
                if(String.IsNullOrEmpty(client.FirstName) || String.IsNullOrEmpty(client.LastName) || String.IsNullOrEmpty(client.Email) || String.IsNullOrEmpty(client.Password))
                {
                    return BadRequest("First Name, Last Name, Email and Password are required");
                }
                //Buscamos si el usuario ya existe
                Client user = _clientRepository.FindByEmail(client.Email);
                if(user != null)
                {
                    return StatusCode(403, "Email está en uso");
                }
                Client newClient = new Client
                {
                    Email = client.Email,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Password = client.Password,
                };
                _clientRepository.Save(newClient);
                var client1 = _clientRepository.FindByEmail(newClient.Email);
                Account newAccount = new Account
                {
                    Number = "VIN" + new Random().Next(10000, 99999).ToString(),
                    Balance = 0,
                    CreationDate = DateTime.Now,
                    ClientId = client1.Id,
                };
                _accountsController.Post(newClient.Id);
                return Created("", newClient);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("current/accounts")]
        public IActionResult PostAccount()
        {
            try
            {
                //Obtener el email del usuario logueado o null en su defecto
                string email = User.FindFirst("Client") != null ? User.FindFirst("Client").Value : string.Empty;
                if (email == string.Empty)
                {
                    return Unauthorized();
                }
                Client client = _clientRepository.FindByEmail(email);
                if (client == null)
                {
                    return NotFound();
                }

                // Preguntamos si tiene menos de 3 cuentas
                if (client.Accounts.Count >= 3)
                {
                    return StatusCode(403, "No puede tener más de 3 cuentas");
                }

                var result = _accountsController.Post(client.Id);
                return result;

                //Account newAccount = new Account
                //{
                //    Number = "VIN" + new Random().Next(10000, 99999).ToString(),
                //    Balance = 0,
                //    CreationDate = DateTime.Now,
                //    ClientId = client.Id,
                //};
                //_accountRepository.Save(newAccount);
                //return Created("", newAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("current/cards")]
        public IActionResult PostCard([FromBody] Card card)
        {
            try
            {
                //Obtener el email del usuario logueado o null en su defecto
                string email = User.FindFirst("Client") != null ? User.FindFirst("Client").Value : string.Empty;
                if (email == string.Empty)
                {
                    return Unauthorized();
                }
                Client client = _clientRepository.FindByEmail(email);
                if (client == null)
                {
                    return NotFound();
                }
                // Contar las tarjetas del mismo tipo
                // mostrar en consola el objeto card
                Console.WriteLine("Tipo: "+ card.Type + " Color: "+ card.Color);
                var cardsTypeCount = client.Cards.Where(c => c.Type == card.Type).Count();
                if(cardsTypeCount > 2)
                {
                    return StatusCode(403, "No puede tener más de 3 tarjetas de este tipo");
                }
                // Tarjeta de este tipo y color
                Card equalCard = client.Cards.Where(c => c.Type == card.Type && c.Color == card.Color).FirstOrDefault();
                if (equalCard != null)
                {
                    return StatusCode(403, "No puede tener más de 1 tarjeta de este color");
                }
                Card newCard = new Card
                {
                    ClientId = client.Id,
                    CardHolder = client.FirstName + " " + client.LastName,
                    Type = card.Type,
                    Color = card.Color,
                };
                var result = _cardsController.Post(newCard);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
