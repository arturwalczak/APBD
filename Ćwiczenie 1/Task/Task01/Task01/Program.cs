using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Task01
{
    public class Program
    {

        private static bool UrlValid(string url)
        {            
                Uri uriResult;
                bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                return result;            
        }

        private static void FindEmails(string text)
        {
            const string MatchEmailPattern =
      @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
      + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
      + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
      + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

            Regex rx = new Regex(
              MatchEmailPattern,
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find matches.
            MatchCollection matches = rx.Matches(text);
            
            List<string> urlList = new List<string>();
            foreach (Match match in matches)
            {
                urlList.Add(match.Value.ToString());
            }
            urlList = urlList.Distinct().ToList();
            foreach (string url in urlList)
            {
                Console.WriteLine(url);
            }


        }

        static async Task Main(string[] args)
        {
            string websiteUrl = args[0];
            if (websiteUrl != null) using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(websiteUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            string result = content.ReadAsStringAsync().Result;
                            if (UrlValid(websiteUrl))
                            {
                                FindEmails(result);
                            }
                            else
                                throw new ArgumentException("url not valid");                         
                            
                            
                        }
                    }
                }
            else
                throw new ArgumentNullException("no url provided");



        }




    }

}

