using System;

namespace BlackJackLight
{
	class Program
	{
		static void Main (string[] args)
		{
			const double initialMoney = 100.0;
			double playerMoney = initialMoney;
			int firstCardScore, secondCardScore;

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
			Console.WriteLine("1. Start Game");
			Console.WriteLine("2. Continue Game");
			Console.WriteLine("3. Exit Game");
			Console.WriteLine(Environment.NewLine + "Please select an option (1-3): ");
			int selectedMenuOption = int.Parse(Console.ReadLine());

			switch (selectedMenuOption) {
				case 1:
					Console.WriteLine("Starting a new game...");
					// Initialize the game state here
					playerMoney = initialMoney; // Reset player money
					break;
				case 2:
					Console.WriteLine("Loading saved game...");
					break;
				case 3:
					Console.WriteLine("Bye! Bye!");
					return;
			}
			Console.ReadKey();
		}
	}
}