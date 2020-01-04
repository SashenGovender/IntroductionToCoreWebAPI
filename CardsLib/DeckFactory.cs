namespace CardsLib
{
    // ---------------------------------------------------------------------------------------------------------------
    public enum DeckType
    {
        Standard,
    };

    // ---------------------------------------------------------------------------------------------------------------
    public static class DeckFactory
    {
        public static Deck CreateDeck(DeckType type)
        {
            switch (type)
            {
                case DeckType.Standard: return new StandardDeck();
            }

            return new StandardDeck(); ;
        }
    }
    // ---------------------------------------------------------------------------------------------------------------
}