using HomeBankingMindhub.Models;
using System.Collections.Generic;

namespace HomeBankingMindhub.Repositories
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAllAccounts();
        void Save(Card card);
        Card FindById(long id);
        IEnumerable<Card> GetCardsByClient(long clientId);
    }
}
