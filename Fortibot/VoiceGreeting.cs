using System;
using System.Media;

public class VoiceGreeting
{
    public static void Play()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("greeting.wav");
            player.Play();
        }
        catch (Exception e)
        {
            Console.WriteLine("Audio error: " + e.Message);
        }
    }
}