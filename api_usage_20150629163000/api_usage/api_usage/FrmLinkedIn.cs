using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using System.Reflection;
using System.Net;
using System.Collections;
using System.Windows.Documents;

using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LinkedIn.NET;
using LinkedIn.NET.Options;
using LinkedIn.NET.Groups;
using LinkedIn.NET.Search;
using LinkedIn.NET.Updates;
using LinkedIn.NET.Members;

namespace api_usage
{
    public partial class FrmLinkedIn : Form
    {

        //*** consumer key and secret are stored in /debug/bin/LinkedIn.config

        protected LinkedInClient linkedInClient;
        protected string consumerKey;
        protected string consumerSecret;
        protected string accessToken;
        protected bool haveAccessToken;
        protected LinkedInGroupPost selectedPost;
        protected TreeNode selectedPostNode;
        const string CRLF = "\r\n";
        const string REDIRECT_URL = "http://newscode.wp-bbosa.com/";
        const string STATE = "123456789";

        public FrmLinkedIn()
        {
            LoadConfiguration();
            InitializeClient();          

            if (String.IsNullOrEmpty(accessToken))
            {
                Authenticate();
            }
            InitializeComponent();
        }
        protected void LoadConfiguration()
        {
            try
            {
                string[] linkedInConfig = File.ReadAllLines("linkedin.config");
                consumerKey = linkedInConfig[0];
                consumerSecret = linkedInConfig[1];

                if (linkedInConfig.Length == 3)
                {
                    accessToken = linkedInConfig[2];
                    haveAccessToken = true;
                }
            }
            catch (Exception ex)
            {
                EmitException("LinkedIn.config file is missing or corrupt." + "\r\n" + ex.Message);
            }
        }
        protected void InitializeClient()
        {
            if ((!String.IsNullOrEmpty(consumerKey)) && (!String.IsNullOrEmpty(consumerSecret)))
            {
                linkedInClient = new LinkedInClient(consumerKey, consumerSecret);

                if (haveAccessToken)
                {
                    linkedInClient.AccessToken = accessToken;
                }
            }
        }
        protected void Authenticate()
        {
            if (linkedInClient != null)
            {
                var options = new LinkedInAuthorizationOptions
                {
                    RedirectUrl = REDIRECT_URL,
                    //Permissions = LinkedInPermissions.Connections |
                    //			  LinkedInPermissions.EmailAddress  |
                    //			  //LinkedInPermissions.GroupDiscussions | LinkedInPermissions.Messages |
                    //			    LinkedInPermissions.BasicProfile,
                    Permissions = LinkedInPermissions.FullPermissionsScope,

                    //			  
                    State = STATE
                };

                //create new instance of authorization dialog using authorization link built by _Client
                var dlgAuth = new DlgAuthorization(linkedInClient.GetAuthorizationUrl(options));

                if (dlgAuth.ShowDialog(this) == DialogResult.OK)
                {
                    //get access token using authorization code received
                    var response = linkedInClient.GetAccessToken(dlgAuth.AuthorizationCode, REDIRECT_URL);

                    if (response.Result != null && response.Status == LinkedInResponseStatus.OK)
                    {
                        accessToken = response.Result.AccessToken;
                        SaveConfiguration();
                    }
                }
                else
                {
                    //show error information
                    MessageBox.Show(dlgAuth.OauthErrorDescription, dlgAuth.OauthError);
                }
            }
        }
        protected void SaveConfiguration()
        {
            File.WriteAllLines("linkedin.config", new string[]
			{
				consumerKey,
				consumerSecret,
				accessToken,
			});
        }
        protected void EmitException(string exception)
        {
            MessageBox.Show(exception, "An Error Has Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void LKI_pbxSearch_Click(object sender, EventArgs e)
        {
          LKI_LoadSearch("taimoor");
        }
        public void LKI_LoadGroups()
        {
            if (haveAccessToken)
            {                
                
                LinkedInGetGroupOptions options = new LinkedInGetGroupOptions();
                options.GroupOptions.SelectAll();

                LinkedInResponse<IEnumerable<LinkedInGroup>> result = linkedInClient.GetMemberGroups(options);

                if (result.Result != null && result.Status == LinkedInResponseStatus.OK)
                {
                    //ShowMemberGroups(result);
                }
                
            }
        }
        public void LKI_LoadSearch(String Search)
        {
            if (haveAccessToken)
            {
                var result = linkedInClient.Search(new LinkedInSearchOptions { FirstName = Search });
                

                if (result.Result != null && result.Status == LinkedInResponseStatus.OK)
                {
                    //ShowMemberGroups(result);
                }

            }
        }

    }

    public static class ExtensionMethods
    {
        public static string LimitLength(this string s, int len)
        {
            string ret = s;

            if (s.Length > len)
            {
                ret = s.Substring(0, len - 3) + "...";
            }

            return ret;
        }
    }

   
}
