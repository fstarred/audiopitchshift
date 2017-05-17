using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace PitchAndShiftAudio
{
    class BaseWService
    {
        public WebProxy Proxy { get; set; }

        public const int REQUEST_TIMEOUT_MS = 4000;

        private string appver = null;        

        protected BaseWService()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            appver = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion.ToString(); 
        }

        protected string GetResponseFromRequest(string url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)(WebRequest.Create(new Uri(url)));
            request.Timeout = REQUEST_TIMEOUT_MS;
            request.UserAgent = String.Format( "{0}/{1} ( {2} )", Globals.AppTitle, appver, Globals.AppHomepage);
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.ContentLength = 0;

            StreamReader ReadStream = null;
            HttpWebResponse Response = null;
            string ResponseText = string.Empty;

            request.Proxy = this.Proxy;

            try
            {
                Response = (HttpWebResponse)(request.GetResponse());
                Stream ReceiveStream = Response.GetResponseStream();
                ReadStream = new StreamReader(ReceiveStream, System.Text.Encoding.UTF8);
                ResponseText = ReadStream.ReadToEnd();
                Response.Close();
                ReadStream.Close();

            }
            catch (Exception e)
            {
                ResponseText = string.Empty;
                throw e;
            }

            return ResponseText;
        }

    }
}
