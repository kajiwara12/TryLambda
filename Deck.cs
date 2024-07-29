using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryLambda
{
    public class Deck
    {
        public Card[] Cards = new Card[52];

        public Deck()
        {
            int cardNumber = 0;
            foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards[cardNumber]= new Card(rank,suit);
                    cardNumber++;
                }
            }
        }
        public Card[] GetCards() { 
            return Cards;
        }
    }
}
