using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class Translator
    {
        //Default constructor
        public Translator()
        {
            //Nothing needed here
        }

        //Private method to determine whether the word starts with a vowel
        private bool StartsWithVowel(string word)
        {
            char[] vowels = new char[5];
            vowels[0] = 'a';
            vowels[1] = 'e';
            vowels[2] = 'i';
            vowels[3] = 'o';
            vowels[4] = 'u';

            //Loop checks each vowel
            for(int i = 0; i < 5; i++)
            {
                if(word.ToArray()[0] == vowels[i])
                {
                    return true;
                }
            }

            return false;
        }

        public int FirstVowel(string word)
        {
            char[] vowels = new char[5];
            vowels[0] = 'a';
            vowels[1] = 'e';
            vowels[2] = 'i';
            vowels[3] = 'o';
            vowels[4] = 'u';

            //Loop checks every letter for being a vowel, then returns index
            for (int i = 0; i < word.Length; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (word.ToArray()[i] == vowels[j])
                    {
                        return i;
                    }
                }
            }

            return 1;
        }

        //Public method to change the word to pig latin, determining which logic to use from StartsWithVowel and FirstVowel
        public string ToPigLatin(string word)
        {
            word = word.Trim().ToLower();
            if (StartsWithVowel(word))
            {
                //Simple, just add 'yay'
                return word + "yay";
            }
            else
            {
                //Take the word apart and make a temporary array for storage
                char[] wordArray = word.ToArray();
                char[] tempArray = new char[word.Length];

                int count = 0;
                //Loop that fills the temparray starting at the first vowel
                for(int i = FirstVowel(word); i < word.Length; i++)
                {
                    tempArray[count] = wordArray[i];
                    count++;
                }

                //Find out how many letters there were before the vowel, and loop that many times to add them to the end
                int moveToEnd = word.Length - (word.Length - FirstVowel(word));
                for(int i = 0; i < moveToEnd; i++)
                {
                    tempArray[count] = wordArray[i];
                    count++;
                }

                //Put the word back together, and add the extra stuff
                string pigLatinWord = "";
                for(int i = 0; i < tempArray.Length; i++)
                {
                    pigLatinWord += tempArray[i];
                }
                return pigLatinWord + "ay";
            }
        }
    }
}
