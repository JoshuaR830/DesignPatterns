using System.Collections;
using System.Collections.Generic;
using Api.Services;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cards")]
    public class CardsController : Controller
    {
        private ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("")]
        public IEnumerable<Card> GetAll()
        {
            return _cardService.FetchCards();
        }
    }
}