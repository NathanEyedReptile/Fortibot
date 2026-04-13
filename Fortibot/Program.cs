using System;

class Program
{
    static void Main()
    {
        Console.Title = "Fortibot - Cybersecurity Assistant";

        VoiceGreeting.Play();   // plays on launch
        UIHelper.ShowLogo();    // ASCII logo

        UIHelper.TypeText("Initializing Fortibot...\n");

        Chatbot.Start();        //chatbot
    }
}
