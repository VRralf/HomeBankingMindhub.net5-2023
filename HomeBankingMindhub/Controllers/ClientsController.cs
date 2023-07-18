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
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
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
                              CreationDate = ac.CreationDate
                          }).ToList()
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
                    return Forbid();
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
                        CreationDate = ac.CreationDate
                    }).ToList()
                };
                return Ok(clientDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
