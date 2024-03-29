﻿

namespace slotMachine
{
    internal class Program
    {
        public const double MIN_MONEY = 0.10;
        public const double NO_FUNDS = 0;
        
        static void Main(string[] args)
        {
            // Declaring lists for the stake, wins and loses
            List<int> stakeList = new List<int> { 10, 25, 50 };
            List<double> winList = new List<double> { 1, 2.5, 5 };
            List<double> loseList = new List<double> { -0.10, -0.25, -0.5 };

            bool play = true;
            while (play)
            {
                // Showing welcome message
                UISlotMethods.Welcome();

                // Asking the user how much money wants to play
                double moneyToPlay = UISlotMethods.SelectMoneyToPlay();
                
                while (moneyToPlay != NO_FUNDS)
                {
                    //Asking the user to place a bet
                    double betAmount = UISlotMethods.SelectBetAmount(moneyToPlay);

                    //Asking the user to select the line variant
                    int lineVar = UISlotMethods.SelectLineToPlay();

                    //Asking the user to select a stake
                    int stakeIdx = UISlotMethods.SelectStakeToPlay(stakeList, winList, loseList); ;
                    int userStake = stakeList[stakeIdx];
                    
                    // Showing the playing stake
                    UISlotMethods.ShowUserStake(userStake);

                    // Declaring a 2D array
                    int[,] slotMachine = new int[Logic.NUMBER_OF_SLOTS, Logic.NUMBER_OF_SLOTS];

                    // Asking the user to start the game
                    UISlotMethods.ShowStartToPlay();

                    while (Console.ReadKey().Key == ConsoleKey.Enter && betAmount >= MIN_MONEY)
                    {
                        // Assigning a random number to each slot
                        slotMachine = Logic.AssignDynamicSlotNumbers();

                        // Showing the slots with the random numbers
                        UISlotMethods.ShowSlots(slotMachine);

                        // Check if the user win or lose 
                        bool isWin = Logic.CheckIfWinOrLose(slotMachine, lineVar);

                        // Calculating the winnings and loses
                        double winLosAmount = Logic.CalcWinnings(winList, loseList, stakeIdx, isWin);

                        // Updating how much money the user has left in the bank
                        moneyToPlay += winLosAmount;
                        betAmount += winLosAmount;
                        
                        // Showing how much money the user has left for bet 
                        UISlotMethods.ShowBetAmountLeft(betAmount);
                        // Showing how much money the user has left in the bank
                        UISlotMethods.ShowBankAmountLeft(moneyToPlay);
                    }
                }
                // Checking if the user wants to keep playing or not 
                play = UISlotMethods.AskIfKeepPlaying();
            }
        }
    }
}
