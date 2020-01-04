using System;
using System.Collections.Generic;
using System.Linq;
using BlackjackData;
using BlackjackData.Models;
using BlackjackLib;
using CardsLib;

namespace ArchaicGaming.WebAPI.GameManager
{
    public class BlackjackGameSessionManager
    {
        // ---------------------------------------------------------------------------------------------------------------
        private readonly IBlackjackData _blackjackPlayerData;

        public string GameSessionId { get; private set; }

        // ---------------------------------------------------------------------------------------------------------------
        public BlackjackGameSessionManager(IBlackjackData blackjackPlayerData)
        {
            _blackjackPlayerData = blackjackPlayerData;
        }

        // ---------------------------------------------------------------------------------------------------------------
        public void UpdateGameState(Player newPlayerData)
        {
            _blackjackPlayerData.UpdatePlayerSessionInformation(CreatePlayerSessionObject(newPlayerData,GameSessionId));

            _blackjackPlayerData.SaveChangesToDatabase();
        }

        // ---------------------------------------------------------------------------------------------------------------
        public void SaveGameState(Blackjack blackjackGame)
        {
            string gameSessionId = Guid.NewGuid().ToString();
            _blackjackPlayerData.AddPlayerSessionInformation(CreatePlayerSessionObject(blackjackGame.Dealer, gameSessionId));

            foreach (var player in blackjackGame.Players)
            {
                _blackjackPlayerData.AddPlayerSessionInformation(CreatePlayerSessionObject(player, gameSessionId));
            }

            _blackjackPlayerData.SaveChangesToDatabase();
        }

        // ---------------------------------------------------------------------------------------------------------------
        public void RestoreGameState(Blackjack blackjackGame)
        {
            //todo:: find a better way to get the session id
            GameSessionId = _blackjackPlayerData.GetLatestSessionId();

            var gameData = _blackjackPlayerData.GetBySessionId(GameSessionId);

            foreach (var playerSessionData in gameData)
            {
                var cardIds = playerSessionData.PlayerCardIds.Split(';');

                Player player = null;
                if (playerSessionData.PlayerId == Blackjack.DealerId)
                {
                    player = blackjackGame.Dealer;
                }
                else
                {
                    player = new Player(new List<Card>(), playerSessionData.PlayerId); //blackjackGame.Players.First(p => p.PlayerID == playerSessionData.PlayerId);
                    blackjackGame.Players.Add(player);
                }

                foreach (var cardId in cardIds)
                {
                    //todo: find a better way to remove the cards from the blackjack deck
                    player.AddCard(blackjackGame.GetCard(Convert.ToInt32(cardId)));
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        private PlayerSessionData CreatePlayerSessionObject(Player player, string sessionGuid)
        {
            return new PlayerSessionData()
            {
                PlayerCards = string.Join<Card>(";", player.Cards),
                PlayerCardIds = string.Join(";", player.Cards.Select(card => card.CardId)),
                PlayerId = player.PlayerID,
                Score = player.Score,
                SessionId = sessionGuid,
            };
        }

        // ---------------------------------------------------------------------------------------------------------------

        // ---------------------------------------------------------------------------------------------------------------
    }
}