using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace PitchAndShiftAudio
{

    class LastFMFS : BaseWService, IBaseWService
    {
        // Get your own API_KEY and API_SECRET from http://www.last.fm/api/account
        string API_KEY = null;
        string API_SECRET = null;
        const string ROOT_URL = "http://ws.audioscrobbler.com/2.0/";

        //public WebProxy Proxy { get; set; }

        public LastFMFS(string apikey, string apisecret)
        {
            API_KEY = apikey;
            API_SECRET = apisecret;
        }

        //public static bool HasError(string xml)
        //{
        //    // Be sure to set a reference to System.Core and System.Xml.Linq 
        //    XElement states = XElement.Parse(xml);

        //    // Using LINQ             
        //    XElement foundNode;
        //    var query = from XElement r in states.Descendants("lfm")
        //                where r.Attribute("error").Value != null
        //                select r;
            
        //    foundNode = query.FirstOrDefault();

        //    return foundNode != null;
        //}


        private string ParamToString(Dictionary<string, string> param)
        {
            StringBuilder sburl = new StringBuilder();

            foreach (KeyValuePair<String, String> entry in param)
            {
                sburl.Append('&');
                sburl.Append(entry.Key);
                sburl.Append('=');
                sburl.Append(entry.Value);
            }

            return sburl.ToString();
        }

        public string CallSearchMethod(string name, Dictionary<string, string> param)
        {
            string urlparam = ParamToString(param);

            StringBuilder sburl = new StringBuilder();

            sburl.Append(String.Format("{0}?method={1}&api_key={2}{3}", ROOT_URL, name, API_KEY, urlparam));

            string response = GetResponseFromRequest(sburl.ToString());

            return response;
        }

    }
}
