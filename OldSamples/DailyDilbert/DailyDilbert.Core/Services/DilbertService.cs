using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace DailyDilbert.Core
{
    public class DilbertService : IDilbertService
    {
        public void GetFeedItems(Action<List<DilbertItem>> success, Action<Exception> error)
        {
            var url = "http://feed.dilbert.com/dilbert/daily_strip";

            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.BeginGetResponse(result => ProcessResponse(success, error, request, result), null);
            }
            catch (Exception exception)
            {
                error(exception);
            }
        }

        private void ProcessResponse(Action<List<DilbertItem>> success, Action<Exception> error, HttpWebRequest request, IAsyncResult result)
        {
            try
            {
                var response = request.EndGetResponse(result);
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var text = reader.ReadToEnd();
                    var list = ParseDilbertItemList(text);
                    success(list);
                }
            }
            catch (Exception exception)
            {
                error(exception);
            }
        }

        private List<DilbertItem> ParseDilbertItemList(string text)
        {
            var xml = XDocument.Parse(text);
            var items = xml.Descendants("item");
            var list = items.Select(x =>
                                    new DilbertItem()
                                        {
                                            Title = x.Element("title").Value,
                                            StripUrl = ExtractHttpImg(x.Element("description").Value)
                                        }).ToList();
            return list;
        }

        private string ExtractHttpImg(string value)
        {
            var startPos = value.IndexOf("http://");
            var endPos = value.IndexOf(".gif\"", startPos);
            return value.Substring(startPos, endPos + 4 - startPos);
        }
    }
}