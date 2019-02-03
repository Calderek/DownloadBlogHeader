using FinAiConsole.Abstract;
using FinAiConsole.ConsoleViews;
using FinAiConsole.Logics;

namespace FinAiConsole.Helpers
{
    class MockIoC
    {
        public IHtmlContentProvider HtmlContentProvider => new HtmlContentProvider();
        public IFileHelper FileHelper => new FileHelper();
        public IAppView View => new AppView();
        public ILettersDeterminant LettersDeterminant => new LettersDeterminant();

    }


}

