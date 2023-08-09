using AplicationNet6.DTOs;
using AplicationNet6.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicationNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountRepository.GetAllAccounts();
            var accountsDTO = accounts.Select(acc => new AccountDTO
            {
                Id = acc.Id,
                Balance = acc.Balance,
            });
            return Ok(accountsDTO);
        }
    }
}
