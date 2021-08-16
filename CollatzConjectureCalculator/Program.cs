using System;

namespace CollatzConjectureCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        /// <summary>
        /// Prompts the user to enter a number on the console line.
        /// </summary>
        static void Start()
        {
            Console.WriteLine("Please Enter a Number. Or enter \"e\" key to exit.");
            var input = Console.ReadLine();
            ValidateInput(input);
        }

        /// <summary>
        /// Validates the user's input and displays the result on the console.
        /// A valid input will display the steps a number will take to reach the number 1.
        /// Otherwise, and error message will be displayed to user. 
        /// </summary>
        /// <param name="input"></param>
        static void ValidateInput(string input)
        {
            input = input.Replace(",", ""); //Replace the commas with an empty string.

            if (long.TryParse(input, out long number) && number > 0)
            {
                ComputeCollatzConjectureSequence(number);
                Start(); //Prompts the user again for another number or to exit.
            }
            else
            {
                if ("e".Equals(input, StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Exiting Program."); }
                else 
                {
                    Console.WriteLine("Invalid Number. Try again or enter \"e\" to exit."); 
                    Start(); //Prompts the user again to enter a number or to exit.
                }
            }
        }

        /// <summary>
        /// Computes the steps for the Collatz Conjecture sequence and displays the steps on the console line. 
        /// </summary>
        /// <param name="number"></param>
        static void ComputeCollatzConjectureSequence(long number)
        {
            long stepCounter = 1;
            Console.WriteLine($"Initial Number {number}");

            while(number > 1)
            {
                number = number % 2 == 0 ? number / 2 : (3 * number) + 1; 
                Console.WriteLine($"Step {stepCounter} Number: {number}");
                stepCounter++;
            }
        }

    }
}
