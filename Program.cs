using System;

namespace Capstone1
{
    class Program
    {
        static string WordToPigLatin(string inWord)
        {

            return "";
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
        static void Main(string[] args)
        {
            ;
        }
    }
}
