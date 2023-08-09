﻿using AplicationNet6.Models;

namespace AplicationNet6.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client?> GetAllClients();
        void Save(Client client);
        Client? FindById(long id);
        Client? FindByEmail(string email);
    }
}
