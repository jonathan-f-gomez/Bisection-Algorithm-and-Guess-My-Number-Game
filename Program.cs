using System;
using System.Collections.Generic;
using System.Linq;


namespace EX_9A
{
    class Program
    {
        public static int[] listArr = { 1,2,3,4,5,6,7,8,9,10};
        public static int[] theHundo = Enumerable.Range(1, 100).ToArray(); 
        public static int[] oneLarge = Enumerable.Range(1,  1000).ToArray();
        public static Random random = new Random();        

        public static void TheGame()
        {
            try
            {
                bool playAgain = true;
                while (playAgain == true)
                {
                    Console.Clear();
                    
                    AskUser();

                    Console.WriteLine("\nPlay again? \n1. Yes \n2. No");
                    var n = Int32.Parse(Console.ReadLine());
                    
                    if (n == 2) playAgain = false;
                    else playAgain = true;
                }
            }
            catch (Exception)
            {
                TheGame();
                throw;
            }
           
        }
        public static void AskUser()
        {
            Console.WriteLine("What game would you like to play?\n\n1. See the bisection algorithm in action" +
                "\n2. Guess the computer number\n3. Computer guess my number");
            try
            {
                int myChoice = int.Parse(Console.ReadLine());
                if(myChoice >= 4 || myChoice <= 0)
                {
                    Console.WriteLine("Please enter a valid response and try again");
                    Console.WriteLine($"\nPlease press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    AskUser();
                }

                switch (myChoice)
                {
                    case 1:
                        BisectionAlgorithm(WhatArray());
                        break;
                    case 2:
                        TheHumanGuess(WhatArray());
                        break;
                    case 3:
                        TheComputerGuess(WhatArray());
                        break;
                }
            }
            catch (FormatException e)
            {                
                Console.WriteLine($"{e.Message} Please enter a valid response and try again");
                Console.WriteLine($"\nPlease press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                AskUser();
                
                throw;
            }
        }
        public static int[] WhatArray()
        {
            Console.WriteLine("\nWhat range would you like to use?\n\n1. 1-10" +
            "\n2. 1-100 \n3. 1-1000");
            try
            {                
               int whichArr = int.Parse(Console.ReadLine());
               if (whichArr > 3 || whichArr <1)
               {
                    int rand = random.Next(1, 4);
                   Console.WriteLine($"\nYou chose a number out of range so we will use option {rand}");
                   whichArr = rand;
               }
               switch (whichArr)
               {
                   case 1:
                       return listArr;
                       break;
                   case 2:
                       return theHundo;
                       break;
                   case 3:
                       return oneLarge;
                       break;
                   default:
                       Console.WriteLine("You chose a number out of range so we will use 1 - 10");
                       return listArr;
                       break;
               }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.Message} Please try that again.");
                throw;
            }
        }        
        public static int ChooseNumber (int[] myArr)
        {
            int length = myArr.Length;

            Console.WriteLine($"\nPlease choose a number between 1 - {length}");
            int num = int.Parse(Console.ReadLine());
            if (num > length)
            {
                Console.WriteLine($"\n{num} is greater than {length}");
                num = random.Next(1, length);
                Console.WriteLine($"\nYour auto-assigned number is {num}");
            }
            if (num < 1)
            {
                Console.WriteLine($"\n{num} is less than 0");
                num = random.Next(1, length);
                Console.WriteLine($"\nYour auto-assigned number is {num}");
            }

            return num;
        }

        public static int BisectionAlgorithm(int[] myArr)
        {
            int length = myArr.Length;
            int num = ChooseNumber(myArr);

            int start = myArr[0];
            int end = myArr[length - 1];
            
            int result = 0;
            bool isEqual = false;
            while (isEqual == false)
            {
                int middle = (start + end) / 2;                 
                Console.WriteLine($"Start point is: {start} \tMiddle is: {middle} \tEnd point is: {end}");
                if (middle == num) 
                {
                    result += middle;
                    Console.WriteLine($"Found your number {num}");
                    isEqual = true;
                }
                else if (middle < num) start = middle + 1;
                else if (middle > num) end = middle - 1;
                
            }

            return result;
        } //DONE
        public static int TheHumanGuess(int[] myArr)
        {
            int length = myArr.Length;
            int theComputerAnswer = random.Next(1, myArr.Length + 1); //computer picks a random number

            int start = myArr[0]; //the start 
            int end = myArr[length - 1];

            int result = 0;
            bool isEqual = false;

            int count = 0;

            //Console.WriteLine($"Guess the computers number 1 through {length}");
            while (isEqual == false)
            {

                //int middle = (start + end) / 2;

                Console.WriteLine($"\nGuess a number {start} through {end}");
                int myGuess = int.Parse(Console.ReadLine());

                //Console.WriteLine($"Start point is: {start} Middle is: {middle} End point is: {end}");
                if (myGuess == theComputerAnswer)
                {
                    result += theComputerAnswer;
                    Console.WriteLine($"\nYou found my number {theComputerAnswer}!!!! it only took you {count} trys.");
                    isEqual = true;
                }

                else if (myGuess < theComputerAnswer)
                {
                    start = myGuess;
                    Console.WriteLine("You need to go higher");
                    count++;
                }
                else if (myGuess > theComputerAnswer)
                {
                    Console.WriteLine("You need to go Lower");
                    end = myGuess;
                    count++;
                }
            }
            return result;
        } //DONE
        public static int TheComputerGuess(int[] myArr)
        {
            int length = myArr.Length;
            int start = myArr[0]; //the start 
            int end = myArr[length - 1];

            //Console.WriteLine($"Please choose a number between 1 - {length}");
            int myNumber = ChooseNumber(myArr);/*int.Parse(Console.ReadLine());*/

            int result = 0;
            bool isEqual = false;
            int count = 0;
            while (isEqual == false)
            {
                int theComputerAnswer = random.Next(start, end); //computer guesses a number

                //Console.WriteLine($"Start point is: {start} Middle is: {middle} End point is: {end}");
                if (myNumber == theComputerAnswer)
                {
                    result += theComputerAnswer;
                    Console.WriteLine($"I found your number {theComputerAnswer}!!!! It took me {count} trys.");
                    isEqual = true;
                }
                else
                {
                    Console.WriteLine($"\nIs it {theComputerAnswer}? (Your number is {myNumber}) \n\n1. Higher\n2. Lower");
                    int ourResponse = int.Parse(Console.ReadLine());

                    if (ourResponse == 1)
                    {
                        start = theComputerAnswer;
                        count++;
                    }
                    else if (ourResponse == 2)
                    {
                        end = theComputerAnswer;
                        count++;
                    }
                }
            }
            return result;
        } //DONE

        
        static void Main(string[] args)
        {

            TheGame();
            
        }
    }
}
