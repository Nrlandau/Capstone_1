using System;

namespace Capstone1
{
    enum CaseName{LOWER,UPPER,TITLE}
    class Program
    {
        static string LineToPigLatin(string line)
        {
            int currentLength = 0;
            int i;
            string LatinLine = "";
            for(i =0; i <line.Length; i++)
            {
                if(line[i] == ' ')
                {
                    if(currentLength ==0)
                    {
                        LatinLine += " ";
                        currentLength = 0;
                        continue;
                    }
                    LatinLine += WordToPigLatin(line.Substring(i - currentLength,currentLength))+ " ";
                    currentLength = 0;
                }
                else
                    currentLength++;
            }
            return LatinLine;
        }
        static string WordToPigLatin(string inWord)
        {
            CaseName wordCase;
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
        static CaseName getCase(string inWord)
        {
            if(inWord == inWord.ToUpper())
                return CaseName.UPPER;
            if(inWord == inWord.ToLower())
                return CaseName.LOWER;
            return CaseName.TITLE;
        }
        static string setCase(string inWord, CaseName wordCase)
        {
            switch(wordCase)
            {
                case CaseName.UPPER:
                    return inWord.ToUpper();
                case CaseName.LOWER:
                    return inWord.ToLower();
                case CaseName.TITLE:
                    return inWord.Substring(0,1).ToUpper() + inWord.Substring(1).ToLower();
            }
            return inWord;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(WordToPigLatin("hello"));
            System.Console.WriteLine(WordToPigLatin("Hello"));
            System.Console.WriteLine(WordToPigLatin("HELLO"));
            System.Console.WriteLine(LineToPigLatin("Elllo ASDF  asdf  asdfff"));
        }
    }
}
