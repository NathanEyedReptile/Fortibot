using System;
using System.Collections.Generic;

namespace FortiBot
{
    // Delegate for chatbot responses
    public delegate string ResponseHandler(string input);

    public class ChatbotEngine
    {
        // Delegate object
        private ResponseHandler responseDelegate;

        // Random object for random responses
        private Random random = new Random();

        // Stores the current conversation topic
        private string currentTopic = "";

        // Memory system
        private string userName = "";
        private string favoriteTopic = "";

        // Constructor
        public ChatbotEngine()
        {
            responseDelegate = GenerateResponse;
        }

        // Dictionary containing keyword responses
        private Dictionary<string, List<string>> keywordResponses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use long, complex passwords with symbols and numbers.",
                    "Avoid reusing the same password across multiple accounts.",
                    "Consider using a password manager to store secure passwords."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Never click suspicious links from unknown senders.",
                    "Always verify email addresses before opening attachments.",
                    "Be cautious of urgent messages asking for personal information."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review your privacy settings regularly on social media.",
                    "Avoid sharing sensitive personal information publicly online.",
                    "Use two-factor authentication to improve account security."
                }
            },

            {
                "scam",
                new List<string>()
                {
                    "Scammers often create urgency to pressure victims into acting quickly.",
                    "Never send money to unverified people or organizations online.",
                    "Be cautious of messages promising unrealistic rewards or prizes."
                }
            },

            {
                "safe browsing",
                new List<string>()
                {
                    "Only visit secure HTTPS websites.",
                    "Avoid downloading files from unknown websites.",
                    "Keep your browser updated for the latest security protection."
                }
            }
        };

        // Delegate calls this method
        public string GenerateResponse(string input)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please enter a valid message.";
            }

            string lowerInput = input.ToLower();

            // Sentiment detection
            string sentimentResponse = "";

            if (lowerInput.Contains("worried"))
            {
                sentimentResponse = "It's understandable to feel worried about online threats. ";
            }
            else if (lowerInput.Contains("frustrated"))
            {
                sentimentResponse = "Cybersecurity can definitely feel frustrating sometimes. ";
            }
            else if (lowerInput.Contains("confused"))
            {
                sentimentResponse = "That's okay. Cybersecurity topics can be confusing at first. ";
            }
            else if (lowerInput.Contains("curious"))
            {
                sentimentResponse = "Curiosity is a great mindset for learning cybersecurity. ";
            }

            // Remember user's name
            if (lowerInput.StartsWith("my name is"))
            {
                userName = input.Substring(11).Trim();

                return $"Nice to meet you {userName}. I'll remember your name.";
            }

            // Remember favorite cybersecurity topic
            if (lowerInput.Contains("i am interested in"))
            {
                foreach (var keyword in keywordResponses.Keys)
                {
                    if (lowerInput.Contains(keyword))
                    {
                        favoriteTopic = keyword;

                        return $"Great! I'll remember that you're interested in {keyword}.";
                    }
                }
            }

            // Follow-up conversation handling
            if (lowerInput.Contains("tell me more") ||
                lowerInput.Contains("another tip") ||
                lowerInput.Contains("explain more") ||
                lowerInput == "more")
            {
                if (!string.IsNullOrEmpty(currentTopic) &&
                    keywordResponses.ContainsKey(currentTopic))
                {
                    List<string> topicResponses = keywordResponses[currentTopic];

                    int randomIndex = random.Next(topicResponses.Count);

                    string followUpResponse = topicResponses[randomIndex];

                    if (favoriteTopic == currentTopic)
                    {
                        return sentimentResponse +
                               $"Since you're interested in {currentTopic}, {followUpResponse}";
                    }

                    return sentimentResponse + followUpResponse;
                }

                return "Could you specify which cybersecurity topic you'd like to know more about?";
            }

            // General responses
            if (lowerInput.Contains("how are you"))
            {
                return "All systems operational. No threats detected 😎😎";
            }

            if (lowerInput.Contains("purpose"))
            {
                return "I help users stay safe online and avoid cyber threats.";
            }

            // Check dictionary keywords
            foreach (var keyword in keywordResponses)
            {
                if (lowerInput.Contains(keyword.Key))
                {
                    // Store current topic
                    currentTopic = keyword.Key;

                    List<string> responses = keyword.Value;

                    // Random response selection
                    int index = random.Next(responses.Count);

                    string selectedResponse = responses[index];

                    // Personalized response
                    if (favoriteTopic == keyword.Key)
                    {
                        return sentimentResponse +
                               $"Since you're interested in {keyword.Key}, {selectedResponse}";
                    }

                    return sentimentResponse + selectedResponse;
                }
            }

            // Exit
            if (lowerInput == "exit")
            {
                return "FortiBot shutting down. Stay safe.";
            }

            // Default response
            return "I didn't quite understand that. Try asking about cybersecurity.";
        }

        // Public method that uses delegate
        public string GetResponse(string input)
        {
            return responseDelegate(input);
        }
    }
}