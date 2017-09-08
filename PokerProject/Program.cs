using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
    class Program
    {
        static void Main(string[] args)
        {

            // a. Create an instance of your CardSet class, and call it myDeck.
            CardSet myDeck = new CardSet();
            // b. Build a loop that does a Console.WriteLine 52 times.
           

            //creating howmanyCard
            int howManyCards = 3;


            //players balance
            int balance = 10;

            //setting the screen color
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to the Poker Game.");
            Console.WriteLine("you have $10 and each bet will be $1.");
            Console.WriteLine("Press any key when you are ready to start.");

            Console.ReadLine();
            while (balance > 0)
            {
                //calling the mehods
                SuperCard[] computerHand = myDeck.GetCards(howManyCards);
                SuperCard[] playersHand = myDeck.GetCards(howManyCards);

                //sorting the card
                Array.Sort(computerHand);
                Array.Sort(playersHand);


                //displaying the cards
                DisplayHands(computerHand, playersHand);

                //setting the colors again
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                //comparing the cards
                Console.WriteLine();
                bool won = CompareHands(computerHand, playersHand);


                

                if (won)
                { Console.WriteLine("Congrats! You won the game");
                balance += 1;
                }
                else
                { Console.WriteLine("Sorry! You lost the game");
                balance -= 1;
                }

                //decreasing the balance
                Console.WriteLine("your new balance is {0}", balance);

                Console.WriteLine("please press Enter to play another round");
                Console.ReadLine();
                
            }
            
            Console.WriteLine("your balance is now zero.");
            

            // end of program
            Console.ReadLine();

        }
        public static void DisplayHands(SuperCard[] computerHand, SuperCard[] playersHand)
        {
            //loop for computer hands
            Console.WriteLine("COMPUTER HANDS");
            foreach (SuperCard card in computerHand)
            {
                card.Display();
                Console.ResetColor();
            }

            //loop for players hands
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PLAYERS HANDS");
            foreach (SuperCard card in playersHand)
            {
                card.Display();
                Console.ResetColor();
            }

        }    //end of display method


        public static bool CompareHands(SuperCard[] computerHand, SuperCard[] playersHand)
        {
            int computerHandTotal = 0;
            int playersHandTotal = 0;
            //adding all the ranks of computer hand
           

            foreach (SuperCard card in computerHand) //see each card
            {
                int cardValue;
                for(int x=0; x<computerHand.Length; x++)  //getting values one by one of each card and add it to computer hand total
                {
                    cardValue=  (int)card.CardRank; //getting the value of rank of each card
                    computerHandTotal += cardValue;
                }
               
            }

            foreach (SuperCard card in playersHand)
            {
                int cardValue;
                for (int x = 0; x <playersHand.Length; x++)
                {
                    cardValue = (int)card.CardRank;
                    playersHandTotal += cardValue;
                }

            }

            //now compare
            if (playersHandTotal > computerHandTotal)
            {
                return true;
            }
            else { return false; }


        }//end of compare method

    }
}
