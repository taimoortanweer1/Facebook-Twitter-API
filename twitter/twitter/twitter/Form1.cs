using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlchemyAPI;
using System.IO;
using Tweetinvi;
using Newtonsoft.Json;
using TweetSharp;
using System.Net;
using System.Collections.Specialized;
using System.Xml;
using HtmlAgilityPack;
using Abot.Crawler;
using Abot.Poco;

namespace twitter
{
    public partial class Form1 : Form
    {
        string consumerKey = "pNpMDTAW5Q0MACi912iQ8BhVy";
        string consumerSecret = "NyhsqogTpY2996YUQv5fLMzleIVsZxbLtLLCUYEfVhKrmgAHKO";
        string accessToken = "355691359-jTZR3A9ZYj4yZxfuDcGs0tWz2z9IzaFo5wMkpGua";
        string accessTokenSecret = "oP2Zh0h9oScRoIV6hOP7jtMk0qJoYW5gvDkSm2z568ESI";
        public Form1()
        {
               
            InitializeComponent();
            
        }
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            
            TwitterService twitterService = new TwitterService();
            AlchemyAPI.AlchemyAPI alchemyObj = new AlchemyAPI.AlchemyAPI();
            alchemyObj.LoadAPIKey("api_key.txt");
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            //IEnumerable<TwitterStatus> tweets = twitterService.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
            var tweets_search = twitterService.Search(new SearchOptions { Q = "zardari", Count = 10 });

            if (tweets_search != null)
            {

                foreach (var tweet in tweets_search.Statuses)
                {
                    //System.Diagnostics.Debug.WriteLine("{0} says '{1}", tweet.User.ScreenName, tweet.Text);

                    string xml = alchemyObj.TextGetTextSentiment("");

                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("FAIL");
            }                 
        }
        private void bttnsentiment_Click(object sender, EventArgs e)
        {            
            // Load an API key from disk.                                    
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

             String url = "http://www.csc.ncsu.edu/faculty/healey/tweet_viz/tweet_app/";
            PersonalityAnalysisTwitterWiz(webBrowser1, url, txtBxSearch.Text);

        }
        private void PersonalityAnalysisTwitterWiz(WebBrowser Wb, String Url, String AliasName)
        {
            //<button id="query-btn" type="submit" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" role="button" aria-disabled="false"><span class="ui-button-text">Query</span></button>
            //<input id="query-inp" size="50" type="text" data-hasqtip="true" oldtitle="Keywords:" title="" aria-describedby="qtip-0">

            Wb.Navigate(Url);

            //wait for complete load
            while (Wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            //hiding extra blocks
            HtmlElement HEC = Wb.Document.Body;
      
            HEC.Children[0].Style = "display:none;";
            HEC.Children[2].Style = "display:none;";
            HEC.Children[5].Style = "display:none;";
            HEC.Children[8].Style = "display:none;";
            HEC.Children[11].Style = "display:none;";
            HEC.Children[14].Style = "display:none;";
            HEC.Children[17].Style = "display:none;";
            HEC.Children[19].Style = "display:none;";
            
            //applying query
            if (Wb.Document != null)
            {                             
                HtmlElement elem = Wb.Document.GetElementById("query-inp");
                elem.InnerText = AliasName;
                elem = Wb.Document.GetElementById("query-btn");
                elem.InvokeMember("click");                
            }
        }

        private string[] PersoanlityAnalysisByTwitterAlias( String AliasName )
        {
            string[] innerText = new string[30];
            int count = 0;
            using (WebClient client = new WebClient())
            {

                //******** Getting Response from www.AnalyseWords.com
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();               
                byte[] response =
                client.UploadValues("http://analyzewords.com/index.php?handle="+AliasName, new NameValueCollection(){});
                string result = System.Text.Encoding.UTF8.GetString(response);
                doc.LoadHtml(result);

                
                //********** Parsing the result using AgilityPack HTML Parser ***************
                foreach (var row in doc.DocumentNode.SelectNodes("//tr"))
                {
                    foreach (var cell in row.SelectNodes("td"))
                    {
                        if (cell.InnerText.Contains("&nbsp"))
                        {
                            innerText[count] = cell.InnerText;
                            innerText[count] = innerText[count].Replace("&nbsp;", "");
                            count++;
                        }
                    }
                }
            }

            return innerText;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] arr = PersoanlityAnalysisByTwitterAlias( "barackobama" );
        }
        private void GoogleLocalHost(WebBrowser Wb, String Url, String AliasName)
        {
            Wb.Navigate(Url);

            //wait for complete load
            while (Wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            //applying query
            if (Wb.Document != null)
            {
            //    HtmlElement elem = Wb.Document.GetElementById("query-inp");
            //    elem.InnerText = "BarackObama";
            //    elem = Wb.Document.GetElementById("query-btn");
            //    elem.InvokeMember("click");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GoogleLocalHost(webBrowser1, "http://localhost:8808/2pm/", "taimoor");
        }
    }
}