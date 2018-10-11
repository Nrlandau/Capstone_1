using System;

namespace Capstone1
{
    class Program
    {
        static string WordToPigLatin(string inWord)
        {
            int wordCase;
            int i;
            wordCase = getCase(inWord);
            for(i = 0; i < inWord.Length && !IsVowel(inWord[i]); i++);
            if(i ==0)
                return  setCase(inWord + "way",wordCase);
            return setCase(inWord.Substring(i) + inWord.Substring(0,i) + "ay",wordCase);
        }
        static bool IsVowel(char letter)
        {
            switch(letter)
            {
                case 'a': case 'e': case 'i': case 'o': case 'u':
                case 'A': case 'E': case 'I': case 'O': case 'U':
                return true;
                default:
                return false;
            }
        }
        static int getCase(string inWord)
        {
            return 0;
        }
        static string setCase(string inWord, int wordCase)
        {
            return inWord;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(WordToPigLatin("Hello"));
        }
    }
}
