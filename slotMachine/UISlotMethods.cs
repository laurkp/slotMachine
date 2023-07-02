

namespace slotMachine
{
    internal class UISlotMethods
    {
        public const int LOWER_LIMIT = 0;
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
            double amount = -1;

            while (amount <= LOWER_LIMIT)
            {
                amount = Convert.ToDouble(Console.ReadLine());
                if (amount <= LOWER_LIMIT)
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive amount");
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
            double betAmount = -1;

            while (betAmount <= LOWER_LIMIT || betAmount > playMoney)
            {
                
                betAmount = Convert.ToDouble(Console.ReadLine());

                if (betAmount > LOWER_LIMIT && betAmount <= playMoney)
                {
                    break;
                }
                Console.WriteLine($"Invalid bet. Please place a new bet equal or lower than {playMoney}: ");
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
            Console.WriteLine($"\nSelect line to play:\n {Logic.INPUT_HORIZONTAL_LINE} - horizontal\n {Logic.INPUT_VERTICAL_LINE} - vertical\n {Logic.INPUT_DIAGONAL_LINE} - diagonal\n ");
            int line = -1;

            bool validInput = false;
            line = Convert.ToInt32(Console.ReadLine());

            validInput = line < Logic.INPUT_HORIZONTAL_LINE || line > Logic.INPUT_DIAGONAL_LINE;

            if (!validInput)
            {
                  Console.WriteLine($"Invalid input. Please enter {Logic.INPUT_HORIZONTAL_LINE}, {Logic.INPUT_VERTICAL_LINE}, or {Logic.INPUT_DIAGONAL_LINE} for the line variant.");
            }
            return line;
        }
        /// <summary>
        /// Asking the user to select a stake
        /// </summary>
        /// <returns></returns>
        public static int SelectStakeToPlay(List<int> stakeList, List<double> wins, List<double> loses)
        {
            string winsLoses = "";
            string selectStake = "";

            for (int i = 0; i < stakeList.Count; i++)
            {
                winsLoses += $"\n{stakeList[i]}cents wins ${wins[i]} / lose {loses[i]}cents\n";
                selectStake += $"\n{i} - {stakeList[i]}cents\n";
            }

            Console.WriteLine($"For each play depending on the stake: \n{winsLoses}");
            Console.WriteLine($"Select stake: \n{selectStake}");

            int stakeIndex = -1;

            while (stakeIndex < LOWER_LIMIT || stakeIndex > stakeList.Count)
            {
                stakeIndex = Convert.ToInt32(Console.ReadLine());

                if (stakeIndex >= Logic.INPUT_HORIZONTAL_LINE && stakeIndex <= Logic.INPUT_DIAGONAL_LINE)
                {
                    break;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {LOWER_LIMIT} and {stakeList.Count - USER_CHOICE_YES} inclusive.\n");
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
            int slotRows = slots.GetLength(0);
            int slotColumns = slots.GetLength(1);

            string output = "";

            for (int r = 0; r < slotRows; r++)
            {
                for (int c = 0; c < slotColumns; c++)
                {
                    output += $"{slots[r, c]}";

                    if (c < slotColumns - 1)
                    {
                        output += " | ";
                    }
                }

                if (r < slotRows - 1)
                {
                    output += $"\n{new string('-',slotColumns * Logic.NUMBER_OF_SLOTS)}\n";
                }
            }
            Console.WriteLine(output);
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
            Console.WriteLine($"Do you want to play again?\nSelect: {USER_CHOICE_YES} - Yes\n {USER_CHOICE_NO} - No");
            int keepPlaying = -1;

            while (keepPlaying != USER_CHOICE_YES && keepPlaying != USER_CHOICE_NO)
            {
                keepPlaying = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Invalid input. Please select 1 or 2.");
            }
            return  keepPlaying == USER_CHOICE_YES;
        }
    }
}
