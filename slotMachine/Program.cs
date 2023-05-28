﻿using System.Collections.Generic;

namespace slotMachine
{
    internal class Program
    {
        /*
        public const double STAKE1 = 10;
        public const double STAKE2 = 25;
        public const double STAKE3 = 50;
        public const double WIN1 = 1;
        public const double WIN2 = 2.5;
        public const double WIN3 = 5;
        public const double LOSE1 = 0.10;
        public const double LOSE2 = 0.25;
        public const double LOSE3 = 0.5;
        */
        static void Main(string[] args)
        {
            List<int> stakeList = new List<int> { 10, 25, 50 };
            List<double> winList = new List<double> { 1, 2.5, 5 };
            List<double> loseList = new List<double> { 0.10, 0.25, 0.5 };

            while (true)
            {
                // Prompting welcome message
                Console.WriteLine("*** WELCOME TO THE SLOT MACHINE ***");

                //Asking the user to place a bet
                Console.WriteLine("\nPlace a bet: ");
                double bet = Convert.ToDouble(Console.ReadLine());
                double money = bet;


                //Asking the user to select a stake
                Console.WriteLine($"\nSelect stake:\n 0 - {stakeList[0]}cents\n 1 - {stakeList[1]}cents\n 2 - {stakeList[2]}cents\n ");
                int stakeIdx = Convert.ToInt32(Console.ReadLine());
                int userStake = stakeList[stakeIdx];

                // Prompting the playing stake
                Console.WriteLine($"* Playing stake: {userStake}cents *");

                // Declaring a random variable
                Random random = new Random();

                // Declaring an array of numbers and a 2D array
                int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
                int[,] slotMachine = new int[3, 3];

                // Asking the user to start the game
                Console.WriteLine("\n** Press 'Enter' to play **");


                while (Console.ReadKey().Key == ConsoleKey.Enter && money >= 0.10)
                {

                    // Assigning a random number to each slot
                    slotMachine[0, 0] = random.Next(numbers.Length);
                    slotMachine[0, 1] = random.Next(numbers.Length);
                    slotMachine[0, 2] = random.Next(numbers.Length);
                    slotMachine[1, 0] = random.Next(numbers.Length);
                    slotMachine[1, 1] = random.Next(numbers.Length);
                    slotMachine[1, 2] = random.Next(numbers.Length);
                    slotMachine[2, 0] = random.Next(numbers.Length);
                    slotMachine[2, 1] = random.Next(numbers.Length);
                    slotMachine[2, 2] = random.Next(numbers.Length);

                    // Prompting the slots with the random numbers
                    Console.WriteLine($"\n{slotMachine[0, 0]} | {slotMachine[0, 1]} | {slotMachine[0, 2]}\n-- --  --\n{slotMachine[1, 0]} | {slotMachine[1, 1]} | {slotMachine[1, 2]}\n-- --  --\n{slotMachine[2, 0]} | {slotMachine[2, 1]} | {slotMachine[2, 2]}\n");

                    // Using if else statement to check if the user win or lose 
                    if ((slotMachine[0, 0] == slotMachine[0, 1] && slotMachine[0, 1] == slotMachine[0, 2]) ||
                        (slotMachine[1, 0] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[1, 2]) ||
                        (slotMachine[2, 0] == slotMachine[2, 1] && slotMachine[2, 1] == slotMachine[2, 2]) ||
                        (slotMachine[0, 0] == slotMachine[1, 1] && slotMachine[2, 2] == slotMachine[0, 0]))
                    {
                        if (userStake == stakeList[0])
                        {
                            money = money + winList[0];
                        }
                        if (userStake == stakeList[1])
                        {
                            money = money + winList[1];
                        }
                        if (userStake == stakeList[2])
                        {
                            money = money + winList[2];
                        }
                    }
                    else
                    {
                        if (userStake == stakeList[0])
                        {
                            money = money - loseList[0];
                        }
                        if (userStake == stakeList[1])
                        {
                            money = money - loseList[1];
                        }
                        if (userStake == stakeList[2])
                        {
                            money = money - loseList[2];
                        }
                    }
                    // Prompting how much money the user has left
                    Console.WriteLine($"Bank: {money}$");
                }
            }
        }
    }
}