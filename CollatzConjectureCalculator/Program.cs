using System;

namespace CollatzConjectureCalculator
{
     /*-------------------------------------------------------------------------
     * THE COLLATZ CONJECTURE:
     *
     *  Take any positive integer n.
     *  If n is even, divide n by 2. (n/2)
     *  If n is odd, multiply n by 3 and add 1. (3n+1)
     *  Repeat the sequence until n equals 1. 
     * 
     * Conjecture:
     * No matter the starting value of n, the sequence will always reach 1. 
     * The value of n will eventually end in a 4,2,1 cycle. 
     * 
     * ------------------------------------------------------------------------
     * Note:
     * This conjecture remains unproven, but it's likely believed to be true. 
     * 
     * ------------------------------------------------------------------------
     * ABOUT THIS PROGRAM
     * This is a simple program that will read a user's input from a console line, and then display the number of steps until the value of n reaches 1. 
     * Example, the number 31 has 106 steps. 
     */

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
            #region Explanation
            //Tries to parse the input into a "long" datatype and stores the value in the variable named "number", if parsing is sucessful. 
            //It also check if the number is greater than 0.

            //Please note, that if the first condition long.TryParse() method fails - returns false, then the second condition of the if statement will not execute.
            //In other words, the code "&& number > 0" will not be evalutated so it's safe from an exception.
            //See the term "short-circuiting" or this Stackoverflow article: https://stackoverflow.com/questions/11358576/will-an-if-statement-stop-evaluating-if-it-fails-the-first-condition 
            #endregion

            //Replace the commas with an empty string.
            input = input.Replace(",", "");

            if (long.TryParse(input, out long number) && number > 0)
            {
                ComputeCollatzConjectureSequence(number);
                Start(); //After computing the sequence, it will prompt the user again for another number or to exit.
            }
            else
            {
                #region Explanation
                //Check if the user wants to exit the program, the letter "e" was type and entered. Ordinal Case is ignored - "e" or "E" are valid to exit the program.
                //Note: The curly braces are not need after the if statement since there is only 1 statement follows that prints out "Exiting Program".
                //However, I always prefer to include the curly braces to prevent a possible bug in the future if more than 1 statement need to be added in the future.
                #endregion

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
            #region Explanation
            //The while loop checks the number is even or odd and applies the Collatz Conjecture rule.
            // If the number is even, then divide by 2.
            // If the number is odd, then multiply by 3 and add 1. 
            // Then repeat the cycle until the number is equal to 1. 
            // The steps are tracked with the counter and the new computed number is printed out in the console window.

            //In the while loop is using the ternary conditional operator ?:
            //It's basically a shorthand version of writing an if-else statement.
            //For more information see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator

            //FINALLY, I'm wasn't quite sure on the effiency of the modulus % operator to check if a number is odd or even. 
            //This is especially true when dealing very large numbers. It might be more effiecent to check the last digit of a given number. 
            //For the purposes of this program it's not important, but it is interesting to think about if you're into data science. 
            //Here is an article on benchmarking this topic published in 2014: 
            //https://cc.davelozinski.com/c-sharp/fastest-way-to-check-if-a-number-is-odd-or-even

            #endregion

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
