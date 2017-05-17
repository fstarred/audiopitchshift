using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace PitchAndShiftAudio
{
    class MusicBrainz : BaseWService, IBaseWService
    {
        const string ROOT_URL = "http://musicbrainz.org/ws/2/";
        const string ROOT_COVER_ART_URL = "http://coverartarchive.org/";

        private string SearchParamToString(Dictionary<string, string> param)
        {
            StringBuilder sburl = new StringBuilder();

            foreach (KeyValuePair<String, String> entry in param)
            {
                sburl.Append("+AND+");
                sburl.Append(entry.Key);
                sburl.Append(':');
                sburl.Append(entry.Value);                
            }

            if (param.Count > 0)
                sburl.Remove(0, 5);

            return sburl.ToString();
        }


        private string BrowseParamToString(Dictionary<string, string> param)
        {
            StringBuilder sburl = new StringBuilder();

            foreach (KeyValuePair<String, String> entry in param)
            {
                sburl.Append("&");
                sburl.Append(entry.Key);
                sburl.Append('=');
                sburl.Append(entry.Value);
            }

            return sburl.ToString();
        }


        private string LookupParamToString(Dictionary<string, string> param)
        {
            StringBuilder sburl = new StringBuilder();

            foreach (KeyValuePair<String, String> entry in param)
            {
                sburl.Append("?");
                sburl.Append(entry.Key);
                sburl.Append('=');
                sburl.Append(entry.Value);
            }

            return sburl.ToString();
        }

        public string CallSearchMethod(string name, Dictionary<string, string> param)
        {
            string urlparam = SearchParamToString(param);

            StringBuilder sburl = new StringBuilder();

            sburl.Append(String.Format("{0}{1}/?query={2}", ROOT_URL, name, urlparam));

            string response = GetResponseFromRequest(sburl.ToString());

            return response;
        }

        public string CallBrowseMethod(string name, string mbid, Dictionary<string, string> param)
        {
            string urlparam = BrowseParamToString(param);

            StringBuilder sburl = new StringBuilder();

            sburl.Append(String.Format("{0}{1}={2}{3}", ROOT_URL, name, mbid, urlparam));

            string response = GetResponseFromRequest(sburl.ToString());

            return response;
        }


        public string CallLookupMethod(string name, string mbid, Dictionary<string, string> param)
        {
            string urlparam = LookupParamToString(param);

            StringBuilder sburl = new StringBuilder();

            sburl.Append(String.Format("{0}{1}/{2}{3}", ROOT_URL, name, mbid, urlparam));

            string response = GetResponseFromRequest(sburl.ToString());

            return response;
        }


        public string GetImageUrl(string name, string id, string objreq)
        {
            return String.Format("{0}{1}/{2}/{3}", ROOT_COVER_ART_URL, name, id, objreq);
        }
    }
}
