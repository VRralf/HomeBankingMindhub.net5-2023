using Microsoft.AspNetCore.Mvc;
using Test3Net6.DTOs;
using Test3Net6.Repositories;

namespace Test3Net6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clients = _clientRepository.GetAllClients();
            var clientsDTO = clients.Select(cli => new ClientDTO
            {
                Id = cli.Id,
                FirstName = cli.FirstName,
                LastName = cli.LastName,
                Email = cli.Email,
                Phone = cli.Phone,
                Accounts = cli.Accounts.Select(acc => new AccountDTO
                {
                    Id = acc.Id,
                    AccountNumber = acc.AccountNumber,
                    AccountType = acc.AccountType,
                    Balance = acc.Balance
                }).ToList()
            });
            return Ok(clientsDTO);
        }
    }
}
