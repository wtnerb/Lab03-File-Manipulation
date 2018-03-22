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
    }

    
}
