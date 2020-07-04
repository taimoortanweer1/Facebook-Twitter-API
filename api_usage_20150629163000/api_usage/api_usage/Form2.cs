using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Serialization;
using Microsoft.Glee.Drawing;
using Infragistics.Win.Misc;
using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Plus.v1;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Plus.v1.Data;
using System.Collections.Generic;
using System.Linq;

namespace api_usage
{
    public partial class Form2 : Form
    {

        //%%%%%%%%%%%%%%%%%%%%%%%%% PlusService service 
        PlusService service;
        string[] scopes;
        string client_id = "904980209954-07eeelujt56lnb7lblbb0nj8samrqoc4.apps.googleusercontent.com";
        string client_secret = "ANNkHRLH14-RCLyZv-5dxytQ";
        string api_key = "AIzaSyDHjbsFoCwfqvQbvF3-fPG_i5YTjFsKVt4";
        string q = "https://www.googleapis.com/plus/v1/people?query=taimoor&key=AIzaSyDHjbsFoCwfqvQbvF3-fPG_i5YTjFsKVt4";
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        string access_code = "CAACEdEose0cBAI0tZC2RCZAfIyr9NaruOkNyW7ZAea2AVHK9OqwZCVvemPAPbFHeBnVgp9WVofliYIBpEOIFJ20EsvbZCO7aOJMZBcEG7Rs14L9TjSCVoFuzxYO0KH6DtXyFNTBTGLkzkgztFfAkEAws2GfyiYPwEU8hkSJ9ZAquZC5lZB9eRhMK5HYoO2bKfJxXZAkwzPAZBnsNilJ5sEdsw5Jph1Gs3GAPrftdPBqZCheIdwZDZD";
        Microsoft.Glee.GraphViewerGdi.GViewer viewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
        int count = 0;
        //create a graph object
        Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("graph");
        List<string> listL = new List<string>();
        List<string> listG = new List<string>();
        List<string> listM = new List<string>();
        
                                     
        public Form2()
        {
            InitializeComponent();
        }

