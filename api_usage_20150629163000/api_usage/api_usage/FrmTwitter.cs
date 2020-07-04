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

using Newtonsoft.Json;
using TweetSharp;
using System.Reflection;
using System.Net;
using System.Collections;
using System.Windows.Documents;

namespace api_usage
{
    public partial class FrmGooglePlus : Form
    {
        string consumerKey = "pNpMDTAW5Q0MACi912iQ8BhVy";
        string consumerSecret = "NyhsqogTpY2996YUQv5fLMzleIVsZxbLtLLCUYEfVhKrmgAHKO";
        string accessToken = "355691359-jTZR3A9ZYj4yZxfuDcGs0tWz2z9IzaFo5wMkpGua";
        string accessTokenSecret = "oP2Zh0h9oScRoIV6hOP7jtMk0qJoYW5gvDkSm2z568ESI";
        TwitterSearch ts = new TwitterSearch(
            "pNpMDTAW5Q0MACi912iQ8BhVy",
            "NyhsqogTpY2996YUQv5fLMzleIVsZxbLtLLCUYEfVhKrmgAHKO",
            "355691359-jTZR3A9ZYj4yZxfuDcGs0tWz2z9IzaFo5wMkpGua",
            "oP2Zh0h9oScRoIV6hOP7jtMk0qJoYW5gvDkSm2z568ESI");

        TwitterSearch gs = new TwitterSearch(
            "pNpMDTAW5Q0MACi912iQ8BhVy",
            "NyhsqogTpY2996YUQv5fLMzleIVsZxbLtLLCUYEfVhKrmgAHKO",
            "355691359-jTZR3A9ZYj4yZxfuDcGs0tWz2z9IzaFo5wMkpGua",
            "oP2Zh0h9oScRoIV6hOP7jtMk0qJoYW5gvDkSm2z568ESI");
        
        public FrmGooglePlus()
        {
            InitializeComponent();
        }
        private void TW_lblSearch_Click(object sender, EventArgs e)
        {

        }
        private void FrmTwitter_Load(object sender, EventArgs e)
        {

        }
        private void TW_pbxSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Text = TW_txtBQueryString.Text;
            TW_lbSearchResult.Items.Clear();
            ts.ResultSearch.Clear();
            ts.ResultSearchTweet.Clear();

            if (TW_cmbType.Text == "user")
            {
              
                ts.TW_UserSearchByName(TW_txtBQueryString.Text, TW_cmbLimit.Text);
                foreach (KeyValuePair<string, string> item in ts.ResultSearch)
                {
                    TW_lbSearchResult.Items.Add(item.Value.ToString());
                }
            }

            if (TW_cmbType.Text == "tweet")
            {
                List<Tuple<String, String, String, String>> temp = new List<Tuple<string, string, string, string>>();
                temp = ts.TW_TweetSearchByKeyword(TW_txtBQueryString.Text, TW_cmbLimit.Text);
                dgvLoadSearchedTweets(temp);

            }
            Cursor.Current = Cursors.Default;

           
        }
        private void TW_lbSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Text = TW_lbSearchResult.SelectedItem.ToString();
            //*** accessing selected item's index from the main search list 
            TW_dgvProfileInfo.DataSource = null;
            TW_dgvProfileInfo.Rows.Clear();
            TW_dgvProfileInfo.Refresh();
            KeyValuePair<String, String> pair = ts.ResultSearch.ElementAt(TW_lbSearchResult.SelectedIndex);

            //*** result in TwitterData
            ts.TW_UserDataByID(pair.Key.ToString());
            GridViewUpdate(ts.TwitterData, TW_dgvProfileInfo);
            
