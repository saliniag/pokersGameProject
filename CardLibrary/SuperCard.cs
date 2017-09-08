using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{

    public enum Suit
    {
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    public enum Rank
    {
        Deuce = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    public abstract class SuperCard: IComparable<SuperCard>
    {

        public Rank CardRank { get; set; }
        
        public abstract Suit CardSuit { get; }

        public abstract void Display();

        //implementation of compareTo method
        public int CompareTo(SuperCard other)
        {
            if ((int)this.CardSuit > (int)other.CardSuit) 
            {
                return 1;
                
            }
            else if ((int)this.CardSuit < (int)other.CardSuit) 
            {
                return -1;
            }
            //if ((int)this.CardSuit == (int)other.CardSuit)// && ((int)this.CardRank > (int)other.CardRank))
            //{
            //    if ((int)this.CardRank > (int)other.CardRank)
            //    { return 1; }

            //   if ((int)this.CardRank < (int)other.CardRank) { return -1; }

            //   else { return 0; }
                
            //}
            else { return 0; }

        }


    }

    //child classes
   
    public class CardClub : SuperCard
    {
        private Suit Club_CardSuit = Suit.Club;
        //overriding CardSuit property
        public override Suit CardSuit
        {
            get { return Club_CardSuit; }
        }

        public override void Display()
        {
            // Code to Display a club card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♣");
            Console.ResetColor();
        }

        //constructor
        public CardClub(Rank myRank)
        {
            CardRank = myRank;
        }


    }

    public class CardDiamond : SuperCard {
        private Suit Diamond_CardSuit = Suit.Diamond;

        //overriding CardSuit property
        public override Suit CardSuit
        {
            get { return Diamond_CardSuit; }
        }

        public override void Display()
        {
            // Code to Display a diamond card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♦");
            Console.ResetColor();
        }


        //constructor
        public CardDiamond(Rank myRank)
        {
            CardRank = myRank;
        }
    }

    public class CardHeart : SuperCard {
        private Suit Heart_CardSuit = Suit.Heart;

        //overriding CardSuit property
        public override Suit CardSuit
        {
            get { return Heart_CardSuit; }
        }


        public override void Display()
        {
            // Code to Display a heart card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♥");
            Console.ResetColor();
        }


        //constructor
        public CardHeart(Rank myRank)
        {
            CardRank = myRank;
        }
        
    }

    public class CardSpade : SuperCard {

        private Suit Spade_CardSuit = Suit.Spade;

        //overriding CardSuit property
        public override Suit CardSuit
        {
            get { return Spade_CardSuit; }
        }

        public override void Display()
        {
            // Code to Display a Spade card...
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(CardRank + " of " + CardSuit + "s ♠");
            Console.ResetColor();
        }


        //constructor
        public CardSpade(Rank myRank)
        {
            CardRank = myRank;
        }
    }

//end of inherited class spercard

    //creating class CardSet

    public class CardSet
    {
        public SuperCard[] cardArray;

        //instant iating random class\
        Random myRandom = new Random();
        //constructor
        public CardSet()
        {
            cardArray = new SuperCard[52];
            
            

            //looping for CardClub 
            int index2 = 2;
            for (int index1 = 0; index1 < 13; index1++)
            {
                
                cardArray[index1] = new CardClub((Rank)(index2));
                index2 = index2 + 1;
            }

            //looping for cardDiamond
            index2 = 2;
            for (int index1 = 13; index1 < 26; index1++)
            {

                cardArray[index1] = new CardDiamond((Rank)(index2));
                index2 = index2 + 1;
            }

            //looping for cardHeart
            index2 = 2;
            for (int index1 = 26; index1 < 39; index1++)
            {

                cardArray[index1] = new CardHeart((Rank)(index2));
                index2 = index2 + 1;
            }
            //looping for cardSpade
            index2 = 2;
            for (int index1 =39 ; index1 < 52; index1++)
            {

                cardArray[index1] = new CardSpade((Rank)(index2));
                index2 = index2 + 1;
            }   
        }//end of constructor

        public SuperCard[] GetCards(int number)
        {
            SuperCard[] oneHand = new SuperCard[number];
            for (int i = 0; i < number; i++)
            {
                int myNum = myRandom.Next(cardArray.Length);
                oneHand[i] = cardArray[myNum];
                 
            }
            return oneHand; 
               
        }
        
        
    }   

}
 