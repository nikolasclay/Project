using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            string playerInput;
            string playerName;
            int counter = 0;
            int counter1 = 0;


            Random r = new Random();
            theAnswer = r.Next(1, 21);

            Console.WriteLine("Enter your name: ");
            playerName = Console.ReadLine();

            do
            {
                // get player input


                Console.Write($"{playerName} enter your guess (1-20): ");
                playerInput = Console.ReadLine();
                
               

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))

                {
                    if (playerGuess > 20 || playerGuess < 1)
                    {
                        Console.WriteLine($"{ playerName } your number was not between 1 and 20.");
                        
                    }
                    else if (playerGuess == theAnswer)
                    {
                        Console.WriteLine($"{theAnswer} was the number.  You Win!");
                        break;
                        counter1++;
                        
                    }
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            Console.WriteLine("Your guess was too High!");
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("Your guess was too low!");
                            counter++;
                        }
                    }

                }                
             
                else
                {
                    Console.WriteLine("That wasn't a number!");
                }
                


            } while (true);
            
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
