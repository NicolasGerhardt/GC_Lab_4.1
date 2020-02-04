# Lab 4.1 Dice Rolling
## Task
Create an application that simulates dice rolling.

## What will the Application do?
* The application asks the user to enter the number of sides for a pair of dice.
* The application prompts the user to roll the dice.
* The application “rolls” two n-sided dice, displaying the results of each along with a total
* For 6-sided dice, the application recognizes the following dice combinations and displays a message for each. It should not output this for any other size of dice.
  * Snake Eyes: Two 1s
  * Ace Deuce: A 1 and 2
  * Box Cars: Two 6s
  * Win: A total of 7 or 11
  * Craps: A total of 2, 3, or 12 (will also generate another message!)
* The application asks the user if he/she wants to roll the dice again.

## Build Specifications/Grading Requirements
1. Use a static method to generate the random numbers.
  * Proper method header: 2 points
  * Program generates random numbers validly and with an even distribution (all numbers represented equally) within the user-specified range: 1 point
  * Method returns meaningful value of proper type: 1 point
2. Use a static method to implement output for different dice combinations
  * Proper method header: 2 points
  * Method recognizes all specified cases correctly: 1 point
  * Method displays properly to Console: 1 point
3. Application takes all user input correctly: 1 point
4. Application loops properly: 1 point

## Extended Exercises
* Use the DiceRollerApp class to display special messages for craps, snake eyes, and box cars.

