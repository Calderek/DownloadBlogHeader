using FinAiConsole.Abstract;
using FinAiConsole.Helpers;
using HtmlAgilityPack;
using System.Net;
using System.Web;

namespace FinAiConsole.Logics
{
    class HtmlContentProvider : IHtmlContentProvider
    {
        public string LoadBlogHtmlPage(int page)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(GetUrlPage(page));
            }
        }

        private string GetUrlPage(int i)
        {
            return $"{AppHelper.BlogPageUrl}{i}";
        }

        public HtmlNodeCollection GetHeadersByClass(string htmlPage)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlPage);
            return doc.DocumentNode.SelectNodes("//a[contains(@class, 'entry-title')]");
        }

        public string GetUtfTitleHeaderFromNode(HtmlNode headerNode)
        {
            return HttpUtility.HtmlDecode(headerNode.InnerHtml);
        }


    }
}
