namespace FinAiConsole.Abstract
{
    public interface IFileHelper
    {
        void Save(string path, string content);
        bool Exists(string path);
        string Load(string path);
    }
}
