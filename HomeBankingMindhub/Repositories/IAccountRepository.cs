using HomeBankingMindhub.Models;
using System.Collections.Generic;

namespace HomeBankingMindhub.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        void Save(Account account);
        Account FindById(long id);
        IEnumerable<Account> GetAccountByClient(long clientId);
    }
}
