using FinAiConsole.Helpers;
using System;
using System.Threading;

namespace FinAiConsole.Logics
{
    public static class CycleTimer
    {
        private static TimeSpan startTimeSpan = TimeSpan.Zero;
        private static TimeSpan periodTimeSpan = TimeSpan.FromMinutes(AppHelper.LoadingMinuts);

        public static Timer Start(Action executeAction)
        {
            return new Timer((e) =>
           {
               executeAction();
           }, null, startTimeSpan, periodTimeSpan);
        }
    }
}