        void initialize_gragh()
        {
            graph.GraphAttr.Fontsize = 8;
            graph.GraphAttr.FontName = "Arial";
            

        }
        void makegraph()
        {            
        string strNode1 = "user";
        string strNode2 = "likes";
        string strNode3 = "groups";
        string strNode4 = "movies";
      
        graph.AddEdge(strNode1, strNode2);
        graph.AddEdge(strNode1, strNode3);
        graph.AddEdge(strNode1, strNode4);

        foreach( string s in listL)
        {
            graph.AddEdge(strNode2, s);
        }
        foreach (string s in listG)
        {
            graph.AddEdge(strNode3, s);
        }
        foreach (string s in listM)
        {
            graph.AddEdge(strNode4, s);
        }
        
          
        //bind the graph to the viewer
        viewer.Graph = graph;
        
        //associate the viewer with the form
        //Form2.SuspendLayout();
        this.SuspendLayout();
        viewer.Dock = System.Windows.Forms.DockStyle.Fill;
        viewer.Dock = this.Dock;
        this.Controls.Add(viewer);
        this.ResumeLayout();
 
        //show the form
       // this.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Text = "";
         
            var facebookClient = new FacebookClient(access_code);
                    
            
            //dynamic listLikes = facebookClient.Get("/me/likes?limit=10");
            dynamic listLikes = facebookClient.Get("/me/likes?limit=10");
            dynamic listGroups = facebookClient.Get("/me/groups?limit=10");
            dynamic listMovies = facebookClient.Get("/me/movies?limit=10");

            //dynamic listLikes = facebookClient.Get("/139041419482037/likes?limit=10");
            //dynamic listGroups = facebookClient.Get("/139041419482037/posts?limit=10");
            //dynamic listMovies = facebookClient.Get("/139041419482037/movies?limit=10");

            listLikes = (IDictionary<string, object>)listLikes;
            listGroups = (IDictionary<string, object>)listGroups;
            listMovies = (IDictionary<string, object>)listMovies;

            // ************ Acquiring Page's Name and ID *************
            string page_id = "123456789";
            string name = "/" + page_id.ToString() + "/likes";
            
            foreach (dynamic L1 in (JsonArray)listLikes["data"])
            {
                 listL.Add((string)(((JsonObject)L1)["name"]));                
                //listBox4.Items.Add(name.ToString());
                //page_id = (string)(((JsonObject)L1)["id"]);
                //listBox4.Items.Add(page_id.ToString());
            }

            foreach (dynamic L1 in (JsonArray)listGroups["data"])
            {
                listG.Add((string)(((JsonObject)L1)["name"]));                
            }

            foreach (dynamic L1 in (JsonArray)listMovies["data"])
            {
                listM.Add((string)(((JsonObject)L1)["name"]));
            }

            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search_Facebook();
        }
        private void Search_Facebook()
        {            
            //clearing display
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            // Creating a client with AccessToken as parameter
            var facebookClient = new FacebookClient(access_code);
            //var facebookClient = new FacebookClient();

            // ******* Page Searching Query ***************8
            
            //with place
            dynamic facebookData = facebookClient.Get("/search?q=" + textBox3.Text.ToString() + " in " + textBox4.Text.ToString() + "&type="+comboBox1.Text.ToString());          

            //without place
            //dynamic facebookData = facebookClient.Get("/search?q=" + textBox3.Text.ToString() +"&type=" + comboBox1.Text.ToString());            
            //dynamic facebookData = facebookClient.Get("/search?q=professor shoab&type=page");

            // ******** EOB *********************


            //converting dynamic object to its key/value pair equivalent object
            facebookData = (IDictionary<string, object>)facebookData;
            //dynamic L1 = (IDictionary<string, object>)L1;
          
            // ************ Acquiring Page's Name and ID *************
            string page_id="123456789";
            string name = "/" + page_id.ToString() + "/likes"; 

            foreach (dynamic L1 in (JsonArray)facebookData["data"])
            {
                name = ((string)(((JsonObject)L1)["name"]));
                //textBox2.Text = textBox2.Text + name + "\r\n";
                listBox4.Items.Add(name.ToString());
                page_id = (string)(((JsonObject)L1)["id"]);
                listBox4.Items.Add(page_id.ToString());         
            }
            // ************ EOB *************


            /*
            //pages liked by the current page
            facebookData = facebookClient.Get("/" + listBox4.SelectedItem.ToString() + "/likes");
            facebookData = (IDictionary<string, object>)facebookData;

            string liked_page_name = "";
            string liked_page_id = "";

            foreach (dynamic L1 in (JsonArray)facebookData["data"])
            {
                liked_page_name = ((string)(((JsonObject)L1)["name"]));
                //textBox5.Text = textBox5.Text + liked_page_name + "\r\n";
                liked_page_id = (string)(((JsonObject)L1)["id"]);
                listBox1.Items.Add(liked_page_name.ToString());
            }
            */
            
             /*
            //acquiring ids of posts in page
            facebookData = facebookClient.Get("/" + page_id.ToString() + "/feed");
            facebookData = (IDictionary<string, object>)facebookData;
            string post_id="";
            int c = 0;
            foreach (dynamic L1 in (JsonArray)facebookData["data"])
            {
                c++;
                try
                {
                    //name = ((string)(((JsonObject)L1)["name"]));
                    post_id = (string)(((JsonObject)L1)["object_id"]);
                    listBox2.Items.Add(post_id.ToString());
                }
                catch
                {
                    //textBox2.Text = textBox2.Text + "done" + "\r\n";
                }
                if (c == 10)
                break;
            }
            */

            //acquiring likes of a certain post
            //facebookData = facebookClient.Get("/" + post_id.ToString() + "/likes?limit=900");
           // facebookData = facebookClient.Get("/949310681788436/likes?limit=900");
           // facebookData = (IDictionary<string, object>)facebookData;
                                
       //   facebookData = facebookClient.Get("/139041419482037/likes");
       //   facebookData = facebookClient.Get("/949310681788436/likes");

        }
        
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Acquiring name of the persons who liked the post
            listBox3.Items.Clear();

