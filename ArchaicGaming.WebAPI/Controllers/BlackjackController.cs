using System;
using System.Collections.Generic;
using System.Linq;
using ArchaicGaming.WebAPI.GameManager;
using ArchaicGaming.WebAPI.Models;
using BlackjackData;
using BlackjackLib;
using CardsLib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArchaicGaming.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlackjackController : ControllerBase
    {

        // ---------------------------------------------------------------------------------------------------------------
        public Blackjack BlackjackGame { get; private set; }

        private readonly BlackjackGameSessionManager _gameSessionManager;

        // ---------------------------------------------------------------------------------------------------------------
        public BlackjackController(IBlackjackData blackjackPlayerData)
        {
            _gameSessionManager = new BlackjackGameSessionManager(blackjackPlayerData);

            InitialiseBlackjackGame();
        }

        // ---------------------------------------------------------------------------------------------------------------
        private void InitialiseBlackjackGame()
        {
            Deck standardDeck1 = DeckFactory.CreateDeck(DeckType.Standard);
            Deck standardDeck2 = DeckFactory.CreateDeck(DeckType.Standard);

            BlackjackGame = new Blackjack(
                new List<Deck>()
                {
                    standardDeck1, standardDeck2
                },
                new List<Player>(),
                new Player(new List<Card>(), Blackjack.DealerId));
        }

        // ---------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("Deal/{numberOfPlayers}")]
        public ActionResult<string> Deal(int numberOfPlayers)
        {
            //Valid the number of players
            if (numberOfPlayers <= 0)
            {
                return BadRequest(new ErrorResult(1, "Negative Number of Players"));
            }

            //Initialise the player hands for the game
            for (int players = 0; players < numberOfPlayers; players++)
            {
                this.BlackjackGame.Players.Add(new Player(new List<Card>(), players + 1));
            }
            // carry out the deal
            this.BlackjackGame.Deal();

            //Store the State
            _gameSessionManager.SaveGameState(this.BlackjackGame);

            //create the response to send to the client
            var dealResponse = new
            {
                Dealer = this.BlackjackGame.Dealer,
                Players = this.BlackjackGame.Players,
            };
            return JsonConvert.SerializeObject(dealResponse);
        }

        // ---------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("Hit/{playerId}")]
        public ActionResult<string> Hit(int playerId)
        {
            //todo: need to check if valid playerID. ie 90000 is not valid
            if (playerId < 0)
            {
                return BadRequest(new ErrorResult(1, "Negative Number of Players"));
            }

            _gameSessionManager.RestoreGameState(this.BlackjackGame);

            this.BlackjackGame.Hit(playerId);

            //if normal player then return result for just that player
            if (playerId != Blackjack.DealerId)
            {
                var playerData = this.BlackjackGame.Players.FirstOrDefault(player => player.PlayerID == playerId);
                _gameSessionManager.UpdateGameState(playerData);

                return JsonConvert.SerializeObject(playerData);
            }

            //if dealer hit then proceed to evaluate all hands
            var result = new
            {
                Dealer = this.BlackjackGame.Dealer,
                GameResult = this.BlackjackGame.Players.Select(player => new
                {
                    PlayerId = player.PlayerID,
                    PlayerResult = this.BlackjackGame.EvaluateHand(player.PlayerID)
                })
            };

            //todo: need store state
            return JsonConvert.SerializeObject(result);
        }


        // ---------------------------------------------------------------------------------------------------------------


        // ---------------------------------------------------------------------------------------------------------------

    }
}
