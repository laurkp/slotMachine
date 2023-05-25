namespace slotMachine
{
    internal class Program
    {
        public const int STAKE1 = 10;
        public const int STAKE2 = 25;
        public const int STAKE3 = 50;
        public const double WIN1 = 1;
        public const double WIN2 = 2.5;
        public const double WIN3 = 5;
        public const double LOSE1 = 0.10;
        public const double LOSE2 = 0.25;
        public const double LOSE3 = 0.5;
        static void Main(string[] args)
        {
            // Prompting welcome message
            Console.WriteLine("*** WELCOME TO THE SLOT MACHINE ***");

            //Asking the user to place a bet
            Console.WriteLine("\nPlace a bet: ");
            double bet = Convert.ToDouble(Console.ReadLine());
            double money = 0;

            //Asking the user to select a stake
            Console.WriteLine($"\nSelect stake:\n a - {STAKE1}cents\n b - {STAKE2}cents\n c - {STAKE3}cents\n ");
            string stake = Console.ReadLine();
            int userStake = 0;

            if (stake == "a") 
            {
                userStake = STAKE1;
            }
            if (stake == "b")
            {
                userStake = STAKE2;
            }
            if (stake == "c")
            {
                userStake = STAKE3;
            }

            // Prompting the playing stake
            Console.WriteLine($"* Playing stake: {userStake}cents *");

            // Declaring a random variable
            Random random = new Random();

            // Declaring an array of numbers and a 2D array
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            int[,] slotMachine = new int [3, 3];

            // Asking the user to start the game
            Console.WriteLine("\n** Press 'Enter' to play **");


            while (Console.ReadKey().Key == ConsoleKey.Enter)
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
                    (slotMachine[0, 0] == slotMachine[1, 1] && slotMachine[2, 2] == slotMachine[0, 0]) || 
                    (slotMachine[0, 0] == slotMachine[0, 1] && slotMachine[0, 2] == slotMachine[0, 0]) ||
                    (slotMachine[1, 0] == slotMachine[1, 1] && slotMachine[1, 2] == slotMachine[1, 0]) ||
                    (slotMachine[2, 0] == slotMachine[2, 1] && slotMachine[2, 2] == slotMachine[2, 0])) 
                {
                    if (userStake == STAKE1)
                    {
                        money = bet + WIN1;
                    }
                    if (userStake == STAKE2)
                    {
                        money = bet + WIN2;
                    }
                    if (userStake == STAKE3)
                    {
                        money = bet + WIN3;
                    }
                }
                else 
                {
                    if (userStake == STAKE1)
                    {
                        money =  bet - LOSE1;
                    }
                    if (userStake == STAKE2)
                    {
                        money =  bet - LOSE2;
                    }
                    if (userStake == STAKE3)
                    {
                        money =  bet - LOSE3;
                    }
                }
                // Prompting how much money the user has left
                Console.WriteLine($"Bank: {money}$");
            }

        }
    }
}