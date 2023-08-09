using AplicationNet6.Models;

namespace AplicationNet6.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account?> GetAllAccounts();
        void Save(Account account);
        Account? FindById(long id);
        Account? FindByName(string name);
    }
}
