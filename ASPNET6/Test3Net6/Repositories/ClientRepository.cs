using Microsoft.EntityFrameworkCore;
using Test3Net6.Models;

namespace Test3Net6.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(MyContext myContext) : base(myContext)
        {
        }

        public Client? FindByEmail(string email)
        {
            return GetByCondition(cli => cli.Email.ToUpper() == email.ToUpper()).Include(cli => cli.Accounts).FirstOrDefault();
        }

        public Client? FindById(long id)
        {
            return GetByCondition(cli => cli.Id == id).Include(cli => cli.Accounts).FirstOrDefault();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return GetAll().Include(cli => cli.Accounts);
        }

        public void Save(Client client)
        {
            Create(client);
        }
    }
}
