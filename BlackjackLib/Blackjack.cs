﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackjackLib
{
    public class Blackjack
    {
        public Player Dealer { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Deck> CardDeck { get; private set; }

        public Blackjack(List<Deck> cardDeck, List<Player> players, Player dealer)
        {
            CardDeck = cardDeck;
            Players = players;
            Dealer = dealer;
        }

        public void Deal()
        {
            foreach (var player in this.Players)
            {
                if (player.Cards != null)
                {
                    player.AddCard(GetCard());
                }
            }

            Dealer.AddCard(GetCard());
            Dealer.AddCard(GetCard());
        }

        public void Hit(int playerId)
        {
            //this.Players.Any(player => player.PlayerID == playerId)
                this.Players.First(player => player.PlayerID == playerId).AddCard(GetCard());
        }

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
    }
}