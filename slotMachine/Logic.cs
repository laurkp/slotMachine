

using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Drawing;

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
        public const int INPUT_HORIZONTAL_LINE = 1;
        public const int INPUT_VERTICAL_LINE = 2;
        public const int INPUT_DIAGONAL_LINE = 3;

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
                return losingAmount[index];
            }
        }
        /// <summary>
        /// Assigning random numbers to the slots
        /// </summary>
        /// <param name="slot"></param>
        public static int[,] AssignDynamicSlotNumbers()
        {
            int[,] slot = new int[NUMBER_OF_SLOTS, NUMBER_OF_SLOTS]; 

            for (int r = 0; r < NUMBER_OF_SLOTS; r++)
            {
                for (int c = 0; c < NUMBER_OF_SLOTS; c++)
                {
                    slot[r, c] = random.Next(MIN_NUMBER, MAX_NUMBER);
                }
            }
            return slot;
        }
        /// <summary>
        /// Checking if the line win or lose
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static bool CheckIfWinOrLose(int[,] slot, int lineType)
        {
            switch (lineType)
            {
                case INPUT_HORIZONTAL_LINE:
                    return CheckHorizontalWin(slot);

                case INPUT_VERTICAL_LINE:
                    return CheckVerticalWin(slot);

                case INPUT_DIAGONAL_LINE:
                    return CheckDiagonalWin(slot);

                default:
                    return false; // Invalid lineType, return false.
            }
        }

        private static bool CheckHorizontalWin(int[,] slot)
        {
            int rowCount = slot.GetLength(0);
            int columnCount = slot.GetLength(1);

            for (int r = 0; r < rowCount; r++)
            {
                int firstElement = slot[r, 0];
                bool isWinningLine = true;

                for (int c = 0; c < columnCount; c++)
                {
                    if (slot[r, c] != firstElement)
                    {
                        isWinningLine = false;
                        break;
                    }
                }

                if (isWinningLine)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckVerticalWin(int[,] slot)
        {
            int rowCount = slot.GetLength(0);
            int columnCount = slot.GetLength(1);

            for (int c = 0; c < columnCount; c++)
            {
                int firstElement = slot[0, c];
                bool isWinningLine = true;

                for (int r = 0; r < rowCount; r++)
                {
                    if (slot[r, c] != firstElement)
                    {
                        isWinningLine = false;
                        break;
                    }
                }

                if (isWinningLine)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckDiagonalWin(int[,] slot)
        {
            
            int columnCount = slot.GetLength(1);

            // Check top-left to bottom-right diagonal
            int firstElement = slot[0, 0];
            bool isWinningLine = true;

            for (int i = 0; i < columnCount; i++)
            {
                if (slot[i, i] != firstElement)
                {
                    isWinningLine = false;
                    break;
                }
            }

            if (isWinningLine)
            {
                return true;
            }
  
                // Check top-right to bottom-left diagonal
                firstElement = slot[0, columnCount - 1];
                isWinningLine = true;

                for (int i = 0; i < columnCount; i++)
                {
                    if (slot[i, columnCount - 1 - i] != firstElement)
                    {
                        isWinningLine = false;
                        break;
                    }
                }

                return isWinningLine;
        }

    }
}
