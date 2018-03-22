using System;
using System.Text.RegularExpressions;

namespace Lab03_File_Manipulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool MatchExists(string match, string source)
        {
            Regex rx = new Regex(match);
            return rx.IsMatch(source);
        }
    }
}
