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
                    DiceResultsAnalsys(sides, DiceResults);

                } while (PromptYesNo("Roll Again? (y/n) "));
            } while (PromptYesNo("Do you want different dice? (y/n) "));

            DisplayBanner("Thank you for visiting Crazy Nic's Discount Casino");

        }

        private static void DiceResultsAnalsys(int sides, int[] diceResults)
        {
            int[] countOfEachSideRolled = new int[sides + 1]; //made bigger to accomidate 0 indexing translation
            int sum = DiceSum(diceResults);
            foreach (int die in diceResults)
            {
                countOfEachSideRolled[die]++;
            }

            if (diceResults.Length == 2 && sides == 6)
            {
                if (countOfEachSideRolled[1] == 2) WriteColor("Snake Eyes\n", ConsoleColor.Green);
                if (countOfEachSideRolled[1] == 1 && countOfEachSideRolled[2] == 1) WriteColor("Ace Duce\n", ConsoleColor.Red);
                if (countOfEachSideRolled[6] == 2) WriteColor("Boxcars\n", ConsoleColor.Red);
                if (sum == 7 || sum == 11) WriteColor("WIN!!!\n", ConsoleColor.Cyan);
                if (sum == 2 || sum == 3 || sum == 12) WriteColor("Craps!!\n", ConsoleColor.Red);
            }

            if (diceResults.Length == 5 && sides == 6) 
            {
                if (IsYahtzee(countOfEachSideRolled)) DisplayBanner("YAHTZEE!!!");
            }

            Console.WriteLine();
            Console.WriteLine($"You rolled a total of {DiceSum(diceResults)}.");
        }

        private static bool IsYahtzee(int[] countOfEachSideRolled)
        {
            foreach (int result in countOfEachSideRolled)
            {
                if (result == 5) return true;
            }

            return false;
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
