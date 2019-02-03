using FinAiConsole.Abstract;
using FinAiConsole.Helpers;
using System;
using System.Collections.Generic;

namespace FinAiConsole.Logics
{
    class LettersDeterminant : ILettersDeterminant
    {
        private IDictionary<char, int> CountLetters(string header, IDictionary<char, int> letters)
        {
            foreach (var letter in header.ToLower())
            {

                if (AppHelper.OnlyLowcaseLetter)
                    if (!Char.IsLetter(letter)) continue;


                if (!letters.ContainsKey(letter)) letters.Add(letter, 0);
                letters[letter] += 1;
            }
            return letters;
        }

        public IDictionary<char, int> DetermineLetterFromHeaders(IEnumerable<string> headers)
        {
            var letters = new Dictionary<char, int>();
            foreach (var header in headers)
            {
                letters = (Dictionary<char, int>)CountLetters(header, letters);
            }
            return letters;
        }


    }
}
