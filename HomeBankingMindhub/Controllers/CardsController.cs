using HomeBankingMindhub.Models;
using HomeBankingMindhub.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HomeBankingMindhub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private ICardRepository _cardRepository;
        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        [HttpPost]
        public IActionResult Post(Card card)
        {
            try
            {
                var newNumberCard = new Random().Next(1000, 9999) + "-" + new Random().Next(1000, 9999) + "-" + new Random().Next(1000, 9999) + "-" + new Random().Next(1000, 9999);
                Card newCard = new Card
                {
                    Number = newNumberCard,
                    ClientId = card.ClientId,
                    Type = card.Type,
                    CardHolder = card.CardHolder,
                    Color = card.Color,
                    Cvv = new Random().Next(100, 999).ToString(),
                    FromDate = DateTime.Now,
                    ThruDate = DateTime.Now.AddYears(5),                    
                };
                _cardRepository.Save(newCard);
                return Created("", newCard);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
