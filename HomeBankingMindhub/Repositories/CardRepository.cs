using HomeBankingMindhub.Models;
using System.Collections.Generic;

namespace HomeBankingMindhub.Repositories
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(HomeBankingContext repositoryContext) : base(repositoryContext)
        {
        }

        public Card FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Card> GetAllAccounts()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Card> GetCardsByClient(long clientId)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Card card)
        {
            Create(card);
            SaveChanges();
        }
    }
}
