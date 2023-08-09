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

        public Client FindByEmail(string email)
        {
            return FindByCondition(client => client.Email.ToUpper() == email.ToUpper())
                .Include(cli=>cli.Accounts)
                .Include(cli=>cli.ClientLoans)
                .ThenInclude(cl=>cl.Loan)
                .Include(cli=>cli.Cards)
                .FirstOrDefault();
        }

        public Client FindById(long id)
        {
            return FindByCondition(client => client.Id == id)
                .Include(cli=>cli.Accounts)
                .Include(cli=>cli.ClientLoans)
                    .ThenInclude(cl=>cl.Loan)
                .Include(cli=>cli.Cards)
                .FirstOrDefault();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return FindAll().Include(cli=>cli.Accounts)
                .Include(cli=>cli.ClientLoans)
                .ThenInclude(cl=>cl.Loan)
                .Include(cli => cli.Cards)
                .ToList();
        }

        public void Save(Client client)
        {
            Create(client);
            SaveChanges();
        }
    }
}
