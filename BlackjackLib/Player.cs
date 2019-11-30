using System.Collections.Generic;

namespace BlackjackLib
{
    public class Player
    {
        // ---------------------------------------------------------------------------------------------------------------
        public readonly List<Card> Cards;
        public int PlayerID { get; private set; }

        // ---------------------------------------------------------------------------------------------------------------
        public Player(List<Card> cards, int playerId)
        {
            Cards = cards;
            PlayerID = playerId;
        }

        // ---------------------------------------------------------------------------------------------------------------
        public int Score()
        {
            int sum = 0;
            bool hasAce11InSum = false;
            foreach (var card in this.Cards)
            {
                int cardValue = card.Value > 10 ? 10 : card.Value;
                if (card.FaceValue == CardFace.Ace && sum + 11 <= 21)
                {
                    cardValue = 11;
                    hasAce11InSum = true;
                }
                sum += cardValue;
                if ((sum > 21) && hasAce11InSum)
                {
                    sum -= 10;
                    hasAce11InSum = false;
                }
            }

            return sum;
        }

        // ---------------------------------------------------------------------------------------------------------------
        public void AddCard(Card card)
        {
            if (card != null)
            {
                this.Cards.Add(card);
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
    }
}