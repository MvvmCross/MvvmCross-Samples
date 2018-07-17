using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TwitterSearch.Core.Models
{
    public class TwitterSearch
    {
        public static void StartAsyncSearch(string searchText, Action<IEnumerable<Tweet>> success, Action<Exception> error)
        {
            DoAsyncSearch(searchText, success, error);
        }

        private static void DoAsyncSearch(string searchText, Action<IEnumerable<Tweet>> success, Action<Exception> error)
        {
            var search = new TwitterSearch(searchText, success, error);
            search.StartSearch();
        }

        private const string TwitterUrl = "https://api.twitter.com/1.1/search/tweets.json?count=100&result_type=popular&q=";

        private readonly string _searchText;
        private readonly Action<IEnumerable<Tweet>> _success;
        private readonly Action<Exception> _error;

        private TwitterSearch(string searchText, Action<IEnumerable<Tweet>> success, Action<Exception> error)
        {
            _searchText = searchText;
            _success = success;
            _error = error;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        private void HandleData(string data)
        {
            var doc = XDocument.Parse(data);
            var items = doc.Descendants(AtomConst.Entry)
                .Select(entryElement => new Tweet()
                {
                    Title = entryElement.Descendants(AtomConst.Title).Single().Value,
                    Id = long.Parse(entryElement.Descendants(AtomConst.ID).Single().Value.Split(':')[2]),
                    ProfileImageUrl = entryElement.Descendants(AtomConst.Link).Skip(1).First().Attribute("href").Value,
                    Timestamp = DateTime.Parse(entryElement.Descendants(AtomConst.Published).Single().Value),
                    Author = entryElement.Descendants(AtomConst.Name).Single().Value
                });
            _success(items);
        }
        private string RemoveHeader(ref WebHeaderCollection tmpheader, string headname)
        {
            try
            {
                if (tmpheader == null)
                {
                    return null;
                }
                string str = tmpheader.Get(headname);
                if (str != null)
                {
                    tmpheader.Remove(headname);
                }
                return str;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
        private void StartSearch()
        {
            try
            {
                var timestamp = DateTime.Now.ToBinary();

                // perform the search
                string uri = TwitterUrl + _searchText;

                Task.Run(()=> {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
                        var response = (HttpWebResponse)request.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string str = reader.ReadToEnd();
                        HandleData(str);
                    }
                    catch (Exception exception)
                    {
                        _error(exception);
                    }
                });
            }
            catch (Exception exception)
            {
                _error(exception);
            }
        }

       
    }
}