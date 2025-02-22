using System;
using System.Diagnostics;
using System.Speech.Synthesis;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlatformID version = Environment.OSVersion.Platform;
            string str = Console.ReadLine();
            AddVoice voice ;




            if (version == PlatformID.Win32NT)
            {
                voice = speechOnWindows;
            }
            else 
            {
                voice = speechOnMacOS;
            }
            voice("privet");




        }

        delegate void AddVoice(string str);



        static void speechOnWindows(string str)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            synthesizer.Volume = 100;
            synthesizer.Rate = 0;

            synthesizer.Speak(str);
        }

        static void speechOnMacOS(string msg)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "sox",
                Arguments = msg,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };



            var process = Process.Start(startInfo);
        }



    }
}


