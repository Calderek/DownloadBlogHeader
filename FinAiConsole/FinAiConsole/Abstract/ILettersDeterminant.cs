using System.Collections.Generic;

namespace FinAiConsole.Abstract
{
    public interface ILettersDeterminant
    {
        IDictionary<char, int> DetermineLetterFromHeaders(IEnumerable<string> headers);
    }
}
