using System;
using System.Threading;

namespace CybersecurityBot
{
    class Program
    {
        // Global variables for the bot
        static string userName = "User";

        static void Main(string[] args)
        {
            // 1. Setup and Logo (Requirement 2 & 6)
            Console.Clear();
            DisplayLogo();

            // 2. Greeting and Name Capture (Requirement 3)
            TypeEffect(" [SYSTEM] Initializing bootup protocall...", ConsoleColor.DarkGray);
            TypeEffect(" [SYSTEM] Welcome to CyberBot.", ConsoleColor.Green);

            Console.WriteLine("\n--------------------------------------------------");
            Console.Write(" IDENTIFY YOURSELF: ");
            userName = Console.ReadLine();

            // Handle empty name
            if (string.IsNullOrWhiteSpace(userName)) userName = "Agent";

            TypeEffect($"\n Access Granted. Welcome, {userName}. I'm here to help you stay safe online.", ConsoleColor.Green);
            Console.WriteLine("--------------------------------------------------");
            TypeEffect(" You can ask me any question you may have on cybersecurity.");
            TypeEffect(" Type 'exit' to log out.");

            // 3. Interaction Loop (Requirement 4 & 5)
            bool isRunning = true;
            while (isRunning)
            {
                Console.Write($"\n[{userName}] > ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit" || userInput.ToLower() == "quit")
                {
                    TypeEffect(" Logging out... Stay secure.", ConsoleColor.Red);
                    isRunning = false;
                }
                else
                {
                    // Call the logic method to process input
                    ProcessInput(userInput);
                }
            }
        }

        // --- BOT LOGIC METHODS ---

        static string ProcessInput(string input)
        {
            string cleanInput = input.ToLower().Trim();

            // Requirement 5: Input Validation for empty entries
            if (string.IsNullOrEmpty(cleanInput))
            {
                TypeEffect(" [!] I didn't catch that. Please enter a query.", ConsoleColor.Yellow);
                //return;
            }

            // Requirement 4: Knowledge Base Responses
            if (cleanInput.Contains("how are you"))
            {
                TypeEffect($" I am encrypted and running smoothly, {userName}!", ConsoleColor.Cyan);
            }
            else if (cleanInput.Contains("purpose"))
            {
                TypeEffect(" My purpose is to help you navigate the web safely and prevent data breaches.", ConsoleColor.Cyan);
            }
            else if (cleanInput.Contains("password"))
            {
                TypeEffect(" [ADVICE] Use a unique passphrase of at least 12 characters. Avoid birthdays!", ConsoleColor.Yellow);
            }
            else if (cleanInput.Contains("phishing"))
            {
                TypeEffect(" [WARNING] Phishing often uses 'urgent' language. Never click links from unknown senders.", ConsoleColor.Red);
            }
            else if (cleanInput.Contains("browsing") || cleanInput.Contains("safe"))
            {
                TypeEffect(" [TIP] Always check for the HTTPS padlock before entering personal information.", ConsoleColor.Green);
            }
            else if (cleanInput.Contains("ask"))
            {
                TypeEffect(" You can ask: 'What is your purpose?', 'How are you?', or about security topics.");
            }
            else if (cleanInput.Contains("hey")) {
                TypeEffect(" Hello back at you are u ready to ask me a question");
            }
            else
            {
                // Requirement 5: Default response for unsupported queries
                TypeEffect(" I didn't quite understand that. Could you rephrase your security question?", ConsoleColor.Gray);
            }
            switch (input)
            {
                case "how are you?":
                case "how are you doing?":
                    return "I'm just a bot, but I'm always ready to help you stay safe online!";

                case "what’s your purpose?":
                case "what do you do?":
                    return "I’m here to provide cybersecurity awareness and help you protect yourself online!";

                case "what can i ask you about?":
                    return "You can ask me about password safety, phishing, safe browsing, and other cybersecurity tips.";
            }

            return "I didn’t quite understand that. Can you try rephrasing or ask about another cybersecurity topic?";
        }
        

        static void DisplayLogo()
        {
            // Requirement 2 & 6: Visual Elements
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
      ____________________________________________________________
     |        CCCC Y   Y BBBB  EEEEE RRRRR  BBBB  OOOOO TTTTTTT   |
     |    [#] C     Y Y  B   B E     R    R B   B O   O    T      |
     |  PART1 C      Y   BBBBB EEEEE RRRRR  BBBBB O   O    T      |
     |        C      Y   B   B E     R   R  B   B O   O    T      |
     |________CCCC___Y___BBBBB_EEEEE_R____R_BBBBB_OOOOO____T______|
            ");
            Console.ResetColor();
        }

        static void TypeEffect(string text, ConsoleColor color = ConsoleColor.White)
        {
            // Requirement 6: Typing effect for conversational feel
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
