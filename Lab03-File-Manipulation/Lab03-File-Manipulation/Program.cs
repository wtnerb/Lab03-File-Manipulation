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
            string[] wordList = WordList(MY_PATH);
            while (playing)
            {
                Console.Clear();
                Console.WriteLine("Would you like to play a game?");
                Console.WriteLine("1. Play with random word\n" +
                                  "2. Add a word to list\n" +
                                  "3. Remove a word from list\n" +
                                  "4. Display word list\n" +
                                  "5+ quit.");
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
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                switch (option) // making sure this works in c# like in other languages. It does.
                {
                    case 1:
                        //GuessingLoop(wordList[rand.Next(0, wordList.Length)]);
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
                        //RemoveWord();
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
                    foreach(string w in wl)
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
    }
}
