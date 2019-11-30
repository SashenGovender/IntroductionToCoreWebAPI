using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABasicWebAPI.Models
{
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public class BaseDeck
    {
        private List<Card> mCards;

        public BaseDeck()
        {
            mCards = new List<Card>();
        }
        public void AddCard(ref Card card)
        {
            mCards.Add(card);
        }
        public Card GetTopCard()
        {
            Card card = mCards.ElementAt(mCards.Count - 1);
            mCards.RemoveAt(mCards.Count - 1);

            return card;
        }
        public void ShuffleDeck()
        {
            Random rand = new Random();
            for (int iterations = 1; iterations <= 5; iterations++)
            {
                for (int k = 0; k < mCards.Count; k++)
                {
                    int randNum1 = rand.Next(0, mCards.Count);
                    int randNum2 = rand.Next(0, mCards.Count);

                    if (randNum1 != randNum2)
                    {
                        Card temp = mCards[randNum1];
                        mCards[randNum1] = mCards[randNum2];
                        mCards[randNum2] = temp;
                    }
                }
            }
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------------

    public class StandardDeck : BaseDeck
    {
        public StandardDeck()
        {
            for (int cardFace = (int)CardFace.Ace; cardFace <= (int)CardFace.King; cardFace++)
            {
                for (int cardSuite = (int)CardSuite.Hearts; cardSuite <= (int)CardSuite.Clubs; cardSuite++)
                {
                    int value = cardFace;
                    if ((CardFace)cardFace >= CardFace.Jack && (CardFace)cardFace <= CardFace.King)
                    {
                        value = 10;
                    }
                    Card card = new Card((CardFace)cardFace, (CardSuite)cardSuite, value);
                 
                    AddCard(ref card);
                }
            }

        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------------------------------------------------


}