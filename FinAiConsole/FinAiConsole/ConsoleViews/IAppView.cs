using System.Collections.Generic;

namespace FinAiConsole.ConsoleViews
{
    public interface IAppView
    {
        void DisplayBlogHeader(IEnumerable<string> headers);
        void DisplayHeaderLetters(IDictionary<char, int> letters);
    }
}
