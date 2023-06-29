

namespace slotMachine
{
    internal class Logic
    {
        // Declaring a random variable
        static readonly Random random = new Random();

        // Declaring a constant for the number of slots in each row and colum
        public const int NUMBER_OF_SLOTS = 3;
        public const int MIN_NUMBER = 1;
        public const int MAX_NUMBER = 10;
        public const int INPUT_HORIZONTAL_LINE = 0;
        public const int INPUT_VERTICAL_LINE = 1;
        public const int INPUT_DIAGONAL_LINE = 2;

        /// <summary>
        /// Calculating winnings and loses
        /// </summary>
        /// <param name="win"></param>
        /// <param name="lose"></param>
        /// <param name="index"></param>
        /// <param name="Win"></param>
        /// <param name="cash"></param>
        /// <returns></returns>
        public static double CalcWinnings(List<double> winningAmount, List<double> losingAmount, int index, bool userWon)
        {
            
            if (userWon)
            {
               return winningAmount[index];
            }
            else
            {
               return losingAmount[index]*-1;
            }
        }
        /// <summary>
        /// Assigning random numbers to the slots
        /// </summary>
        /// <param name="slot"></param>
        public static void AssignDynamicSlotNumbers(int[,] slot)
        {
            for (int r = 0; r < NUMBER_OF_SLOTS; r++)
            {
                for (int c = 0; c < NUMBER_OF_SLOTS; c++)
                {
                    slot[r, c] = random.Next(MIN_NUMBER, MAX_NUMBER);
                }
            }
        }
        /// <summary>
        /// Checking if the line win or lose
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool CheckIfWinOrLose(int[,] slot, int line)
        {
            bool win = false;
            if (line == INPUT_HORIZONTAL_LINE) // horizontal line
            {
                if ((slot[0, 0] == slot[0, 1] && slot[0, 1] == slot[0, 2]) ||
                    (slot[1, 0] == slot[1, 1] && slot[1, 1] == slot[1, 2]) ||
                    (slot[2, 0] == slot[2, 1] && slot[2, 1] == slot[2, 2]))
                    win = true;
            }
            if (line == INPUT_VERTICAL_LINE) // vertical line
            {
                if ((slot[0, 0] == slot[1, 0] && slot[1, 0] == slot[2, 0]) ||
                    (slot[0, 1] == slot[1, 1] && slot[1, 1] == slot[2, 1]) ||
                    (slot[0, 2] == slot[1, 2] && slot[1, 2] == slot[2, 2]))
                    win = true;
            }
            if (line == INPUT_DIAGONAL_LINE) // diagonal line
            {
                if ((slot[0, 0] == slot[1, 1] && slot[2, 2] == slot[1, 1]) ||
                    (slot[0, 2] == slot[1, 1] && slot[2, 0] == slot[1, 1]))
                    win = true;
            }
            return win;
        }
    }
}
