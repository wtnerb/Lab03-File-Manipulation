using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Lab03_File_Manipulation
{
    public class Program
    {
        public static string MY_PATH = "..\\..\\..\\..\\words.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string words = "blue green red";
            try
            {
                using (StreamWriter sw = new StreamWriter(MY_PATH))
                {
                    sw.Write(words);
                }
            }
            catch
            {
                throw;
            }
            GameLoop();
        }

        static void GameLoop()
        {
            Boolean playing = true;
            Random rand = new Random();
            while (playing)
            {
                string[] wordList = WordList(MY_PATH);
                Console.Clear();
                Console.WriteLine("Would you like to play a game?");
                Console.WriteLine("1. Play with random word\n" +
                                  "2. Add a word to list\n" +
                                  "3. Remove a word from list\n" +
                                  "4. Display word list\n" +
                                  "5. quit.");
                byte option = 0;
                for (byte count = 0; count < 10 && option < 1; count++)
                {
                    try
                    {
                        option = byte.Parse(Console.ReadLine());
                        if (option < 1)
                        {
                            throw new Exception("Run git blame");
                        }
                        if (option > 5)
                        {
                            throw new Exception("invald input, number too large!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                switch (option) // making sure this works in c# like in other languages. It does.
                {
                    case 1:
                        GuessingLoop(wordList[rand.Next(0, wordList.Length)]);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("What word would you like to add?");
                        string w = Console.ReadLine().ToLower();
                        if (Array.Exists(wordList, x=> x == w))
                        {
                            Console.WriteLine("That word already exists in the list!\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                        }
                        AddWord(w, MY_PATH, wordList);
                        break;
                    case 3:
                        RemoveWord(wordList);
                        break;
                    case 4:
                        Console.Clear();
                        foreach(string wrd in wordList)
                        {
                            Console.WriteLine(wrd);
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        playing = false;
                        break;
                    default: throw new Exception("this should never run");
                }
            }

        }

        public static bool MatchExists(string match, string source)
        {
            Regex rx = new Regex(match);
            return rx.IsMatch(source);
        }

        public static string[] WordList(string path)
        {
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch
            {
                throw;
            }
            Regex whiteSpace = new Regex("\\s+");
            return whiteSpace.Replace(text, ",").Split(',');
        }

        public static void AddWord (string word, string path, string[] wl)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(word);
                    foreach (string w in wl)
                    {
                        sw.WriteLine(w);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static void RemoveWord(string[] wordList)
        {
            Console.WriteLine("What word would you like to remove?");
            string word = Console.ReadLine().ToLower();
            int ind = Array.IndexOf(wordList, word);
            if (ind == -1)
            {
                Console.WriteLine("Could not find that word in the list. Try again?");
            }
            else
            {
                wordList[ind] = "";
                using (StreamWriter sw = new StreamWriter(MY_PATH))
                {
                    foreach (string w in wordList)
                    {
                        sw.WriteLine(w);
                    }
                }
                Console.WriteLine("success!");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void GuessingLoop(string w)
        {
            Word wrd = new Word(w);
            while (-1 != Array.IndexOf(wrd.Current, "_"))
            {
                Console.Clear();
                string letter = "";
                wrd.Display();
                Console.WriteLine("What letter would you like to guess next?");
                try
                {
                    letter = Console.ReadLine().ToLower();
                    if (letter.Length > 1 || letter.Length == 0)
                    {
                        throw new Exception("invalid input");
                    }
                    wrd.NextDisplay(letter);
                }
                catch
                {
                    Console.WriteLine("Sorry, that input was not processed correctly.");
                }
            }
            Console.WriteLine($"Congratulations, you guessed the word {wrd.Text.ToUpper()}!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
