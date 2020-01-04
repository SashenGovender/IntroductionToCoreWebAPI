using System.Collections.Generic;
using CardsLib;

namespace BlackjackLib
{
    public class Player
    {
        // ---------------------------------------------------------------------------------------------------------------
        public List<Card> Cards { get; private set; }
        public int PlayerID { get; private set; }

        public int Score => CalculateScore(); //todo: check if there is a better way to do this

        public bool IsBurst => this.Score > 21;

        // ---------------------------------------------------------------------------------------------------------------
        public Player(List<Card> cards, int playerId)
        {
            Cards = cards;
            PlayerID = playerId;
        }

        // ---------------------------------------------------------------------------------------------------------------
        private int CalculateScore()
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