            var nameOfProperty = "ProfileImageUrl";
            var propertyInfo = ts.TwitterData.GetType().GetProperty(nameOfProperty);
            var value = propertyInfo.GetValue(ts.TwitterData, null);
            value = ts.TwitterData.ProfileImageUrl.ToString();
            TW_pbxProfile.Image = GetImageFromUrl(value);
            Cursor.Current = Cursors.Default;
        }
        private void GridViewUpdate(object data, DataGridView MydataGridView)
        {

            int Count = 0;

            //** dont add if columns are already there
            if (MydataGridView.ColumnCount != 2)
            {
                MydataGridView.Columns.Add("Fields", "Fields");
                MydataGridView.Columns.Add("Values", "Values");
            }

            //** setting col width manually
            DataGridViewColumn column0 = MydataGridView.Columns[0];
            column0.Width = 100;

            DataGridViewColumn column = MydataGridView.Columns[1];
            column.Width = 820;
            MydataGridView.Rows.Clear();


            Count = 0;
            var properties = data.GetType().GetProperties();
            foreach (var property in properties)
            {
                try
                {
                    MydataGridView.Rows.Add(property.Name);
                    MydataGridView[1, Count].Value = data.GetType().GetProperty(property.Name).GetValue(data, null);
                    Count++;
                }
                catch { }
            }




        }
        public static Image GetImageFromUrl(string url)
        {

            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }
        private void TW_buttonMoreInfo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TW_dgvUserTweets.DataSource = null;
            TW_dgvUserTweets.Rows.Clear();
            TW_dgvUserTweets.Refresh();

            ts.FollowersList.Clear();
            ts.FriendsList.Clear();
            ts.MembershipList.Clear();
            ts.SubscriptionsList.Clear();

            TW_lbFollowers.Items.Clear();
            TW_lbFriends.Items.Clear();
            TW_lbMemberships.Items.Clear();

            KeyValuePair<String, String> pair;

            //****** loading tweets in dataGridView *****///
            try
            {
                 pair = ts.ResultSearch.ElementAt(TW_lbSearchResult.SelectedIndex);
            }
            catch (Exception ex) { MessageBox.Show("Error : 101 No item selected"); return; }
           
            try
            {
                //** data loaded in ts.TweetsListUser                
                ts.TW_UserTweetsByID(pair.Key);
                dgvLoadTweets(ts);
            }
            catch { }

            //****** loading user followers in LIST *****///
            try
            {
                //** data loaded in ts.UserFollowers                
                ts.TW_UserFollowersByID(pair.Key, pair.Value);
                lb_LoadFollowers(ts);
            }
            catch { }

            //****** loading user friends in LIST *****///
            try
            {   //** data loaded in ts.UserFriends
                ts.TW_UserFriendsByID(pair.Key, pair.Value);
                lb_LoadFriends(ts);
            }
            catch { }

            //****** loading user memberships in LIST *****///
            try
            {   //** data loaded in ts.ListMemberships
                ts.TW_UserMembershipsById(pair.Key, pair.Value);
                lb_LoadMemberships(ts);
            }
            catch { }

            //****** loading user subscription in LIST *****///
            try
            {   //** data loaded in ts.ListSubscriptions
                ts.TW_UserSubscribersById(pair.Key, pair.Value);
                lb_LoadSubscriptions(ts);
            }
            catch { }

            try
            {   //** data loaded in ts.ListSubscriptions
                ts.TW_UserFavouritesById(pair.Key, pair.Value);
                lb_LoadFavourites(ts);
            }
            catch { }

            Cursor.Current = Cursors.Default;

        }
        private void TW_dgvTweets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvLoadTweets(TwitterSearch tempTS)
        {

            if (TW_dgvUserTweets.ColumnCount != 4)
            {
                TW_dgvUserTweets.Columns.Add("SNO", "S.No");
                TW_dgvUserTweets.Columns.Add("Message", "Message");
                TW_dgvUserTweets.Columns.Add("Date", "Created Data");
                TW_dgvUserTweets.Columns.Add("Retweets", "Retweets");
            }
            DataGridViewColumn column0 = TW_dgvUserTweets.Columns[0];
            column0.Width = 50;

            DataGridViewColumn column1 = TW_dgvUserTweets.Columns[1];
            column1.Width = 800;

            DataGridViewColumn column2 = TW_dgvUserTweets.Columns[2];
            column2.Width = 150;

            DataGridViewColumn column3 = TW_dgvUserTweets.Columns[3];
            column3.Width = 100;


            if (TW_cmbType.Text == "user")
            {
                TW_dgvUserTweets.Rows.Clear();
                int count = 0;
                foreach (var tweet in tempTS.TweetsListUser)
                {
                    try
                    {
                        TW_dgvUserTweets.Rows.Add(count.ToString());
                        TW_dgvUserTweets[1, count].Value = tweet.Text;
                        TW_dgvUserTweets[2, count].Value = tweet.CreatedDate;
                        TW_dgvUserTweets[3, count].Value = tweet.RetweetCount;                        
                        count++;
                    }
                    catch { }
                }

            }
        }
        private void dgvLoadSearchedTweets(List<Tuple<String, String, String, String>> ResultTweet)
        {

            if (TW_dgvTweets.ColumnCount != 5)
            {
                TW_dgvTweets.Columns.Add("SNO", "S.No");
                TW_dgvTweets.Columns.Add("ScreenName", "Screen Name");
                TW_dgvTweets.Columns.Add("Message", "Tweet");
                TW_dgvTweets.Columns.Add("CreatedTime", "Created Time");
                TW_dgvTweets.Columns.Add("Retweet", "ReTweet");

            }
            DataGridViewColumn column0 = TW_dgvTweets.Columns[0];
            column0.Width = 50;

            DataGridViewColumn column1 = TW_dgvTweets.Columns[1];
            column1.Width = 100;

            DataGridViewColumn column2 = TW_dgvTweets.Columns[2];
            column2.Width = 750;

            DataGridViewColumn column3 = TW_dgvTweets.Columns[3];
            column3.Width = 100;

            DataGridViewColumn column4 = TW_dgvTweets.Columns[4];
            column4.Width = 100;

            int count = 0;
            if (TW_cmbType.Text == "tweet")
            {
                TW_dgvTweets.Rows.Clear();                
                for(count = 0; count < ResultTweet.Count ;count++)
                {
                    try
                    {
                        TW_dgvTweets.Rows.Add(count.ToString());
                        TW_dgvTweets[1, count].Value = ResultTweet[count].Item1;
                        TW_dgvTweets[2, count].Value = ResultTweet[count].Item2;
                        TW_dgvTweets[3, count].Value = ResultTweet[count].Item3;
                        TW_dgvTweets[4, count].Value = ResultTweet[count].Item4;                        
                    }
                    catch { }
                }

            }
        }
        private void dgvLoadFollowersDetails(TwitterSearch tempTS)
        {

                try
                {
                    foreach (var tweet in tempTS.ListFollowerIds)
                    {
                        try
                        {
                            TW_lbFriends.Items.Add(tweet.Name);
                            
                        }
                        catch { }
                    }
                }
                catch { }
           
        }
        private void lb_LoadFollowers(TwitterSearch tempTS)
        {


            if (TW_cmbType.Text == "user")
            {
                try
                {
                    foreach (var tweet in tempTS.UserFollowers)
                    {
                        try
                        {
                            TW_lbFollowers.Items.Add(tweet.Name);
                            tempTS.FollowersList.Add(new Tuple<string, string, string>(tweet.Id.ToString(), tweet.ScreenName.ToString(), tweet.Name.ToString()));
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
        private void lb_LoadFriends(TwitterSearch tempTS)
        {


            if (TW_cmbType.Text == "user")
            {
                try
                {
                    foreach (var tweet in tempTS.UserFriends)
                    {
                        try
                        {
                            TW_lbFriends.Items.Add(tweet.Name);
                            tempTS.FriendsList.Add(new Tuple<string, string, string>(tweet.Id.ToString(), tweet.ScreenName.ToString(), tweet.Name.ToString()));
                            
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
        private void lb_LoadMemberships(TwitterSearch tempTS)
        {
            if (TW_cmbType.Text == "user")
            {
                try
                {
                    foreach (var tweet in tempTS.ListMemberships)
                    {
                        try
                        {
                            TW_lbMemberships.Items.Add(tweet.Name);                            
                            tempTS.MembershipList.Add(new Tuple<string, string>(tweet.Id.ToString(), tweet.Name.ToString()));

                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
        private void lb_LoadFollowersID(TwitterSearch tempTS)
        {


            if (TW_cmbType.Text == "user")
            {
                try
                {
                    foreach (var tweet in tempTS.ListFollowerIds)
                    {
                        try
                        {
                            TW_lbFriends.Items.Add(tweet.Name);
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
        private void lb_LoadSubscriptions(TwitterSearch tempTS)
        {
            if (TW_cmbType.Text == "user")
            {
                try
                {
                    foreach (var tweet in tempTS.ListSubscriptions)
                    {
                        try
                        {
                            TW_lbSubscriptions.Items.Add(tweet.Name);                            
                            tempTS.SubscriptionsList.Add(new Tuple<string, string>(tweet.Id.ToString(), tweet.Name.ToString()));

                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
        private void lb_LoadFavourites(TwitterSearch tempTS)
        {
            //if (TW_cmbType.Text == "user")
            //{
            //    try
            //    {
            //        foreach (var tweet in tempTS.ListFavourites)
            //        {
            //            try
            //            {
            //                TW_lbFavour.Items.Add(tweet.Text);                           
            //                tempTS.FavouritesList.Add(new Tuple<string, string>(tweet.Id.ToString(), tweet.Text.ToString()));

            //            }
            //            catch { }
            //        }
            //    }
            //    catch { }
            //}

            int count = 0;
            if (TW_cmbType.Text == "user")
            {
                try
                {
                    foreach (var tweet in tempTS.ListFavourites)
                    {
                        try
                        {
                            TW_lbFavourites.Items.Add(tweet.Text);
                            if(count % 2 == 0)
                                TW_lbFavourites.Items[count].BackColor = Color.White;
                            else
                                TW_lbFavourites.Items[count].BackColor = Color.MediumSlateBlue;

                           
                            tempTS.FavouritesList.Add(new Tuple<string, string>(tweet.Id.ToString(), tweet.Text.ToString()));
                            count++;
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        private void TW_dgvTweets_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TW_dgvDataByTweets.DataSource = null;
            TW_dgvDataByTweets.Rows.Clear();
            TW_dgvDataByTweets.Refresh();

            int selectedrowindex = TW_dgvTweets.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = TW_dgvTweets.Rows[selectedrowindex];
            string id = Convert.ToString(selectedRow.Cells["ScreenName"].Value);
            

            gs.TW_UserDataByScreenName(id);
            GridViewUpdate(gs.TwitterData, TW_dgvDataByTweets);
            TW_pbofTweet.Image = GetImageFromUrl(gs.TwitterData.ProfileImageUrl);
             

            Cursor.Current = Cursors.Default;
        }
        private void TW_lbFollowers_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = 0;
            try
            {
                id = ts.UserFollowers[TW_lbFollowers.SelectedIndex].Id;
                gs.TW_UserDataByID(id.ToString());
                GridViewUpdate(gs.TwitterData, TW_dgvFollowerDetail);
            }
            catch { }
            
        }
        private void TW_lbFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = 0;
            try
            {
                 id = ts.UserFriends[TW_lbFriends.SelectedIndex].Id;
                gs.TW_UserDataByID(id.ToString());
                GridViewUpdate(gs.TwitterData, TW_dgvFriendDetail);
            }
            catch
            { }
        }
        private void TW_lbMemberships_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = 0;
            try
            {
                id = ts.ListMemberships[TW_lbMemberships.SelectedIndex].Id;
                gs.TW_UserDataByID(id.ToString());
                GridViewUpdate(gs.TwitterData, TW_dgvMembershipDetail);
            }
            catch
            { }
        }
        private void TW_lbSubscriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = 0;
            try
            {
                id = ts.ListSubscriptions[TW_lbSubscriptions.SelectedIndex].Id;
                gs.TW_UserDataByID(id.ToString());
                GridViewUpdate(gs.TwitterData, TW_dgvSubscriptionDetail);
            }
            catch
            { }
        }
        private void TW_lbFavourites_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = 0;
            try
            {
                //id = ts.ListFavourites[TW_lbFavourites.SelectedIndex].Id;
                //gs.TW_UserDataByID(id.ToString());
                //GridViewUpdate(gs.TwitterData, TW_dgvFavouritesDetail);
            }
            catch
            { }
        }

        private void FrmTwitter_MouseClick(object sender, MouseEventArgs e)
        {

        }
        
    }
    public class TwitterSearch
    {
        public dynamic TwitterData;
        public dynamic TwitterClient;
        public dynamic TweetsListUser;
        public dynamic TweetsFollowers;
        public dynamic UserFollowers;
        public dynamic UserFriends;
        public dynamic ListFollowerIds;
        public dynamic ListMemberships;
        public dynamic ListSubscriptions;
        public dynamic ListFavourites;

        public string ScreenName { get; set; }
        public string ID { get; set; }
        public dynamic Type { get; set; }
        public string AccessToken { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
        public string CreatedTime { get; set; }
        public string UpdatedTime { get; set; }
        public String consumerKey { get; set; }
        public String consumerSecret { get; set; }
        public String accessToken { get; set; }
        public String accessTokenSecret { get; set; }
        public ICollection<KeyValuePair<String, String>> ResultSearch = new Dictionary<String, String>();
        public List<Tuple<String, String, String, String>> ResultSearchTweet = new List<Tuple<String, String, String, String>>();

        //** screen_name , id , display_name **//
        public List<Tuple<String, String, String>> FollowersList = new List<Tuple<String, String, String>>();
        public List<Tuple<String, String, String>> FriendsList = new List<Tuple<String, String, String>>();
        public List<Tuple<String, String>> MembershipList = new List<Tuple<String, String>>();
        public List<Tuple<String, String>> SubscriptionsList = new List<Tuple<String, String>>();
        public List<Tuple<String, String>> FavouritesList = new List<Tuple<String, String>>();

        public TwitterSearch(String consumerKey, String consumerSecret, String accessToken, String accessTokenSecret)  // constructor
        {
            //************* new instantiations ************

            Link = "";
            UpdatedTime = "";
            CreatedTime = "";
            ScreenName = "";
            ID = "";
            ImageLink = "";
            ResultSearch = new Dictionary<string, string>();
            Type = "";
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;

        }
        public TwitterSearch()  // constructor
        {
            //************* new instantiations ************
            Link = "";
            CreatedTime = "";
            UpdatedTime = "";
            ScreenName = "";
            ID = "";
            ImageLink = "";
            Type = "";


        }
        public void TW_UserSearchByName(string name, string count)
        {
            

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            //** 20 items per page
            int page_no = Convert.ToInt32(count) / 20 + 1;
          

            for (int c = 0; c < page_no; c++)
            {
                var tweets_search = twitterService.SearchForUser(new SearchForUserOptions { Q = name.ToString(), Count = Convert.ToInt32(count), Page = c });

                foreach (var tweet in tweets_search)
                {
                    try
                    {
                        ResultSearch.Add(new KeyValuePair<String, String>(tweet.Id.ToString(), tweet.ScreenName));
                    }
                    catch { }
                }
            }
           

        }
        public List<Tuple<string,string,string,string>> TW_TweetSearchByKeyword(string keyword, string count)
        {
            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            string maxid = "1000000000000"; // dummy value
            int tweetcount = 0;
            
            List<TwitterStatus> resultList;
            if (maxid != null)
            {
                
                
                     var tweets_search = twitterService.Search(new SearchOptions { Q = keyword, Count = Convert.ToInt32(count) });
                     resultList = new List<TwitterStatus>(tweets_search.Statuses);
                     maxid = resultList.Last().IdStr;
                
                
                foreach (var tweet in tweets_search.Statuses)
                {
                    try
                    {
                        ResultSearchTweet.Add(new Tuple<string,string,string,string>(tweet.User.ScreenName, tweet.Text,tweet.CreatedDate.ToShortDateString(),tweet.RetweetCount.ToString()));
                        tweetcount++;
                    }
                    catch { }
                }

                while (maxid != null && tweetcount < Convert.ToInt32(count))
                {
                    maxid = resultList.Last().IdStr;
                    tweets_search = twitterService.Search(new SearchOptions { Q = keyword, Count = Convert.ToInt32(count), MaxId = Convert.ToInt64(maxid) });
                    resultList = new List<TwitterStatus>(tweets_search.Statuses);
                    foreach (var tweet in tweets_search.Statuses)
                    {
                        try
                        {
                            ResultSearchTweet.Add(new Tuple<string, string, string, string>(tweet.Id.ToString(), tweet.Text, tweet.CreatedDate.ToShortDateString(), tweet.RetweetCount.ToString()));
                            tweetcount++;
                        }
                        catch { }
                    }
                }

            }

            return ResultSearchTweet;
        }
        public void TW_UserDataByID(string ID)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            var tweets_search = twitterService.GetUserProfileFor(new GetUserProfileForOptions { UserId = Convert.ToInt64(ID) });
            TwitterData = tweets_search;
            

        }
        public void TW_UserDataByScreenName(string name)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            var tweets_search = twitterService.GetUserProfileFor(new GetUserProfileForOptions { ScreenName = name });
            TwitterData = tweets_search;
        }
        public void TW_UserTweetsByID(string ID)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            //var tweets_search = twitterService.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions { }); 
            var tweets_search = twitterService.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { UserId = Convert.ToInt64(ID) });
            
            TweetsListUser = tweets_search;


        }

        public void TW_UserFollowersByID(string ID, string ScrName)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            var tweets_search = twitterService.ListFollowers(new ListFollowersOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName });
            UserFollowers = tweets_search;

        }
        public void TW_UserFriendsByID(string ID, string ScrName)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            var tweets_search = twitterService.ListFriends(new ListFriendsOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName });
            UserFriends = tweets_search;

        }
        public void TW_UserFollow(string ID, string ScrName)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            var tweets_search = twitterService.ListFollowerIdsOf(new ListFollowerIdsOfOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName });
            ListFollowerIds = tweets_search;

        }
        public void TW_UserMembershipsById(string ID, string ScrName)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            //var tweets_search = twitterService.ListFollowerIdsOf(new ListFollowerIdsOfOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName });
            var tweets_search = twitterService.ListListMembershipsFor(new ListListMembershipsForOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName });
            ListMemberships = tweets_search;

        }
        public void TW_UserSubscribersById(string ID, string ScrName)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            //var tweets_search = twitterService.ListFollowerIdsOf(new ListFollowerIdsOfOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName });
            var tweets_search = twitterService.ListSubscriptions(new ListSubscriptionsOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName });
            ListSubscriptions = tweets_search;

        }
        public void TW_UserFavouritesById(string ID, string ScrName)
        {

            TwitterService twitterService = new TwitterService();
            twitterService.AuthenticateWith(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            var tweets_search = twitterService.ListFavoriteTweets(new ListFavoriteTweetsOptions { UserId = Convert.ToInt64(ID), ScreenName = ScrName, Count = 200 });
            ListFavourites = tweets_search;
          
        }
    }
}