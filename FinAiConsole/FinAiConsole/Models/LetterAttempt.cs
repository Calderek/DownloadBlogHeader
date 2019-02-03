using System.Collections.Generic;

namespace FinAiConsole.Models
{
    class LetterAttempt
    {
        public int Attempt { get; set; }
        public Dictionary<char, int> Letters { get; set; }
    }
}
