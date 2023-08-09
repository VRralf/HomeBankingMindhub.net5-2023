using AplicationNet6.DTOs;
using AplicationNet6.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicationNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            var clientsDTO = clients.Select(cli => new ClientDTO
            {
                Id = cli.Id,
                Name = cli.Name,
                Email = cli.Email,
                Accounts = cli.Accounts.Select(acc => new AccountDTO
                {
                    Id = acc.Id,
                    Balance = acc.Balance,
                }).ToList(),
            });
            return Ok(clientsDTO);
        }
    }
}
