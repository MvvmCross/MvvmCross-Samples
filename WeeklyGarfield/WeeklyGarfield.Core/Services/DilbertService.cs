using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace DailyGarfield.Core
{
    public class GarfieldService : IGarfieldService
    {
        public void GetFeedItems(Action<List<GarfieldItem>> success, Action<Exception> error)
        {
            var url = "http://www.hoodcomputing.com/garfield.php";

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

        private void ProcessResponse(Action<List<GarfieldItem>> success, Action<Exception> error, HttpWebRequest request, IAsyncResult result)
        {
            try
            {
                var response = request.EndGetResponse(result);
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var text = reader.ReadToEnd();
                    var list = ParseGarfieldItemList(text);
                    success(list);
                }
            }
            catch (Exception exception)
            {
                error(exception);
            }
        }

        private List<GarfieldItem> ParseGarfieldItemList(string text)
        {
            var xml = XDocument.Parse(text);
            var items = xml.Descendants("item");
            var list = items.Select(x =>
                                    new GarfieldItem()
                                    {
                                        Title = x.Element("title").Value,
                                        StripUrl = ExtractHttpImg(x.Element("link").Value)
                                    }).ToList();
            return list;
        }

        private string ExtractHttpImg(string value)
        {
            var startPos = value.IndexOf("https://");
            var endPos = value.IndexOf(".gif", startPos);
            return value.Substring(startPos, endPos + 4 - startPos);
        }
    }
}