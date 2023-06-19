﻿

namespace slotMachine
{
    internal class UISlotMethods
    {
        
        /// <summary>
        /// Welcoming message
        /// </summary>
        public static void  Welcome()
        {
            Console.WriteLine("*** WELCOME TO THE SLOT MACHINE ***");
        }

        /// <summary>
        /// // Asking the user how much money would like to play
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>How much money the user plays</returns>
        public static double SelectMoneyToPlay()
        {
            double amount;
            Console.WriteLine("Insert the amount of money you want to play: ");
            
            while (!Double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive amount");
                amount = Convert.ToDouble(Console.ReadLine());
                if (amount > 0)
                {
                    break;
                }     
            }
            Console.WriteLine($"Intial money: {amount}");
            return amount;
        }
        /// <summary>
        /// Asking the user to place a bet
        /// </summary>
        /// <param name="betAmount"></param>
        /// <returns></returns>
        public static double SelectBetAmount(double playMoney) 
        {
            double betAmount;
            Console.WriteLine("\nPlace a bet: ");

            while(!Double.TryParse(Console.ReadLine() , out betAmount) || betAmount <= 0 || betAmount > playMoney)
            {
                Console.WriteLine($"Invalid bet. Please place a new bet equal or lower than {playMoney}: ");
                betAmount = Convert.ToDouble(Console.ReadLine());
                if (betAmount > 0 && betAmount <= playMoney)
                {
                    break;
                }
            }
            return betAmount;
        }
        /// <summary>
        /// Asking the user to select the line variant
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static int SelectLineToPlay() 
        {
            int line;
            Console.WriteLine($"\nSelect line to play:\n 0 - horizontal\n 1 - vertical\n 2 - diagonal\n ");
            while (!int.TryParse(Console.ReadLine(), out line) || line < 0 || line > 2)
            {
                Console.WriteLine("Invalid input. Please enter 0, 1, or 2 for the line variant.");
                line = Convert.ToInt32(Console.ReadLine());
                if (line >= 0 && line <= 2)
                {
                    break;
                }
            }
            return line;
        }
        /// <summary>
        /// Asking the user to select a stake
        /// </summary>
        /// <returns></returns>
        public static int SelectStakeToPlay(List<int> list, List<double> wins, List<double> loses)
        {
            int stakeIndex;
            Console.WriteLine($"For each play depending on the stake:\n{list[0]}cents win ${wins[0]} / lose {loses[0]}cents\n{list[1]}cents win ${wins[1]} / lose {loses[1]}cents\n{list[2]}cents win ${wins[2]} / lose {loses[2]}cents\n");
            Console.WriteLine($"\nSelect stake:\n 0 - {list[0]}cents\n 1 - {list[1]}cents\n 2 - {list[2]}cents\n ");

            while (!int.TryParse(Console.ReadLine(), out stakeIndex) || stakeIndex < 0 || stakeIndex > 2)
            {
                Console.WriteLine("Invalid input. Please enter 0, 1, or 2 for the stake.");
                stakeIndex = Convert.ToInt32(Console.ReadLine());
                if (stakeIndex >= 0 && stakeIndex <= 2)
                {
                    break;
                }
            }
            return stakeIndex;
        }
        
        /// <summary>
        /// Prompting the playing stake
        /// </summary>
        /// <param name="stake"></param>
        /// <returns></returns>
        public static void ShowUserStake(int stake)
        {
            Console.WriteLine($"* Playing stake: {stake}cents *");
        }
        /// <summary>
        /// Asking the user to play
        /// </summary>
        public static void ShowStartToPlay()
        {
            Console.WriteLine("\n** Press 'Enter' to play **");
        }
        /// <summary>
        /// Prompting the SlotMachine
        /// </summary>
        /// <param name="slots"></param>
        /// <returns></returns>
        public static void ShowSlots(int[,] slots)
        {
            Console.WriteLine($"\n{slots[0, 0]} | {slots[0, 1]} | {slots[0, 2]}\n-- --  --\n{slots[1, 0]} | {slots[1, 1]} | {slots[1, 2]}\n-- --  --\n{slots[2, 0]} | {slots[2, 1]} | {slots[2, 2]}\n");        
        }

        /// <summary>
        /// Prompting the bet amount
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        public static void ShowBetAmountLeft(double bet)
        {
            Console.WriteLine($"Bet: {bet}$");
        }
        /// <summary>
        /// Prompting how much money are left during the game
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public static void ShowBankAmountLeft(double bank)
        {
            Console.WriteLine($"Bank: {bank}$");
        }

        public static bool AskIfKeepPlaying(bool chooseToPlay)
        {
            int keepPlaying;
            
            Console.WriteLine("Do you want to play again?\nSelect: 1 - Yes\n 2 - No");
            while(!int.TryParse(Console.ReadLine(), out keepPlaying) || keepPlaying < 1 || keepPlaying > 2)
            {
                Console.WriteLine("Invalid input. Please select 1 or 2.");
                keepPlaying = Convert.ToInt32(Console.ReadLine());
                if (keepPlaying >= 1 && keepPlaying <= 2)
                {
                    break;
                }
            }
            if(keepPlaying == 2)
            {
                chooseToPlay = false; 
            }
            return chooseToPlay;
        }
    }
}
