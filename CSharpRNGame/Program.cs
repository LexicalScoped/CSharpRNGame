using System;
using System.Collections.Generic;

namespace CSharpRNGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int turns = 10;
            const int maxRand = 100;
            const int minRand = 1;
            Random RNG = new Random();
            int randomNumber = RNG.Next(minRand, maxRand+1);

            int turnCounter = turns;
            bool gameState = true;

            List<int> guesses = new List<int>();

            while (gameState)
            {
                Console.WriteLine("\nYou have {0} turns remaining", turnCounter);
                Console.Write("Previous Guesses: ");
                foreach (int item in guesses)
                {
                    Console.Write("{0} ", item);
                }
                Console.Write("\nPlease Pick a Number between 1 and 100: ");
                string input = Console.ReadLine();
                bool validInput = true;
                int guess;
                if (!Int32.TryParse(input, out guess))
                {
                    Console.WriteLine("Invalid Number!");
                    validInput = false;
                    continue;
                }
                if (guess < minRand || guess > maxRand)
                {
                    Console.WriteLine("Number is outside of guessing range");
                    validInput = false;
                    continue; 
                }

                if (validInput)
                {
                    turnCounter--;
                    guesses.Add(guess);

                    if (guess > randomNumber) { Console.WriteLine("Your guess {0} is higher then the Random Number", guess); }
                    if (guess < randomNumber) { Console.WriteLine("Your guess {0} is lower then the Random Number", guess); }
                    if (guess == randomNumber)
                    {
                        Console.WriteLine("Congratulations! Your Guess ({0}) matches the Random Number ({1})", guess, randomNumber);
                        gameState = false;
                        break;
                    }
                }
                if (turnCounter == 0)
                {
                    Console.WriteLine("Game Over: You have run out of turns!");
                    gameState = false;
                    break;
                }

            }

        }
    }
}
