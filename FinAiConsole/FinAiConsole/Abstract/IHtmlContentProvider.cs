using HtmlAgilityPack;

namespace FinAiConsole.Abstract
{
    public interface IHtmlContentProvider
    {
        string LoadBlogHtmlPage(int page);
        HtmlNodeCollection GetHeadersByClass(string htmlPage);
        string GetUtfTitleHeaderFromNode(HtmlNode headerNode);
    }
}
