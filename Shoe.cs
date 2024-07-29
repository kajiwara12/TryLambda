using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TryLambda
{
    public class Shoe
    {
        //fields
        private Card[] cards;
        public bool Shuffled = false;
        private Queue<Card> queue;

        public Shoe(int numberOfDecks) {
            cards = new Card[numberOfDecks*52];
            for (int i = 0; i < numberOfDecks; i++) { 
            Deck deck = new Deck();
              Array.Copy(deck.Cards,0,cards,i*52,deck.Cards.Length);
            }
            queue = new Queue<Card>(cards);
        
        }


    }
}
