﻿using System;
using System.Text.RegularExpressions;

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
            for(i =0; i <line.Length ; i++)
            {
                if(line[i] == ' ')
                {
                    if(currentLength ==0)
                    {
                        LatinLine += " ";
                        currentLength = 0;
                        continue;
                    }
                    LatinLine += Translate(line.Substring(i - currentLength,currentLength)) + " ";
                    
                    currentLength = 0;
                }
                else
                    currentLength++;
            }
            if(currentLength != 0)
                LatinLine += Translate(line.Substring(i - currentLength,currentLength));
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
        static string Translate(string input)
        {
            if(CanTranslate(input))
            {
                string LatinLine = "";
                int start = 0;
                for(int i =0; i < input.Length; i++)
                {
                    if(IsPunc(input[i]))
                    {
                        if(start == i)
                            LatinLine += input[start];
                        else
                            LatinLine += WordToPigLatin(input.Substring(start,i-start)) + input[i];
                        start = i + 1;
                    }
                }
                if(start != input.Length)
                {
                    LatinLine += WordToPigLatin(input.Substring(start,input.Length - start));
                }
                
                return LatinLine;
            }
            else
                return input ;
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
            if(inWord == inWord.ToUpper()) //UPPERCASE
                return CaseName.UPPER;
            if(inWord == inWord.ToLower()) //lowercase
                return CaseName.LOWER;
            return CaseName.TITLE;         //Titlecase
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
        static bool CanTranslate(string inWord)
        {
            if(Regex.IsMatch(inWord, "[^a-zA-Z,.?;:'!-]")) //if it contains a charater that isn't a letter or puctuation.
                return false;
            return true;
        }
        static bool IsPunc(char letter) 
        {
            switch(letter)
            {
                case '.': case ',': case '?': case ';': case '!': case ':':
                    return true;
                default:
                    return false;
            }
        }
        static void Main(string[] args)
        {
            string input;
            string isStop;
            while (true)
            {
                System.Console.WriteLine("Enter a line to be translated:");
                input = System.Console.ReadLine();
                System.Console.WriteLine(LineToPigLatin(input));
                isStop = "";
                while(!(isStop.Length != 0 && (isStop.ToLower()[0] == 'y' || isStop.ToLower()[0] == 'n')))
                {
                    System.Console.WriteLine("Continue?(Y/N)");
                    isStop = System.Console.ReadLine();
                }
                if(isStop.ToLower()[0] == 'n')
                    break;

            }
        }
    }
}
