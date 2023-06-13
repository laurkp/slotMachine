using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotMachine
{
    internal class SlotMethods
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
        public static double MoneyToPlay(double amount)
        {
            Console.WriteLine("Insert the amount of money you want to play: ");
            
            if (!Double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive amount");
                amount = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine($"Intial money: {amount}");
            return amount;
        }
        /// <summary>
        /// Asking the user to place a bet
        /// </summary>
        /// <param name="betAmount"></param>
        /// <returns></returns>
        public static double Bet(double betAmount) 
        {
            Console.WriteLine("\nPlace a bet: ");

            if(!Double.TryParse(Console.ReadLine() , out betAmount) || betAmount <= 0)
            {
                Console.WriteLine("Invalid bet. Please place a new bet: ");
                betAmount = Convert.ToDouble(Console.ReadLine());
            }
            return betAmount;
        }
        /// <summary>
        /// Asking the user to select the line variant
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static int LineToPlay(int line) 
        {
            Console.WriteLine($"\nSelect line to play:\n 0 - horizontal\n 1 - vertical\n 2 - diagonal\n ");
            if (!int.TryParse(Console.ReadLine(), out line) || line < 0 || line > 2)
            {
                Console.WriteLine("Invalid input. Please enter 0, 1, or 2 for the line variant.");
                line = Convert.ToInt32(Console.ReadLine());
            }
            return line;
        }
        /// <summary>
        /// Asking the user to select a stake
        /// </summary>
        /// <returns></returns>
        public static int StakeToPlay(List<int> list) 
        {
            int stakeIndex;
            Console.WriteLine($"\nSelect stake:\n 0 - {list[0]}cents\n 1 - {list[1]}cents\n 2 - {list[2]}cents\n ");
            
            if (!int.TryParse(Console.ReadLine(), out stakeIndex) || stakeIndex < 0 || stakeIndex > 2)
            {
                Console.WriteLine("Invalid input. Please enter 0, 1, or 2 for the stake.");
                stakeIndex = Convert.ToInt32(Console.ReadLine());
            }
            return stakeIndex;
        }
        
        /// <summary>
        /// Prompting the playing stake
        /// </summary>
        /// <param name="stake"></param>
        /// <returns></returns>
        public static int UserStake(int stake)
        {
            Console.WriteLine($"* Playing stake: {stake}cents *");
            return stake;
        }
        /// <summary>
        /// Asking the user to play
        /// </summary>
        public static void StartToPlay()
        {
            Console.WriteLine("\n** Press 'Enter' to play **");
        }
        /// <summary>
        /// Prompting the SlotMachine
        /// </summary>
        /// <param name="slots"></param>
        /// <returns></returns>
        public static int[,] PromptSlots(int[,] slots)
        {
            Console.WriteLine($"\n{slots[0, 0]} | {slots[0, 1]} | {slots[0, 2]}\n-- --  --\n{slots[1, 0]} | {slots[1, 1]} | {slots[1, 2]}\n-- --  --\n{slots[2, 0]} | {slots[2, 1]} | {slots[2, 2]}\n");
            return slots;
        }

        /// <summary>
        /// Prompting the bet amount
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        public static double PromptBet(double bet)
        {
            Console.WriteLine($"Bet: {bet}$");
            return bet;
        }
        /// <summary>
        /// Prompting how much money are left during the game
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public static double PromptBank(double bank)
        {
            Console.WriteLine($"Bank: {bank}$");
            return bank;
        }
    }
}
