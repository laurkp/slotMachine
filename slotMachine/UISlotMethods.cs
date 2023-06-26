

namespace slotMachine
{
    internal class UISlotMethods
    {
        public const int USER_CHOICE_YES = 1;
        public const int USER_CHOICE_NO = 2;    
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
            Console.WriteLine("Insert the amount of money you want to play: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            while (amount <= 0)
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
            Console.WriteLine("\nPlace a bet: ");
            double betAmount = Convert.ToDouble(Console.ReadLine());

            while (betAmount <= 0 || betAmount > playMoney)
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
            Console.WriteLine($"\nSelect line to play:\n 0 - horizontal\n 1 - vertical\n 2 - diagonal\n ");
            int line = Convert.ToInt32(Console.ReadLine());

            while (line < 0 || line > 2)
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
            Console.WriteLine($"For each play depending on the stake:\n{list[0]}cents win ${wins[0]} / lose {loses[0]}cents\n{list[1]}cents win ${wins[1]} / lose {loses[1]}cents\n{list[2]}cents win ${wins[2]} / lose {loses[2]}cents\n");
            Console.WriteLine($"\nSelect stake:\n 0 - {list[0]}cents\n 1 - {list[1]}cents\n 2 - {list[2]}cents\n ");
            int stakeIndex = Convert.ToInt32(Console.ReadLine());

            while (stakeIndex < 0 || stakeIndex > 2)
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
        public static bool AskIfKeepPlaying()
        {
            Console.WriteLine("Do you want to play again?\nSelect: 1 - Yes\n 2 - No");
            int keepPlaying = Convert.ToInt32(Console.ReadLine());

            while (keepPlaying != USER_CHOICE_YES && keepPlaying != USER_CHOICE_NO)
            {
                Console.WriteLine("Invalid input. Please select 1 or 2.");
                keepPlaying = Convert.ToInt32(Console.ReadLine());
            }

            return  keepPlaying == USER_CHOICE_YES;
        }
    }
}
