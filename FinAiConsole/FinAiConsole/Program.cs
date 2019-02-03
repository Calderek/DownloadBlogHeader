using FinAiConsole.Controllers;
using FinAiConsole.Helpers;
using FinAiConsole.Logics;

namespace FinAiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var cycleTimer = CycleTimer.Start(CycleExecute);
            ContinueWithoutExit();
        }

        private static void ContinueWithoutExit()
        {
            while (true) { }
        }

        private static void CycleExecute()
        {
            MockIoC ioc = new MockIoC();
            var controller = new BlogHeaderController(ioc.HtmlContentProvider,
                ioc.View, ioc.FileHelper, ioc.LettersDeterminant);
            controller.GetLetters();
        }

    }
}
