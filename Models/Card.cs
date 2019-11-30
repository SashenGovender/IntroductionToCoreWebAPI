using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABasicWebAPI.Models
{
   public enum CardFace
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    };

    public enum CardSuite
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs,
    };


    public class Card
    {
 
        public CardFace Face { get; set; }
        public CardSuite Suite { get; set; }
        public int Value { get; set; }

        public Card(CardFace face, CardSuite suit, int value)
        {
            Suite = suit;
            Face = face;
            Value = value;
        }
    }
}