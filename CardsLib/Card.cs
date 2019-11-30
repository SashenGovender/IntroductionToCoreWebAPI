namespace BlackjackLib
{
    public class Card
    {
        // ---------------------------------------------------------------------------------------------------------------
        public CardFace FaceValue { get; private set; }
        public CardSuit Suit { get; private set; }
        public int Value { get; private set; }

        // ---------------------------------------------------------------------------------------------------------------
        public Card(CardFace faceValue, CardSuit suit, int value)
        {
            FaceValue = faceValue;
            Suit = suit;
            Value = value;
        }

        // ---------------------------------------------------------------------------------------------------------------
    }
}
