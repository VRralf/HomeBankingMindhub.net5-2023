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
    public class AccountsController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var accounts = _accountRepository.GetAllAccounts();
                var accountsDTO = new List<AccountDTO>();
                foreach (Account account in accounts)
                {
                    var accountDTO = new AccountDTO
                    {
                        Id = account.Id,
                        Number = account.Number,
                        Balance = account.Balance,
                        CreationDate = account.CreationDate,
                        Transactions = account.Transactions.Select(acc => new TransactionDTO
                        {
                            Id = acc.Id,
                            Amount = acc.Amount,
                            Date = acc.Date,
                            Description = acc.Description,
                            Type = acc.Type
                        }).ToList()
                    };
                    accountsDTO.Add(accountDTO);
                }
                return Ok(accountsDTO);
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
                var account = _accountRepository.FindById(id);
                if (account == null)
                {
                    return NotFound();
                }
                var accountDTO = new AccountDTO
                {
                    Id = account.Id,
                    Number = account.Number,
                    Balance = account.Balance,
                    CreationDate = account.CreationDate,
                    Transactions = account.Transactions.Select(acc => new TransactionDTO
                    {
                        Id = acc.Id,
                        Amount = acc.Amount,
                        Date = acc.Date,
                        Description = acc.Description,
                        Type = acc.Type
                    }).ToList()
                };
                return Ok(accountDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
