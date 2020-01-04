using Newtonsoft.Json;

namespace CardsLib
{
    public class Card
    {
        // ---------------------------------------------------------------------------------------------------------------
        [JsonProperty(PropertyName = "Value")]
        public CardFace FaceValue { get; private set; }

        [JsonProperty(PropertyName = "Suit")]
        public CardSuit Suit { get; private set; }

        //https://www.newtonsoft.com/json/help/html/SerializationAttributes.htm
        [JsonIgnore]
        public int Value { get; private set; }

        [JsonIgnore]
        public int CardId { get; private set; }

        // ---------------------------------------------------------------------------------------------------------------
        public Card(CardFace faceValue, CardSuit suit, int value)
        {
            FaceValue = faceValue;
            Suit = suit;
            Value = value;
            CardId = ((int)suit * 100) + (int)faceValue;
        }

        // ---------------------------------------------------------------------------------------------------------------
        public override string ToString()
        {
            return $"{FaceValue}{Suit}";
        }
        // ---------------------------------------------------------------------------------------------------------------
    }
}
