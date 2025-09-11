using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. hard coded hangman
            string word = "Sequence";
            char userGuess= ' ';
            int chances = 6;
            string guesses = "";
            char[] letters = new char[word.Length];

            Console.WriteLine("1. Hard Coded Hangman\n");

            //assigns each element in letters array to an underscore
            for (int i = 0; i < word.Length; i++)
            {
                letters[i] += '_';
            }

            //loops until user runs out of chances
            while (chances > 0)
            {
                int incorrect = 0;
                string checkWord = "";

                //prints out each letter / underscore
                foreach (char c in letters)
                {
                    Console.Write(c + " ");
                }

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

                //checks if user guess is an int or non letter char
                if (Char.IsLetter(userGuess) == false)
                {
                    Console.WriteLine("Not a letter\n");
                   // continue;
                }
                else
                {
                    if (userGuess == 's')
                    {
                        //makes user guess capital S
                        userGuess = Char.ToUpper(userGuess);
                    }

                    //add guesses to string + print list of guesses
                    guesses += userGuess + " ";
                    Console.WriteLine($"\nLetters guessed: {guesses}\n");

                    for (int i = 0; i < word.Length; i++)
                    {
                        //checks each letter in word to see if their guess is a match
                        if (word[i] == userGuess)
                        {
                            letters[i] = word[i];
                        }
                        //keeps track if the amount of times there wasn't a matching letter
                        else
                        {
                            incorrect++;
                        }
                    }

                    //if each letter in word (8) didn't have a match, lose a guess / print 
                    if (incorrect == word.Length)
                    {
                        chances--;
                        if (chances == 0)
                        {
                            Console.WriteLine($"You Lose!");
                        }
                    }

                    //puts each char from letters into a new string
                    foreach (char c in letters)
                    {
                        checkWord += c;
                    }

                    //checks if user guessed all the letters
                    if (checkWord == word)
                    {
                        foreach (char c in letters)
                        {
                            Console.Write(c + " ");
                        }
                        Console.WriteLine($"\nYou win!");
                        break;
                    }
                }
            }

            // 2. OOP hangman

            Console.WriteLine("\n\n2. Random Word Hangman\n");

            Boolean playAgain = true;
            string[] wordArray = { "music", "cartoon", "chicken", "snow", "painting", "gnome", "astronaut", "video", "alien", "landmark", "museum", "spice", "square", "lime", "doctor" };

            Random randomNum = new Random();     //generate random num

            //generates new num / word to send to currentWord
            while (playAgain)
            {
                int wordIndex = randomNum.Next(15);

                CurrentWord newWord = new CurrentWord(wordArray[wordIndex]);

                playAgain = newWord.getWord();
            }
        }
    }
}

