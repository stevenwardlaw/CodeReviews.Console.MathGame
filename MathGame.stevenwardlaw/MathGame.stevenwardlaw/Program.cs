namespace MathGame.stevenwardlaw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List of ints to keep score history
            List<int> scoreHistory = new List<int>();
            MathGame currentGame;
            bool gameState = true;

            while (gameState)
            {
                currentGame = new MathGame();

                currentGame.RunGame();

                Console.WriteLine($"Quiz complete. Your final score is {currentGame.Score}.");
                scoreHistory.Add(currentGame.Score);

                Console.WriteLine("Would you like to play again or see your score history? " +
                    "1 - Play again. 2 - See score history. 3 - Exit game.");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Let's play again!");
                        break;
                    case 2:
                        for (int i = 0; i < scoreHistory.Count; i++)
                        {
                            Console.WriteLine($"Game {i + 1}: {scoreHistory[i]}");
                        }
                        break;
                    case 3:
                        gameState = false;
                        break;
                }
            }

        }
    }
}
