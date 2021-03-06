﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CardsLib
{
    // ---------------------------------------------------------------------------------------------------------------
    //https://stackoverflow.com/questions/2441290/javascriptserializer-json-serialization-of-enum-as-string
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardSuit
    {
        Hearts = 1,
        Diamonds,
        Clubs,
        Spades
    };

    // ---------------------------------------------------------------------------------------------------------------
    [JsonConverter(typeof(StringEnumConverter))]
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
    }
    // ---------------------------------------------------------------------------------------------------------------
}