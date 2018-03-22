using System;
using Xunit;
using static Lab03_File_Manipulation.Program;

namespace UnitTestsForFileManipulation
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(true, "a", "cat")]
        [InlineData(false, "b", "cat")]
        public void CanMatch(bool expected, string match, string compare)
        {
            Assert.Equal(expected, MatchExists(match, compare));
        }
    }
}
