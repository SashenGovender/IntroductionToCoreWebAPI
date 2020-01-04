using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum PlayResult
{
    PlayerBurst,
    DealerBurst,
    PlayerBlackjack,
    DealerBlackjack,
    BlackjackDraw,
    PlayerBeatDealer,
    DealerBeatPlayer,
    Draw,
    Unknown,
}

namespace BlackjackLib
{
    public class Blackjack : IBlackjack
    {
        private const int BlackjackWin = 21;
        public const int DealerId = 0;

        // ---------------------------------------------------------------------------------------------------------------
        public Player Dealer { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Deck> CardDeck { get; private set; }

        // ---------------------------------------------------------------------------------------------------------------
        public Blackjack(List<Deck> cardDeck, List<Player> players, Player dealer)
        {
            CardDeck = cardDeck;
            Players = players;
            Dealer = dealer;
        }

        // ---------------------------------------------------------------------------------------------------------------
        public void Deal()
        {
            foreach (var player in this.Players)
            {
                if (player.Cards != null)
                {
                    player.AddCard(GetCard());
                    player.AddCard(GetCard());
                }
            }

            Dealer.AddCard(GetCard());
            Dealer.AddCard(GetCard());
        }

        // ---------------------------------------------------------------------------------------------------------------
        public void Hit(int playerId)
        {
            if (playerId == Blackjack.DealerId)
            {
                while (this.Dealer.Score <= 17)
                {
                    this.Dealer.AddCard(GetCard());
                }
            }
            else
            {
                this.Players.First(player => player.PlayerID == playerId).AddCard(GetCard());
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        public PlayResult EvaluateHand(int playerId)
        {
            int playerScore = this.Players.First(player => player.PlayerID == playerId).Score;
            int dealerScore = this.Dealer.Score;

            if (playerScore > BlackjackWin)
            {
                return PlayResult.PlayerBurst;
            }
            else if (dealerScore > BlackjackWin)
            {
                return PlayResult.DealerBurst;
            }
            else if (playerScore == BlackjackWin && dealerScore == BlackjackWin)
            {
                return PlayResult.BlackjackDraw;
            }
            else if (playerScore == BlackjackWin)
            {
                return PlayResult.PlayerBlackjack;
            }
            else if (dealerScore == BlackjackWin)
            {
                return PlayResult.DealerBlackjack;
            }
            else if (playerScore > dealerScore)
            {
                return PlayResult.PlayerBeatDealer;
            }
            else if (playerScore < dealerScore)
            {
                return PlayResult.DealerBeatPlayer;
            }
            else if (playerScore == dealerScore)
            {
                return PlayResult.Draw;
            }
            else
            {
                return PlayResult.Unknown;
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        private Card GetCard()
        {
            if (this.CardDeck.Count == 0)
            {
                throw new Exception("No Cards in Card Deck");
            }

            Random rand = new Random();
            int deckNumber = rand.Next(0, this.CardDeck.Count);
            Card card = this.CardDeck[deckNumber].GetCard();

            if (this.CardDeck[deckNumber].Cards.Count == 0)
            {
                this.CardDeck.RemoveAt(deckNumber);
            }

            return card;
        }

        // ---------------------------------------------------------------------------------------------------------------
        //add a comment about only using this to restore state
        public Card GetCard(int id)
        {
            if (this.CardDeck.Count == 0)
            {
                throw new Exception("No Cards in Card Deck");
            }

            foreach (var deck in this.CardDeck)
            {
                Card card = deck.GetCard(id);
                if (card != null)
                {
                    if (deck.Cards.Count == 0)
                    {
                        this.CardDeck.Remove(deck);
                    }
                    return card;
                }
            }

            return null;
        }
    }
}