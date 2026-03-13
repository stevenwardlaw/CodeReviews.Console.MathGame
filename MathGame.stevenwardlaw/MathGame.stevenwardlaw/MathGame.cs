namespace MathGame.stevenwardlaw
{
    internal class MathGame
    {
        // Fields to keep score, number of questions & player choice of game
        public int score { get; private set; }
        private int numQuestions;
        private int playerGameChoice;

        // Store game type from enum
        private Operations gameType;

        // Set fields to starting values in constructor
        public MathGame(int numQuestions)
        {
            score = 0;
            this.numQuestions = numQuestions;
        }

        public MathGame()
        {
            score = 0;
            numQuestions = 5;
        }

        // Method to run the game
        public void RunGame()
        {
            Console.WriteLine("Welcome to the math game!");
            Console.WriteLine("Select from the following options:\n" +
                "1 - Addition Quiz\n" +
                "2 - Subtraction Quiz\n" +
                "3 - Multiplication Quiz\n" +
                "4 - Division Quiz\n" +
                "5 - Mixed Quiz");

            playerGameChoice = Convert.ToInt32(Console.ReadLine());

            switch (playerGameChoice)
            {
                case 1:
                    gameType = Operations.Addition;
                    break;
                case 2:
                    gameType = Operations.Subtraction;
                    break;
                case 3:
                    gameType = Operations.Multiplication;
                    break;
                case 4:
                    gameType = Operations.Division;
                    break;
                case 5:
                    gameType = Operations.Mixed;
                    break;
                default:
                    Console.WriteLine("Invalid option entered, defaulting to addition quiz.");
                    gameType = Operations.Addition;
                    break;
            }

            for (int i = 0; i < numQuestions; i++)
            {
                AskQuestion();
            }
        }

        // Method to get question

        public void AskQuestion()
        {
            int correctAnswer;
            int firstNumber;
            int secondNumber;
            string symbol;
            int randomNumber;
            int playerGuess;

            firstNumber = Random.Shared.Next(1, 101);
            secondNumber = Random.Shared.Next(1, 101);
            randomNumber = Random.Shared.Next(1, 5);

            if (gameType == Operations.Addition ||
                (gameType == Operations.Mixed && randomNumber == 1))
            {
                correctAnswer = firstNumber + secondNumber;
                symbol = "+";
            }
            else if (gameType == Operations.Subtraction ||
                (gameType == Operations.Mixed && randomNumber == 2))
            {
                correctAnswer = firstNumber - secondNumber;
                symbol = "-";
            }
            else if (gameType == Operations.Multiplication ||
                (gameType == Operations.Mixed && randomNumber == 3))
            {
                correctAnswer = firstNumber * secondNumber;
                symbol = "*";
            }
            else
            {
                do
                {
                    firstNumber = Random.Shared.Next(1, 101);
                    secondNumber = Random.Shared.Next(1, 101);
                }
                while (firstNumber % secondNumber != 0);

                correctAnswer = firstNumber / secondNumber;
                symbol = "/";
            }

            Console.WriteLine($"What is {firstNumber} {symbol} {secondNumber}?");
            playerGuess = Convert.ToInt32(Console.ReadLine());

            if (playerGuess == correctAnswer)
            {
                score++;
                Console.WriteLine($"That's correct! Your score is now {score}.");
            }
            else
            {
                Console.WriteLine("That's incorrect!");
            }
        }

    }

    public enum Operations { Addition, Subtraction, Multiplication, Division, Mixed }
}
