using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs
{
    public class SortCards
    {
        IDictionary<string, int> numSort = new Dictionary<string, int>() {
            { "2", 1 }, { "3", 2 }, { "4", 3 }, {"5", 4 }, { "6", 5 }, 
            { "7", 6 }, { "8", 7 }, { "9", 8 }, { "10", 9 }, { "J", 10 },
            { "Q", 11 }, { "K", 12 }, { "A", 13 }
        };

        IList<Suits> suitSort = new List<Suits>() { Suits.Diamonds, Suits.Spades, 
            Suits.Clubs, Suits.Hearts };

        public IList<string> SortCardList(IList<string> cardList)
        {
            if (cardList.Count == 0)
                throw new ArgumentException($"Card list is invalid.");

            IList<string> diamonds = new List<string>();
            IList<string> spades = new List<string>();
            IList<string> clubs = new List<string>();   
            IList<string> hearts = new List<string>(); 

            foreach (string card in cardList)
            {
                if (card.Contains('d'))
                    diamonds.Add(card);
                else if (card.Contains('s'))
                    spades.Add(card);
                else if (card.Contains('c'))
                    clubs.Add(card);
                else if (card.Contains('h'))
                    hearts.Add(card);
                else
                    throw new Exception($"Card invalid: {card}");
            }

            diamonds = SortByNumber(diamonds);
            spades = SortByNumber(spades);  
            clubs = SortByNumber(clubs);
            hearts = SortByNumber(hearts); 

            return SortBySuit(diamonds, spades, clubs, hearts);
        }

        private IList<string> SortByNumber(IList<string> cards)
        {
            return cards.OrderBy(card => {
                var cardNumber = card.Remove(card.Length - 1);
                return numSort[cardNumber];
            }).ToList();
        }

        private IList<string> SortBySuit(IList<string> diamonds, IList<string> spades, IList<string> clubs, IList<string> hearts)
        {
            IList<string> sortedCards = new List<string>();

            foreach (Suits suit in suitSort)
            {
                if (suit.Equals(Suits.Diamonds))
                    sortedCards = sortedCards.Concat(diamonds).ToList();
                else if (suit.Equals(Suits.Spades))
                    sortedCards = sortedCards.Concat(spades).ToList();
                else if (suit.Equals(Suits.Clubs))
                    sortedCards = sortedCards.Concat(clubs).ToList();
                else if (suit.Equals(Suits.Hearts))
                    sortedCards = sortedCards.Concat(hearts).ToList();
                else
                    throw new Exception($"Suit invalid: {suit}");
            }

            return sortedCards;
        }

    }
}
