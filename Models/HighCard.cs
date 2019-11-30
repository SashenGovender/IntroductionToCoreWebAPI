using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//A Simple High card game that will deal one card to each player. the player with the highest card wins
namespace ABasicWebAPI.Models
{
    public class HighCard
    {
        private BaseDeck mDeck;
        public HighCard()
        {
            mDeck = new StandardDeck();
            mDeck.ShuffleDeck();
        }

        public Card Deal()
        {
            return mDeck.GetTopCard();
        }
    }
}