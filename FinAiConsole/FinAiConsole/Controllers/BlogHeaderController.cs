using FinAiConsole.Abstract;
using FinAiConsole.ConsoleViews;
using FinAiConsole.Helpers;
using FinAiConsole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinAiConsole.Controllers
{
    public class BlogHeaderController
    {
        private readonly IHtmlContentProvider _htmlProvider;
        private readonly IAppView _viewsProvider;
        private readonly IFileHelper _file;
        private readonly ILettersDeterminant _lettersDeterminant;

        public BlogHeaderController(IHtmlContentProvider htmlProvider, IAppView viewProvider, IFileHelper fileHelper, ILettersDeterminant lettersDetermaint)
        {
            _htmlProvider = htmlProvider;
            _viewsProvider = viewProvider;
            _file = fileHelper;
            _lettersDeterminant = lettersDetermaint;
        }

        public void GetLetters()
        {
            IncrementeNextAttempt();
            var headers = Get20BlogPost();

            if (AppHelper.HasDisplayHeaders)
                _viewsProvider.DisplayBlogHeader(headers);

            var letters = _lettersDeterminant.DetermineLetterFromHeaders(headers).ToDictionary(l => l.Key, l => l.Value);

            LetterAttempt entity = new LetterAttempt { Attempt = AppHelper.IterationNumber, Letters = letters };

            var entities = LoadAttempts();
            entities.Add(entity);
            SaveAttempts(entities);

            _viewsProvider.DisplayHeaderLetters(letters);
        }

        private void SaveAttempts(IList<LetterAttempt> entities)
        {
            string json = JsonConvert.SerializeObject(entities);
            _file.Save(AppHelper.JsonFile, json);
        }

        private IList<LetterAttempt> LoadAttempts()
        {
            var entities = new List<LetterAttempt>();
            try
            {
                entities = JsonConvert.DeserializeObject<List<LetterAttempt>>(_file.Load(AppHelper.JsonFile));

                if (entities.Count >= 5)
                    RemoveEarliestAttempt(entities);
            }
            catch (Exception)
            {
                if (AppHelper.IterationNumber > 1)
                    Console.WriteLine("Failed to load file");
                entities = new List<LetterAttempt>();
            }
            return entities;
        }

        private void RemoveEarliestAttempt(IList<LetterAttempt> entities) => entities.RemoveAt(0);

        private void IncrementeNextAttempt() => AppHelper.IterationNumber++;

        private IEnumerable<string> Get20BlogPost()
        {
            int headerNumber = 0;
            var headers = new List<string>();
            for (int i = 0; i <= AppHelper.NeedPage - 1; i++)
            {

                string htmlCode = _htmlProvider.LoadBlogHtmlPage(i + 1);
                var headersTag = _htmlProvider.GetHeadersByClass(htmlCode);

                foreach (var s in headersTag)
                {
                    if (headerNumber < AppHelper.HeaderAmount)
                    {
                        headerNumber++;
                        headers.Add(_htmlProvider.GetUtfTitleHeaderFromNode(s));
                    }
                    else return headers;
                }

            }
            return headers;
        }



    }
}
