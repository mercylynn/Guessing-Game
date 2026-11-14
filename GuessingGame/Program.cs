
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to guessing game!!");

        PlayGame();
    }

    static void PlayGame()
    {
        int randomNumber = GenerateRandomNumber();
        int playerGuess;
        int attempts = 0;
        int maxAttempts = GetMaxAttempts();
        bool gamewon = false;

        while (attempts < maxAttempts && !gamewon)
        {
            playerGuess = GetPlayerGuess();
            attempts++;

            if (playerGuess < randomNumber)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (playerGuess > randomNumber)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                gamewon = true;

                Console.WriteLine($"Congratulations! You guessed the number {randomNumber} in {attempts} attempts.");
            }
        }

        switch (gamewon)
        {
            case true:
                Console.WriteLine($"You won in {attempts} attempts!");
                break;

            case false:
                Console.WriteLine($"Game over! The number was {randomNumber}");
                break;
        }
    }

    static int GenerateRandomNumber()
    {
        Random random = new Random();

        return random.Next(1, 101);
    }

    static int GetPlayerGuess()
    {
        int guess;

        while (true)
        {
            Console.Write("Enter your guess: ");

            if (int.TryParse(Console.ReadLine(), out guess))
            {
                return guess;
            }

            Console.WriteLine("Invalid input! Enter a valid number.");
        }
    }

    static int GetMaxAttempts()
    {
        int attempts;

        while (true)
        {
            Console.Write("How many attempts would you like to guess? ");

            if (int.TryParse(Console.ReadLine(), out attempts) && attempts > 0)
            {
                return attempts;
            }

            Console.WriteLine("Invalid input! Please enter a positive integer.");
        }
    }

}
