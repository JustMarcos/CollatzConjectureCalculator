# COLLATZ CONJECTURE CALCULATOR
**Written by: Marcos**

## ABOUT THIS PROGRAM

This app is a console program written on .NET 5 using C#, and was created for fun as an alternative to a "Hello World" program example. It should run on any platform.

This is a simple program to display the number of steps it takes for a given number to reach 1 based on Collatz's Conjecuture.

The program will read a user's input from the console line, and then display the number of steps until the value of n reaches 1. (Assuming the Collatz Conjecture is true. )

***

## Collatz Conjecture Explained

### Statement of the problem (The Rules):      
* _Take any positive integer n._
* _If n is even, divide n by 2. (n/2)_
* _If n is odd, multiply n by 3 and add 1. (3n+1)_
* _Repeat the sequence until n equals 1._ 

### Thus Collatz Conjecture is:
**No matter the starting value of _n_, the sequence will eventually reach 1. 
The value of _n_ will eventually end in a 4,2,1 infinite cycle.**

The Collatz Conjecture is simple to understand, but has yet to be proven or disproven, but it's likely believed to be true. 

***
## Code Overview

Aside from the `Main()` method, there 3 other methods in this program.

1. `Start()` -  This is the starting point and will prompt the user for input.
2. `ValidateInput(string input)` - Validates the user's input and will display the result in the output console window.
3. `ComputeCollatzConjectureSequence(long number)` - The methods run in a `while` loop to compute the sequence of Collatz's Conjecture and print out the result in the console window. 

_**Note:**_ In order to exit the program. The letter "e" must be pressed and entered or just close the console window.

### **How the code works. (Details)** 

**1**. `Start()`
- Prompts the user for input using `Console.ReadLine()`. 
- Calls the method `ValidateInput()` to validate the input. 

**2.** `ValidateInput()`
- Validates the string input, and replaces and commas with an empty string (e.g. 1,000,123 becomes 1000123).
- The method then tries to parse the input into a _long_ number. 
 
```
if (long.TryParse(input, out long number) && number > 0)
```
- There are 2 conditions in the `if` statement. The second condition is preceded with an "AND" operator (`&&`), and thus, if the first condition fails making it `false`, then the second condition will not execute. 
- In other words, the second condition (`&& number > 0`) will not be evaluated so it's safe from an exception being thrown. 
- See the term short-circuiting, or this stackoverflow article: 
https://stackoverflow.com/questions/11358576/will-an-if-statement-stop-evaluating-if-it-fails-the-first-condition%20%20%20%20%20%20%20%20%20%20%20%20%20

- If the parsing is successful, then the method `ComputeCollatzConjectureSequence()` is called to compute the Collatz steps, and then prompts the user again.
- If the parsing fails, then it check if the letter "e" was entered (ignoring upper or lowercase) to see if the program should exit, otherwise it display an error message on the console line, and prompt the user again. 

**3.** `ComputeCollatzConjectureSequence()`

- This is the method that does the work in computing the Collatz steps.
- Inside the `while` loop a ternary conditional operator is used to apply the Collatz logic.
- The ternary operator `?:` is a shorthand of an `if-else` statement. For more information see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
- The code is really simple. It runs in a while loop checking if a number is odd or even, prints out the result to the console line, and increments the "stepCounter". The cycle repeats until the number reaches 1.   

```
long stepCounter = 1;
Console.WriteLine($"Initial Number {number}");

while(number > 1)
{
    number = number % 2 == 0 ? number / 2 : (3 * number) + 1; 
    Console.WriteLine($"Step {stepCounter} Number: {number}");
    stepCounter++;
}
```
### NOTE:
The largest number the _long_ datatype supports is 9,223,372,036,854,775,807. If the number exceeds this, then it will overflow to a negative value and the computation will stop. The largest number this program can handle is 3,074,457,345,618,258,602. 

***
### SIDE NOTE - Fastest way to check if a number is odd or even: 
I'm not sure about effiency of the modulus % operator to check if a number is odd or even. 
This only really matters when dealing with extremely large numbers, or if you're interested in data science.
For the purpose of this project, it's not important. However, I did have a thought if it would be more effienct to look at the last digit of the number, perhaps by looking at the last byte of the number in binary. 

Here is an article on benchmarking this topic published in 2014. It would be interesting if the finding here still hold true today (August 2021). 
https://cc.davelozinski.com/c-sharp/fastest-way-to-check-if-a-number-is-odd-or-even

***