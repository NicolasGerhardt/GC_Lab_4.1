using System;
using System.Collections.Generic;

namespace GC_Lab_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayBanner("Welcome to Crazy Nic's Discount Casino");
            do
            {

                int numberOFDice = GetPositiveIntFromUser("How many dice do you want to roll?\n> ");
                int sides = GetPositiveIntFromUser("How many sides do you want on your dice?\n> ");
                Console.WriteLine($"{sides} sided Dice here we come!");
                int rollCount = 0;
                do
                {
                    rollCount++;
                    int[] DiceResults = RollDice(numberOFDice, sides);
                    DisplayDiceResults(DiceResults, rollCount);
                    DiceResultsAnalsys(rollCount, sides, DiceResults);

                } while (PromptYesNo("Roll Again? (y/n) "));
            } while (PromptYesNo("Do you want different dice? (y/n) "));

            DisplayBanner("Thank you for visiting Crazy Nic's Discount Casino");

        }

        private static void DiceResultsAnalsys(int rollCount, int sides, int[] diceResults)
        {
            if (diceResults.Length == 2 && sides == 6)
            {
                if (IsSnakeEyes(diceResults)) WriteColor("SnakeEyes\n", ConsoleColor.Green);
                if (IsAceDuce(diceResults)) Console.WriteLine("Ace Duce");
                if (IsBoxCars(diceResults)) Console.WriteLine("BoxCars");
                if (IsCrapsWin(diceResults)) WriteColor("WIN!!!\n", ConsoleColor.Blue);
                if (IsCrapsLoss(diceResults)) WriteColor("Craps!!\n", ConsoleColor.Red);
            }

            if (diceResults.Length == 5 && sides == 6) 
            {
                if (IsYahtzee(diceResults)) DisplayBanner("YAHTZEE!!!");
            }

            Console.WriteLine();
            Console.WriteLine($"You rolled a total of {DiceSum(diceResults)}.");
        }

        private static bool IsYahtzee(int[] diceResults)
        {
            int[] numOfEachNumberRolled = new int[6];

            foreach (int dice in diceResults)
            {
                numOfEachNumberRolled[dice - 1]++;
            }
            foreach (int result in numOfEachNumberRolled)
            {
                if (result == 5) return true;
            }

            return false;
        }

        private static bool IsCrapsLoss(int[] diceResults)
        {
            int sum = DiceSum(diceResults);
            return (sum == 2 || sum == 3 || sum == 12);
        }

        private static int DiceSum(int[] diceResults)
        {
            int sum = 0;
            foreach (int dice in diceResults)
            {
                sum += dice;
            }
            return sum;
        }

        private static bool IsCrapsWin(int[] diceResults)
        {
            int sum = DiceSum(diceResults);
            return (sum == 7 || sum == 11);
        }

        private static bool IsBoxCars(int[] diceResults)
        {
            int sixesCount = 0;
            foreach (int dice in diceResults)
            {
                if (dice == 6) sixesCount++;
            }

            return sixesCount == 2;
        }

        private static bool IsAceDuce(int[] diceResults)
        {
            bool hasOne = false;
            bool hasTwo = false;

            foreach (int dice in diceResults)
            {
                if (dice == 1) hasOne = true;
                if (dice == 2) hasTwo = true;
            }

            return (hasOne && hasTwo);
        }

        private static bool IsSnakeEyes(int[] diceResults)
        {
            if (diceResults.Length == 2)
            {
                if (diceResults[0] == 1 && diceResults[1] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        private static void DisplayBanner(string bannerMessage)
        {
            string line = string.Empty;
            for (int i = 0; i < bannerMessage.Length; i++)
            {
                line += "=";
            }
            Console.WriteLine();
            Console.WriteLine($"==={line}===");
            Console.WriteLine($"== {bannerMessage} ==");
            Console.WriteLine($"==={line}===");
            Console.WriteLine();
        }

        /// <summary>
        /// Yes Responce retruns true, no responce returns false. 
        /// Otherwise it keeps looping asking for yes or no.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private static bool PromptYesNo(string prompt)
        {
            do
            {
                Console.Write(prompt);
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if ("Yy".Contains(key))
                {
                    return true;
                }
                else if ("Nn".Contains(key))
                {
                    return false;
                }
                else
                {
                    WriteError("type y for yest or n for no");
                }
            } while (true);

        }

        private static void DisplayDiceResults(int[] diceResults, int rollCount)
        {
            Console.WriteLine();
            Console.WriteLine($"Roll #{rollCount}");
            for (int i = 0; i < diceResults.Length; i++)
            {
                Console.WriteLine($"Die #{i + 1}: {diceResults[i]}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Rolls a number of dice with the provided number or sides.
        /// </summary>
        /// <param name="numberOfDice"></param>
        /// <param name="sides"></param>
        /// <returns></returns>
        private static int[] RollDice(int num, int sides)
        {
            int[] dice = new int[num];
            var random = new Random();

            for (int i = 0; i < num; i++)
            {
                dice[i] = random.Next(sides) + 1; // Next returns floored numbers starting at 0.
            }
            
            return dice;
        }

        private static int GetPositiveIntFromUser(string prompt) 
        {
            int output = 0;
            bool done = false;
            while (!done)
            {
                output = GetIntFromUser(prompt);

                if (output < 1)
                {
                    WriteError("must be a postitive integer.");
                }
                else
                {
                    done = true;
                }
            } 

            return output;
        }


        private static int GetIntFromUser(string prompt)
        {
            int output;
            bool done = false;
            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                done = int.TryParse(userInput, out output);

                if (!done)
                {
                    WriteError("must enter an integer.");
                }
            } while (!done);

            return output;
        }

        private static void WriteError(string errorText)
        {
            WriteColor($"ERROR: {errorText}\n", ConsoleColor.Red);
        }

        private static void WriteColor(string text, ConsoleColor color)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = prevColor;
        }
    }
}
