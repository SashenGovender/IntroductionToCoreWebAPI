using System.Collections.Generic;

namespace CardsLib
{
    public class StandardDeck : Deck
    {
        // ---------------------------------------------------------------------------------------------------------------
        public StandardDeck() : base(new List<Card>())
        {
            for (int cardFace = (int)CardFace.Ace; cardFace <= (int)CardFace.King; cardFace++)
            {
                this.AddCard(new Card((CardFace)cardFace, CardSuit.Clubs, cardFace));
                this.AddCard(new Card((CardFace)cardFace, CardSuit.Diamonds, cardFace));
                this.AddCard(new Card((CardFace)cardFace, CardSuit.Hearts, cardFace));
                this.AddCard(new Card((CardFace)cardFace, CardSuit.Spades, cardFace));
            }

            this.Shuffle();
        }
        // ---------------------------------------------------------------------------------------------------------------
    }
}