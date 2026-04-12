using System;
using System.Threading;
using NAudio.Wave;

namespace CybersecurityBot
{
    class Program
    {
        static string userName = "User";

        static void Main(string[] args)
        {
            // display ACSSI art logo and playing the audio file
            Console.Clear();
            DisplayLogo();
            PlayStartupSound();

            TypeEffect(" Initializing bootup protocall...", ConsoleColor.DarkGray);
            TypeEffect(" Welcome to CyberBot.", ConsoleColor.Green);
            Console.WriteLine("\n--------------------------------------------------");
            

            Console.Write(" IDENTIFY YOURSELF: ");
            userName = Console.ReadLine();

            // if the user doesnt enter a username
            if (string.IsNullOrWhiteSpace(userName)) userName = "Anonomyus";

            TypeEffect($"\n Access Granted. Welcome, {userName}. I'm here to help you stay safe online.", ConsoleColor.Red);
            Console.WriteLine("--------------------------------------------------");
            TypeEffect(" You can ask me any question you may have on cybersecurity.");
            TypeEffect(" Type 'exit' to log out.");

            // loop for the user exit
            bool proRunning = true;
            while (proRunning)
            {
                Console.Write($"\n[{userName}] > ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit" || userInput.ToLower() == "quit")
                {
                    TypeEffect(" Logging out... Stay secure.", ConsoleColor.Red);
                    proRunning = false;
                }
                else
                {
                    
                    ProcessInput(userInput);
                }
            }
        }

        

        static void ProcessInput(string input)
        {
            string cleanInput = input.ToLower().Trim();

            // If there is no input
            if (string.IsNullOrEmpty(cleanInput))
            {
                TypeEffect(" I didn't catch that. Please enter a query.", ConsoleColor.Yellow);
               
            }

            // Responses to inputs
            if (cleanInput.Contains("how are you")|| cleanInput.Contains("how are you doing?"))
            {
                TypeEffect($" I am good and running smoothly, {userName}!", ConsoleColor.Red);
            }
            else if (cleanInput.Contains("purpose")|| cleanInput.Contains("what do you do?"))
            {
                TypeEffect(" My purpose is to help you with cybersecurity saftey, naybe you'll learn something new.", ConsoleColor.Red);
            }
            else if (cleanInput.Contains("password"))
            {
                TypeEffect(" Use a unique passphrase of at least 12 characters. Avoid birthdays!", ConsoleColor.Red);
            }
            else if (cleanInput.Contains("phishing"))
            {
                TypeEffect(" Phishing often uses 'urgent' language. Never click links from unknown senders.", ConsoleColor.Red);
            }
            else if (cleanInput.Contains("browsing") || cleanInput.Contains("safe"))
            {
                TypeEffect(" Always check for the HTTPS padlock before entering personal information.", ConsoleColor.Red);
            }
            else if (cleanInput.Contains("ask"))
            {
                TypeEffect(" You can ask: 'What is your purpose?', 'How are you?', or about security topics.");
            }
            else if (cleanInput.Contains("hey")) {
                TypeEffect(" Hello back at you, are you ready to ask me a question");
            }
            else
            {
                // if user enters input that doesnt contain any key word above
                TypeEffect(" I didn't quite understand that. Could you rephrase your question or ask about a different topic?", ConsoleColor.Yellow);
            }
        }

        static void DisplayLogo()
        {
            // ACSSI art logo code
            Console.ForegroundColor = ConsoleColor.DarkBlue;
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
            
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        static void PlayStartupSound() // audio greeting for the user
        {
            Thread soundThread = new Thread(() =>
            {
                try
                {
                    using (var audioFile = new AudioFileReader("CyberBotgreeting.wav"))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        outputDevice.Init(audioFile);
                        outputDevice.Play();

                        
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
                catch
                {
                 
                }
            });

            soundThread.IsBackground = true; 
            soundThread.Start();
        }
    }
}
