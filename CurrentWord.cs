using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class CurrentWord
    {
        static string guesses = "";
        static int chances = 6;

        public static void getWord(string word)
        {

            char userGuess;
            char[] letters = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                letters[i] += '_';
            }
        
            while (chances > 0)
            {
                int incorrect = 0;

                printLetters(letters);

                userGuess = getUserInput();
                
                //checks if input is correct
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == userGuess)
                    {
                        letters[i] = word[i];
                    }
                    else
                    {
                        incorrect++;
                    }
                }

                //lose chance if inut had no match for each letter
                if (incorrect == word.Length)
                {
                    chances--;
                    if (chances == 0)
                    {
                        Console.WriteLine($"You Lose!");
                    }
                }

                checkForWin(letters, word);

            }
        }
        public static void printLetters(char[] letters)
        {
            foreach (char c in letters)
            {
                Console.Write(c + " ");
            }
        }
        public static char getUserInput()
        {
            char userGuess;

            Console.Write($"\nChances Left: {chances}\nGuess a Letter: ");
            userGuess = Convert.ToChar(Console.ReadLine());

            
            if (Char.IsLetterOrDigit(userGuess) == false || Char.IsDigit(userGuess) == true)
            {
                Console.WriteLine("Not a letter\n");
            }
            else
            {
                guesses += userGuess + " ";
                Console.WriteLine($"\nLetters guessed: {guesses}\n");
            }
                return userGuess;
        }
        public static void checkForWin(char[] letters, string word)
        {
            string checkWord = "";

            //puts each char from letters into a new string
            foreach (char c in letters)
            {
                checkWord += c;
            }

            //checks if user guessed all the letters
            if (checkWord == word)
            {
                printLetters(letters);
                Console.WriteLine($"\nYou win!");               
            }
        }


    }
}
