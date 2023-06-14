﻿using System.Collections.Generic;

namespace slotMachine
{
    internal class Program
    {
        public const double MIN_MONEY = 0.10;
        
        static void Main(string[] args)
        {
            // Declaring lists for the stake, wins and loses
            List<int> stakeList = new List<int> { 10, 25, 50 };
            List<double> winList = new List<double> { 1, 2.5, 5 };
            List<double> loseList = new List<double> { 0.10, 0.25, 0.5 };
            while (true)
            {
                // Prompting welcome message
                UISlotMethods.Welcome();

             
                double moneyToPlay = UISlotMethods.MoneyToPlay();
                
                while (true)
                {
                    //Asking the user to place a bet
                    double betAmount = UISlotMethods.Bet(moneyToPlay);

                    double playBank = moneyToPlay - betAmount;

                    //Asking the user to select the line variant
                    
                    int lineVar = UISlotMethods.LineToPlay();

                    //Asking the user to select a stake
                    int stakeIdx = UISlotMethods.StakeToPlay(stakeList); ;
                    int userStake = stakeList[stakeIdx];
                    
                    // Prompting the playing stake
                    UISlotMethods.UserStake(userStake);

                    // Declaring a 2D array
                    int[,] slotMachine = new int[Logic.NUMBER_OF_SLOTS, Logic.NUMBER_OF_SLOTS];

                    // Asking the user to start the game
                    UISlotMethods.StartToPlay();

                    while (Console.ReadKey().Key == ConsoleKey.Enter && betAmount >= MIN_MONEY)
                    {

                        // Assigning a random number to each slot
                        Logic.AssignDynamicSlotNumbers(slotMachine);

                        // Prompting the slots with the random numbers
                        UISlotMethods.PromptSlots(slotMachine);

                        // Using if statements to check if the user win or lose 
                        bool isWin = Logic.CheckIfWinOrLose(slotMachine, lineVar);

                        // Calculating the winnings and loses
                        betAmount += Logic.CalcWinnings(winList, loseList, stakeIdx, isWin);

                        double newBank = playBank + betAmount;
                        
                        // Prompting how much money the user has left for bet 
                        UISlotMethods.PromptBet(betAmount);
                        // Prompting how much money the user has left in the bank
                        UISlotMethods.PromptBank(newBank);
                    }
                    break;
                }
                
            }
        }
    }
}