            var facebookClient = new FacebookClient(access_code);
            dynamic facebookData = facebookClient.Get("/"+listBox2.SelectedItem.ToString()+"/likes?limit=900");
            facebookData = (IDictionary<string, object>)facebookData;
            string name = "";
            foreach (dynamic L1 in (JsonArray)facebookData["data"])
            {
                try
                {
                    name = ((string)(((JsonObject)L1)["name"]));
                    //post_id = (string)(((JsonObject)L1)["object_id"]);
                    listBox3.Items.Add(name.ToString());
                }
                catch
                {
                    //textBox6.Text = textBox6.Text + "done" + "\r\n";
                }
            }
   
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  ********* Acquiring pages liked by the current page ******************* 
            listBox1.Items.Clear();

            var facebookClient = new FacebookClient(access_code);
            
            dynamic facebookData = facebookClient.Get("/" + listBox4.SelectedItem.ToString() + "/likes");
            facebookData = (IDictionary<string, object>)facebookData;

            string liked_page_name = "";
            string liked_page_id = "";

            foreach (dynamic L1 in (JsonArray)facebookData["data"])
            {
                liked_page_name = ((string)(((JsonObject)L1)["name"]));
                //textBox5.Text = textBox5.Text + liked_page_name + "\r\n";
                liked_page_id = (string)(((JsonObject)L1)["id"]);
                listBox1.Items.Add(liked_page_name.ToString());
            }
            //  ********* EOB ******************* 

            listBox2.Items.Clear();
            
            //********** Acquiring ids of posts in page **********************
            facebookData = facebookClient.Get("/" + listBox4.SelectedItem.ToString() + "/feed");
            facebookData = (IDictionary<string, object>)facebookData;
            string post_id = "";
            int c = 0;
            foreach (dynamic L1 in (JsonArray)facebookData["data"])
            {
                c++;
                try
                {
                    //name = ((string)(((JsonObject)L1)["name"]));
                    post_id = (string)(((JsonObject)L1)["object_id"]);
                    listBox2.Items.Add(post_id.ToString());
                }
                catch
                {
                    //textBox2.Text = textBox2.Text + "done" + "\r\n";
                }
                if (c == 10)
                    break;
            }

            /******** EOB *******************/        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            // Creating a client with AccessToken as parameter
            var facebookClient = new FacebookClient(access_code);

            //Getting facebook pages id/name/info (likes ones)
            dynamic facebookData = facebookClient.Get("/me/likes?type=page");


            //dynamic facebookData = facebookClient.Get("/uid=139041419482037/likes?type=page");           
            //no of Data objects returned by facebook Graph
            int resultCount = (int)facebookData.Count;


            //var jsonObject = (JObject)facebookClient.Get("me/friends");           


            //accessing data 
            foreach (var L1_Object in facebookData.data)
            {

                foreach (var L2_Object in L1_Object)
                {
                    var objText = L2_Object;
                    listBox1.Items.Add(objText.ToString());
                }
            }

            // Data obj = JsonConvert.DeserializeObject<Data>(facebookData);
            /*
            for (int i = 0; i < resultCount; i++)
            {
                textBox2.Text = facebookData[i] + "\r\n";
            }
           */
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            makegraph();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
      
        private void button5_Click(object sender, EventArgs e)
        {

            scopes = new string[] {PlusService.Scope.PlusLogin,
            PlusService.Scope.UserinfoEmail,
            PlusService.Scope.UserinfoProfile};
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            UserCredential credential =
                    GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
                    {
                        ClientId = client_id,
                        ClientSecret = client_secret
                    },
                                                                scopes,
                                                                Environment.UserName,
                                                                CancellationToken.None,
                                                            new FileDataStore("Daimto.GooglePlus.Auth.Store")
                                                                ).Result;


            service = new Google.Apis.Plus.v1.PlusService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Plus Sample",
            });


            ActivitiesResource.SearchRequest list = service.Activities.Search(q);
        }

    }


 
}
