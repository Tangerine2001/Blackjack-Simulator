using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackSimulator
{
    class Deck
    {
        Random rand = new Random();
        List<string> suit = new List<string>(new string[]{"S", "H", "C", "D"});
        List<string> rank = new List<string>(new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K"});

        List<string> deck = new List<string>();

        public Deck()
        {
            deck.Add("No cards");
        }

        public Deck(int count)
        {
            deck = createDeck(count);
        }

        public List<string> createDeck(int count)
        {
            List<string> deck = new List<string>();

            for(int i = 0; i < count; i++)
            {
                for(int j = 0; j < suit.Count; j++)
                {
                    for(int k = 0; k < rank.Count; k++)
                    {
                        deck.Add(rank[k] + suit[j]);
                    }
                }
            }

            return deck;        
        }
        public List<string> getCards()
        {
            return deck;
        }

        public string Draw()
        {
            string top = deck[0];
            deck.RemoveAt(0);
            return top;
        }

        public void shuffle()
        {
            //This shuffling method is taken from https://stackoverflow.com/questions/273313/randomize-a-listt
            int n = deck.Count;
            while (n > 0)
            {
                n--;
                int r = rand.Next(n + 1);
                string temp = deck[r];
                deck[r] = deck[n];
                deck[n] = temp;
            }
        }
        

    }
}
