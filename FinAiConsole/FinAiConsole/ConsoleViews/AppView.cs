using System;
using System.Collections.Generic;
using System.Linq;

namespace FinAiConsole.ConsoleViews
{
    public class AppView : IAppView
    {
        public void DisplayBlogHeader(IEnumerable<string> headers)
        {
            foreach (string item in headers)
            {
                Console.WriteLine(item);
            }
        }

        public void DisplayHeaderLetters(IDictionary<char, int> letters)
        {
            foreach (KeyValuePair<char, int> entry in letters.OrderBy(l => l.Key))
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
