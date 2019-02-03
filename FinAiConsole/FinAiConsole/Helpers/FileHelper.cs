using FinAiConsole.Abstract;
using System.IO;

namespace FinAiConsole.Helpers
{
    public class FileHelper : IFileHelper
    {
        public void Save(string path, string content)
        {
            //For simplify not be check available exceptions such as ovverride file when is used and other.
            File.WriteAllText(path, content);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string Load(string path)
        {
            return Exists(path) ? File.ReadAllText(path) : null;
        }
    }
}
