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
                Console.WriteLine("Broke it.");
            }
        }

        public static bool MatchExists(string match, string source)
        {
            Regex rx = new Regex(match);
            return rx.IsMatch(source);
        }
        

    }

    
}
