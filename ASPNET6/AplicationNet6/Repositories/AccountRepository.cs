using AplicationNet6.Models;

namespace AplicationNet6.Repositories
{
    public class AccountRepository : RepositoryBase<Account> ,IAccountRepository
    {
        public AccountRepository(MyContext myContext) : base(myContext)
        {
        }

        public Account? FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Account? FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account?> GetAllAccounts()
        {
            return GetAll();
        }

        public void Save(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
