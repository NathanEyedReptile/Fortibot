using System;

public class Chatbot
{
    public static void Start()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        // Input validation
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name. Restart the program and try again.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nWelcome {name}, Fortibot is now online.");
        Console.ResetColor();

        while (true)
        {
            Console.Write("\n> ");
            string input = Console.ReadLine()?.ToLower();

            // Input validation
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid question.");
                continue;
            }

            if (input.Contains("how are you"))
            {
                Console.WriteLine("All systems operational. No threats detected 😎😎");
            }
            else if (input.Contains("purpose"))
            {
                Console.WriteLine("I help you stay safe online and avoid cyber threats.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Use long, complex passwords with symbols and avoid reuse.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Never click suspicious links. Always verify the sender.");
            }
            else if (input.Contains("safe browsing"))
            {
                Console.WriteLine("Only visit secure (HTTPS) websites and avoid downloads from unknown sources.");
            }
            else if (input == "exit")
            {
                Console.WriteLine("Fortibot shutting down. Stay safe.");
                break;
            }
            else
            {
                Console.WriteLine("I didn't quite understand that. Try asking about cybersecurity.");
            }
        }
    }
}
