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
        public static Boolean getWord(string word)
        {
            int chances = 6;
            char userGuess = ' ';
            char[] letters = new char[word.Length];
            Boolean playAgain = true;
            string guesses = "";

            //put letters
            for (int i = 0; i < word.Length; i++)
            {
                letters[i] += '_';
            }


            //loops while user wants to keep playing
            while (playAgain)
            {
                int incorrect = 0;
                Boolean userWin = false;

                printLetters(letters);

                try
                {
                    Console.Write($"\nChances Left: {chances}\nGuess a Letter: ");
                    userGuess = Convert.ToChar(Console.ReadLine());
                }
                //catches blank input
                catch
                {
                    Console.WriteLine("Not a letter\n");
                    continue;
                }
                
                //checks if input is non letter char or an int
                if (Char.IsLetter(userGuess) == false || Char.IsDigit(userGuess) == true)
                {
                    Console.WriteLine("Not a letter\n");
                }
                else
                {
                    guesses += userGuess + " ";
                    Console.WriteLine($"\nLetters guessed: {guesses}\n");
                    
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
                    userWin = checkForWin(letters, word);

                    if (userWin == false)
                    {
                        //lose chance if input had no match for each letter
                        if (incorrect == word.Length)
                        {
                            chances--;
                            if (chances == 0)
                            {
                                Console.WriteLine($"You Lose!");
                                Console.WriteLine($"Word was: {word}\n");
                            }
                        }
                    }

                    //runs if user wins or loses
                    if (chances == 0 || userWin == true)
                    {
                        Console.Write("\nPlay again? Y/N: ");
                        char temp = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.WriteLine("\n");

                        if (temp != 'Y')
                        {
                            playAgain = false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }      
            //sends playAgain back to generate new word (if Y) or to stop program
            return playAgain;
        }
        
        public static void printLetters(char[] letters)
        {
            foreach (char c in letters)
            {
                Console.Write(c + " ");
            }
        }

        public static Boolean checkForWin(char[] letters, string word)
        {
            string checkWord = "";
            Boolean temp = false;

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
                temp = true;
            }
            //return win status
            return temp;
        }


    }
}
