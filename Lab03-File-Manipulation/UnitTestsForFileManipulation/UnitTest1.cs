using System;
using Xunit;
using System.IO;
using Lab03_File_Manipulation;

namespace UnitTestsForFileManipulation
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(true, "a", "cat")]
        [InlineData(false, "b", "cat")]
        public void CanMatch(bool expected, string match, string compare)
        {
            Assert.Equal(expected, Program.MatchExists(match, compare));
        }

        [Fact]
        public void CanGetWordList()
        {
            string words = "blue green\nred";
            string[] expect = { "blue", "green", "red" };
            string path = "..\\..\\testcase.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(words);
                }
            }
            catch
            {
                throw;
            }
            Assert.Equal(expect, Program.WordList(path));
        }

        [Fact]
        //[InlineData("_ _ _ _ n ", {"_", "_", "_", "_", "_"}, "green", "n")]
        public void CanJudgeGuess()//(string expected, string current, string word, string guess)
        {
            string[] expected = { "_", "_", "e", "e", "_" };
            Word w = new Word("green");
            w.NextDisplay("e");
            Assert.Equal(expected, w.Current);
        }

        [Fact]
        public void CanAddWord()
        {
            string words = "blue green\nred";
            string path = "..\\..\\testcase.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(words);
                }
            }
            catch
            {
                throw;
            }
            Assert.Equal(-1, (Array.IndexOf(Program.WordList(path), "blueberry")));
            Program.AddWord("blueberry", path, Program.WordList(path));
            Assert.NotEqual(-1, (Array.IndexOf(Program.WordList(path), "blueberry")));
        }
    }
}
