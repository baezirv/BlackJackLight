using System;
using System.Threading;

namespace BlackJackLight
{
	class Program
	{
		static void Main (string[] args)
		{
			const double initialMoney = 100.0;
			double playerMoney = initialMoney;
			int firstCardScore, secondCardScore, thirdCardScore;

			string gender;
			int age;
			string playerName;
			// Set a window title
			Console.Title = "BlackJack The Game";
			

			while (true) {
				Console.WriteLine("Please insert your age and press <Enter>");
				string ageInput = Console.ReadLine();
				
				if (!int.TryParse(ageInput, out age)) {
					Console.WriteLine("Invalid input. Please enter a valid age.");
				} else if (age < 18) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Sorry, you must be at least 18 years old to play this game.");
					Environment.Exit(0);
				}
				else {
					break;
				}
			}
			Console.WriteLine("Please insert your name and press <Enter>");
			playerName = Console.ReadLine();
			
			while (true) {
				Console.WriteLine("Please insert your gender (male or female) and press <Enter>");
				// Read the input and trim any whitespace
				gender = Console.ReadLine()?.Trim().ToLower();
				if (gender == "male" || gender == "female") {
					break; // Exit the loop if input is valid
				}
				Console.WriteLine("Invalid input. Please type 'male' or 'female'.");
			}
			if (string.IsNullOrWhiteSpace(gender)) {
				
			}
			if (gender == "male" && string.IsNullOrWhiteSpace(playerName)) {
				playerName = "John Doe";
			} else if (gender == "female" && string.IsNullOrWhiteSpace(playerName)) {
				playerName = "Jane Doe";
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write($"Welcome {playerName} to BlackJack The Game!\n");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("    ( V )");
			Console.WriteLine("     \\ / ");
			Console.WriteLine("      V ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("1. New Game");
			Console.WriteLine("2. Reset Status");
			Console.WriteLine("3. Exit Game");
			Console.WriteLine(Environment.NewLine + "Please select an option (1-3): ");
			int selectedMenuOption = int.Parse(Console.ReadLine());

			switch (selectedMenuOption) {
				case 1:
					Console.WriteLine("Starting a new game...");
					Thread.Sleep(1000);
					// Initialize the game state here
					playerMoney = initialMoney;
					Console.WriteLine("Shuffling the deck...");
					Thread.Sleep(500);
					Console.WriteLine(".....................");
					Thread.Sleep(500);
					Console.WriteLine(".....................");
					Console.WriteLine("Done shuffling the deck.");
					Thread.Sleep(500);
					Console.WriteLine("Serving the cards.");
					Thread.Sleep(1000);
					// Create a instance of Random to generate random numbers
					var randomGenerator = new Random();
					firstCardScore = randomGenerator.Next(1, 11); // Random score between 1 and 10
					secondCardScore = randomGenerator.Next(1, 11); // Random score between 1 and 10
					thirdCardScore = 0;
					
					Console.WriteLine("Drawing your first card.\n .................");
					Thread.Sleep(500);
					Console.WriteLine($"Your first card score is: {firstCardScore}");
					Thread.Sleep(1000);
					Console.WriteLine("Drawing your second card.\n .................");
					Thread.Sleep(500);
					Console.WriteLine($"Your second card score is: {secondCardScore}");
					int currentScore = firstCardScore + secondCardScore;
					Thread.Sleep(500);
					Console.WriteLine($"Your current score is: {currentScore}");
					Console.WriteLine("Would you like to draw a third card?\n1. Yes\n2. No");
					
					var shouldDrawThirdCard = Console.ReadLine();
					
					if (shouldDrawThirdCard == "1") {
						thirdCardScore = randomGenerator.Next(1, 11); // Random score between 1 and 10
						Thread.Sleep(500);
						Console.WriteLine("Drawing your third card.\n .................");
						Thread.Sleep(500);
						Console.WriteLine($"Your third card score is: {thirdCardScore}");
					} else if (shouldDrawThirdCard == "2") {
						Thread.Sleep(500);
						Console.WriteLine("You chose not to draw a third card.");
					} else {
						Thread.Sleep(500);
						Console.WriteLine("Invalid option. No third card drawn.");
					}
					
					var totalScore = firstCardScore + secondCardScore + thirdCardScore;
					Thread.Sleep(500);
					Console.WriteLine($"Your total score is: {totalScore}");
					Thread.Sleep(1000);

					if (totalScore > 21) {
						Console.ForegroundColor = ConsoleColor.Red;
						Thread.Sleep(500);
						Console.WriteLine("You busted! Your total score exceeds 21.");
						Console.WriteLine("Game over.\n Press any key to quit.");
						Console.ReadKey ();
					}
					
					var dealerHandScore = randomGenerator.Next(10, 23); // Dealer's score between 17 and 22
					Thread.Sleep(1000);
					Console.WriteLine("The dealer is drawing cards...");
					Thread.Sleep(500);
					Console.WriteLine("Dealer's total score is: " + dealerHandScore);
					Thread.Sleep(1000);
					
					if (totalScore <= dealerHandScore) {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("You lost! The dealer's score is higher or equal to yours.");
						Console.WriteLine("Game over.\nPress any key to quit.");
						Console.ReadKey ();
					} else if (totalScore > dealerHandScore && totalScore <= 21) {
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Congratulations! You won against the dealer!");
						playerMoney += 10; // Player wins $10
						Console.WriteLine($"Your new balance is: ${playerMoney}");
					} else {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Invalid game state. Please try again.");
					}
					break;
				case 2:
					Console.WriteLine("Are you sure you want to reset your status?\n1. Yes\n2. No");
					string promptAnswer = Console.ReadLine();
					if (promptAnswer == "1") {
						Console.WriteLine("Resetting status...");
						playerMoney = initialMoney; // Reset player money
						Console.WriteLine("Stats were reset to initial values.");
					} else if (promptAnswer == "2") {
						Console.WriteLine("Status reset cancelled.");
					} else {
						Console.WriteLine("Invalid option. Returning to main menu.");
					}
					break;
				case 3:
					Console.WriteLine("Bye! Bye!");
					return;
			}
			Console.ReadKey();
		}
	}
}