using System;
using System.Windows;
using System.Windows.Input;

namespace FortiBot
{
    public partial class MainWindow : Window
    {
        // Create chatbot engine object
        private ChatbotEngine chatbot = new ChatbotEngine();

        public MainWindow()
        {
            InitializeComponent();

            // Startup messages
            ChatHistory.Text += "FortiBot is now online.\n";
            ChatHistory.Text += "Ask me anything about cybersecurity.\n\n";

            // Play voice greeting
            VoiceGreeting.Play();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();

            // Input validation
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // Display user message
            ChatHistory.Text += $"You: {input}\n";

            // Get chatbot response
            string response = chatbot.GetResponse(input);

            // Auto scroll to bottom
            ChatScrollViewer.ScrollToEnd();

            // Display chatbot response
            ChatHistory.Text += $"FortiBot: {response}\n\n";

            // Exit command
            if (input.ToLower() == "exit")
            {
                Application.Current.Shutdown();
            }

            // Clear input field
            UserInput.Clear();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendButton_Click(sender, e);
            }
        }
    }
}