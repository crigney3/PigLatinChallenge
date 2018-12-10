using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Translator instance and main loop
            Translator translator = new Translator();
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("1 - Translate some pig latin!\n2 - Quit");
                string input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "1":
                    case "translate":
                        //Get new user input and pig latin it
                        Console.WriteLine("Enter what you want turned into pig latin:");
                        string toBeLatined = Console.ReadLine().Trim().ToLower();
                        
                        //In case it's a sentence, .Split it
                        string[] sentenceArray = toBeLatined.Split(' ');
                        string[] outputArray = new string[sentenceArray.Length];
                        int count = 0;
                        foreach(string word in sentenceArray)
                        {
                            outputArray[count] = translator.ToPigLatin(word);
                            count++;
                        }

                        //Put the sentence back together
                        foreach(string outputWord in outputArray)
                        {
                            Console.Write(outputWord + " ");
                        }
                        Console.WriteLine();
                        break;
                    case "2":
                    case "quit":
                        quit = !quit;
                        Console.WriteLine("Quitting...");
                        break;
                }
            }
        }
    }
}
