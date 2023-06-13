using System.Collections.Generic;

namespace slotMachine
{
    internal class Program
    {
        public const double MIN_MONEY = 0.10;
        
        // Declaring a random variable
        static readonly Random random = new Random();
        static void Main(string[] args)
        {
            // Declaring lists for the stake, wins and loses
            List<int> stakeList = new List<int> { 10, 25, 50 };
            List<double> winList = new List<double> { 1, 2.5, 5 };
            List<double> loseList = new List<double> { 0.10, 0.25, 0.5 };
            while (true)
            {
                // Prompting welcome message
                SlotMethods.Welcome();

                double inputAmount = 0;
                double bank = SlotMethods.MoneyToPlay(inputAmount); ;
                
                while (true)
                {
                    //Asking the user to place a bet
                    double money = SlotMethods.Bet(inputAmount);
                    double playBank = bank - money;

                    //Asking the user to select the line variant
                    int linePlay = 0;
                    int lineVar = SlotMethods.LineToPlay(linePlay);

                    //Asking the user to select a stake
                    int stakeIdx = SlotMethods.StakeToPlay(stakeList); ;
                    int userStake = stakeList[stakeIdx];
                    
                    // Prompting the playing stake
                    SlotMethods.UserStake(userStake);

                    // Declaring a 2D array
                    int[,] slotMachine = new int[3, 3];

                    // Asking the user to start the game
                    SlotMethods.StartToPlay();

                    while (Console.ReadKey().Key == ConsoleKey.Enter && money >= MIN_MONEY)
                    {

                        // Assigning a random number to each slot
                        for (int r = 0; r < 3; r++)
                        {
                            for (int c = 0; c < 3; c++)
                            {
                                slotMachine[r, c] = random.Next(1, 10);
                            }
                        }

                        // Prompting the slots with the random numbers
                        SlotMethods.PromptSlots(slotMachine);

                        // Using if statements to check if the user win or lose 
                        bool isWin = false;
                        if (lineVar == 0) // horizontal line
                        {
                            if (slotMachine[0, 0] == slotMachine[0, 1] && slotMachine[0, 1] == slotMachine[0, 2])
                                isWin = true;
                        }
                        if (lineVar == 1) // vertical line
                        {
                            if (slotMachine[0, 0] == slotMachine[1, 1] && slotMachine[1, 1] == slotMachine[2, 0])
                                isWin = true;
                        }
                        if (lineVar == 2) // diagonal line
                        {
                            if ((slotMachine[0, 0] == slotMachine[1, 1] && slotMachine[2, 2] == slotMachine[1, 1]) ||
                                (slotMachine[0, 2] == slotMachine[1, 1] && slotMachine[2, 0] == slotMachine[1, 1]))
                                isWin = true;
                        }

                        if (isWin)
                        {
                            money += winList[stakeIdx];
                        }
                        else
                        {
                            money -= loseList[stakeIdx];
                        }

                        double newBank = playBank + money;
                        bank = newBank;
                        // Prompting how much money the user has left for bet 
                        SlotMethods.PromptBet(money);
                        // Prompting how much money the user has left in the bank
                        SlotMethods.PromptBank(newBank);
                    }
                }
                
            }
        }
    }
}
