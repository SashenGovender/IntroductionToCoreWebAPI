using System;
using System.Collections.Generic;
using BlackjackLib;
using IntroductionToCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToCoreWebAPI.Controllers
{
    // [Route("api/[controller]/[action]/{id?}")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlackjackController : ControllerBase
    {
        // ---------------------------------------------------------------------------------------------------------------
        public Blackjack BlackjackGame { get; private set; }

        // ---------------------------------------------------------------------------------------------------------------
        public BlackjackController()
        {
            InitialiseBlackjackGame();
        }

        // ---------------------------------------------------------------------------------------------------------------
        private void InitialiseBlackjackGame()
        {
            Deck standardDeck1 = DeckFactory.CreateDeck(DeckType.Standard);
            Deck standardDeck2 = DeckFactory.CreateDeck(DeckType.Standard);
            const int dealerID = 0;
            BlackjackGame = new Blackjack(new List<Deck>() { standardDeck1, standardDeck2 }, new List<Player>(), new Player(new List<Card>(), dealerID));
        }

        // ---------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("Deal")]
        //[ResponseType(typeof(Card))]
        public ActionResult<Card> Deal(int numberOfPlayers)
        {
            if (numberOfPlayers <= 0)
            {
                return BadRequest(new ErrorResult(1, "Negative Number of Players"));
            }
            Card card = null;//highCardGame.Deal();
            //return 5;
            return card;
        }

        // GET api/play

        [HttpGet]
        //[Route("api/play")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/play/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/play
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/play/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/play/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
