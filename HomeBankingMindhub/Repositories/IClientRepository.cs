using HomeBankingMindhub.Models;
using System.Collections.Generic;

namespace HomeBankingMindhub.Repositories
{
    //TODO: Implementar la interfaz IClientRepository con los métodos necesarios para que funcione el proyecto.
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        void Save(Client client);
        Client FindById(long id);
        Client FindByEmail(string email);
    }
}
