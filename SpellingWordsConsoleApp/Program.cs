using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;
using System.IO;

namespace SpellingWordsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // C#
            SpeechSynthesizer speaker = new SpeechSynthesizer();

            // C#
            speaker.Rate = 1;
            speaker.Volume = 100;
            speaker.Speak("Hello Speller! ");

            int fails = 0;
            int pass = 0;

            try
            {

                var spellingWordFile = File.ReadAllLines(args[0]);


                foreach (string word in spellingWordFile)
                {
                    Console.WriteLine("Please Spell The Word!");
                    speaker.Speak(word);

                    string answer = Console.ReadLine();

                    string msg = string.Empty;
                    if (String.Compare(answer, word, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        msg = "Correct";
                        pass += 1;
                    }
                    else
                    {
                        msg = ("Fail!! Dude you suck!!");
                        fails += 1;

                    }

                    Console.WriteLine(msg);
                    speaker.Speak(msg);
                }

                string endMsg = "Game Over\r\n";
                endMsg += "Fails = " + fails;

                speaker.Speak(endMsg);
                Console.WriteLine(endMsg);
            }
            catch (Exception exp)
            {
                string msg = "Oops!!There was a problem and my program has crashed!";
                Console.WriteLine(msg);
                speaker.Speak(msg);

                Console.WriteLine(exp);
            }

            Console.ReadKey();
        }
    }
}
