using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_File_Manipulation
{
    public class Word
    {
        public string Text { get; set; }
        public string[] Current { get; set; }

        public Word(string text)
        {
            Text = text;
            Current = new string[text.Length];
            for (int i = 0; i < Current.Length; i++)
            {
                Current[i] = "_";
            }
        }

        public void NextDisplay( string guess)
        {
            int ind = Text.IndexOf(guess);
            while (0 <= ind && ind < Current.Length)
            {
                Current[ind] = Text.Substring(ind, 1);
                ind = Text.IndexOf(guess, ind + 1);
            }
        }
    }
}
