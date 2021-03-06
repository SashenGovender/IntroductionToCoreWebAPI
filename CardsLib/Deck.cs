﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsLib
{
    public class Deck
    {
        // ---------------------------------------------------------------------------------------------------------------
        public readonly List<Card> Cards;

        // ---------------------------------------------------------------------------------------------------------------
        public Deck(List<Card> cards)
        {
            Cards = cards;
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
        public Card GetCard()
        {
            Card card = null;
            int numCards = this.Cards.Count;
            if (numCards > 0)
            {
                card = this.Cards[numCards - 1];
                Cards.RemoveAt(numCards - 1);
            }

            return card;
        }

        // ---------------------------------------------------------------------------------------------------------------
        public Card GetCard(int id)
        {
            int numCards = this.Cards.Count;

            if (numCards <= 0)
                return null;

            bool hasCard = Cards.Exists(c => c.CardId == id);
            if (!hasCard)
                return null;

            Card card = null;
            card = Cards.FirstOrDefault(c => c.CardId == id);
            Cards.Remove(card); // test this

            return card;
        }

        // ---------------------------------------------------------------------------------------------------------------'
        public void Shuffle()
        {
            Random rand = new Random();
            int numCards = this.Cards.Count;
            for (int index = 0; index < numCards; index++)
            {
                int rand1 = rand.Next(0, numCards);
                int rand2 = rand.Next(0, numCards);

                Swap(this.Cards, rand1, rand2);
            }
        }

        // ---------------------------------------------------------------------------------------------------------------
        private static void Swap<T>(IList<T> list, int firstIndex, int secondIndex)
        {
            T tmp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tmp;

        }
        // ---------------------------------------------------------------------------------------------------------------
    }
}