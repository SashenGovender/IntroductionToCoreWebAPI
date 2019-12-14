﻿using System;
using System.Collections.Generic;
using System.Linq;
using BlackjackData;
using BlackjackData.Models;
using BlackjackLib;
using IntroductionToCoreWebAPI.Models;
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

        private readonly IBlackjackData _blackjackPlayerData;

        // ---------------------------------------------------------------------------------------------------------------
        public BlackjackController(IBlackjackData blackjackPlayerData)
        {
            _blackjackPlayerData = blackjackPlayerData;

            InitialiseBlackjackGame();
        }

        // ---------------------------------------------------------------------------------------------------------------
        private void InitialiseBlackjackGame()
        {
            Deck standardDeck1 = DeckFactory.CreateDeck(DeckType.Standard);
            Deck standardDeck2 = DeckFactory.CreateDeck(DeckType.Standard);

            BlackjackGame = new Blackjack(new List<Deck>() { standardDeck1, standardDeck2 }, new List<Player>(), new Player(new List<Card>(), Blackjack.DealerId));
        }

        // ---------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("Deal/{numberOfPlayers}")]
        public ActionResult<string> Deal(int numberOfPlayers)
        {
            if (numberOfPlayers <= 0)
            {
                return BadRequest(new ErrorResult(1, "Negative Number of Players"));
            }

            for (int players = 0; players < numberOfPlayers; players++)
            {
                this.BlackjackGame.Players.Add(new Player(new List<Card>(), players + 1));
            }

            this.BlackjackGame.Deal();

            var dealResponse = new
            {
                Dealer = this.BlackjackGame.Dealer,
                Players = this.BlackjackGame.Players,
            };

            //Store the State
            _blackjackPlayerData.AddPlayerSessionInformation(new PlayerSessionData()
            {
                PlayerCards = string.Join(";", dealResponse.Dealer.Cards), 
                PlayerId = dealResponse.Dealer.PlayerID, 
                Score = dealResponse.Dealer.Score, 
                SessionId = Guid.NewGuid().ToString(),
            });


            return JsonConvert.SerializeObject(dealResponse);
        }

        // ---------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("Hit/{playerId}")]
        public ActionResult<string> Hit(int playerId)
        {
            //todo: need to check if valid playerID. ie 90000 is not valid
            //todo: need some sort of restore game state
            //  sets the deck, player
            if (playerId < 0)
            {
                return BadRequest(new ErrorResult(1, "Negative Number of Players"));
            }

            //*****************Temp code to test Hit
            for (int players = 0; players < 2; players++)
            {
                this.BlackjackGame.Players.Add(new Player(new List<Card>(), players + 1));
            }
            this.BlackjackGame.Deal();
            //*****************Temp code to test Hit

            this.BlackjackGame.Hit(playerId);

            if (playerId == Blackjack.DealerId)
            {
                //todo: need store state
                var result = new
                {
                    Dealer = this.BlackjackGame.Dealer,
                    GameResult = this.BlackjackGame.Players.Select(player => new
                    {
                        PlayerId = player.PlayerID,
                        PlayerResult = this.BlackjackGame.EvaluateHand(player.PlayerID)
                    })
                };

                return JsonConvert.SerializeObject(result);
            }
            else
            {
                //todo: need store state
                return JsonConvert.SerializeObject(this.BlackjackGame.Players.FirstOrDefault(player => player.PlayerID == playerId));
            }

        }



        // ---------------------------------------------------------------------------------------------------------------
        //// GET api/play

        //[HttpGet]
        ////[Route("api/play")]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/play/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/play
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/play/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/play/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
