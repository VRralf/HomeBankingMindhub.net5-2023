using Test3Net6.Models;

namespace Test3Net6.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client?> GetAllClients();
        void Save(Client client);
        Client? FindById(long id);
        Client? FindByEmail(string email);
    }
}
