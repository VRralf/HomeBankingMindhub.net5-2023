using HomeBankingMindhub.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HomeBankingMindhub.Repositories
{
    //TODO: Implementar la interfaz IClientRepository con los métodos necesarios para que funcione el proyecto.
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(HomeBankingContext repositoryContext) : base(repositoryContext)
        {
        }

        public Client FindById(long id)
        {
            return FindByCondition(client => client.Id == id).Include(cli=>cli.Accounts).FirstOrDefault();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return FindAll().Include(cli=>cli.Accounts).ToList();
        }

        public void Save(Client client)
        {
            Create(client);
            SaveChanges();
        }
    }
}
