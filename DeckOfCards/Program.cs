using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public static Random rand = new Random();
    class Card{
        public string stringVal;
        public string sult;
        public int val;
    }
    class Deck{
        public List<Card> cards;
        public Deck(){
            cards = new List<Card>();
            string[] stringVal_kind = {"Ace", 2, 3, 4, 5, 6, 7, 8, 9, 10, "Jack", "Queen", "King"};
            string[] sult_kind = {"Clubs", "Spades", "Hearts", "Diamonds"};
            string[] stringVal_kind = {"Ace", 2, 3, 4, 5, 6, 7, 8, 9, 10, "Jack", "Queen", "King"};
            for(int i=0;i<stringVal_kind.Length;i++){
                for(int a=0;a<sult_kind.Length;a++){
                    cards.Add(new Card(stringVal_kind[i],sult_kind[a],i+1));
                }
            }
        }
        public topMost(){
            cardReturn = cards[0];
            cards.Remove(cards[0]);
            return cardReturn;
        }
        public reset(){
            Deck();
        }
        public shuffle(){
            for(int i=0;i<cards.Count;i++){
                int new_idx = rand.Next(0,cards.Count);
                Card temp = cards[i];
                cards[i] = cards[new_index];
                cards[new_index] = temp;
            }
        }
    }
}
