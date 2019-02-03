using System;

namespace FinAiConsole.Helpers
{
    public static class AppHelper
    {
        public static readonly int LoadingMinuts = 1;
        public static readonly bool HasDisplayHeaders = true;
        public static readonly bool OnlyLowcaseLetter = false;
        public static readonly int HeaderAmount = 20;

        //Please not change
        public static int IterationNumber = 0;
        public static readonly int NeedPage = (int)Math.Ceiling((double)HeaderAmount / HeaderInPage);
        public static readonly int HeaderInPage = 8;
        public static readonly string JsonFile = @"D:\path.json";
        public static readonly string BlogPageUrl = @"https://www.finai.pl/blog?page=";


    }

}
