using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using Microsoft.CSharp;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Diagnostics;
using Microsoft.Glee.Drawing;
using System.Drawing.Imaging;
using Infragistics.Win.Misc;


namespace api_usage
{ 
    public partial class FrmSearch : Form
    {

        //***** Custom FB search class object

        //fs contains data of searched result and data related to them
        FacebookSearch fs = new FacebookSearch("CAACEdEose0cBAPMW5de5HgM23Wssa9vx0Onb9WTfmX1MSWHLRgFavNaKSqHECEbAZANVo2xcEAbPbz7XViZB5wRtgWUCpqNEevnZAmMcwrl2yD6rlmB5nZBn1mbe6exMVEIGAvSoNJruzUeL6zQlZBW8RFTPLkrKSj87ezSVZAq311SudtAJT9kigNYhMWqPQZAvkwqlfZATr4o3RZBaMah6OxxI7rhmEoOQONeZC9Q0a8PQZDZD");
        //ps contains data of more information regarding the page/user 
        FacebookSearch ps = new FacebookSearch("CAACEdEose0cBAPMW5de5HgM23Wssa9vx0Onb9WTfmX1MSWHLRgFavNaKSqHECEbAZANVo2xcEAbPbz7XViZB5wRtgWUCpqNEevnZAmMcwrl2yD6rlmB5nZBn1mbe6exMVEIGAvSoNJruzUeL6zQlZBW8RFTPLkrKSj87ezSVZAq311SudtAJT9kigNYhMWqPQZAvkwqlfZATr4o3RZBaMah6OxxI7rhmEoOQONeZC9Q0a8PQZDZD");
        //ls contains details of user who liked some post 
        FacebookSearch ls = new FacebookSearch("CAACEdEose0cBAPMW5de5HgM23Wssa9vx0Onb9WTfmX1MSWHLRgFavNaKSqHECEbAZANVo2xcEAbPbz7XViZB5wRtgWUCpqNEevnZAmMcwrl2yD6rlmB5nZBn1mbe6exMVEIGAvSoNJruzUeL6zQlZBW8RFTPLkrKSj87ezSVZAq311SudtAJT9kigNYhMWqPQZAvkwqlfZATr4o3RZBaMah6OxxI7rhmEoOQONeZC9Q0a8PQZDZD");
        
        //*** instantiations of graphics objects
        Microsoft.Glee.GraphViewerGdi.GViewer viewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
        Microsoft.Glee.Drawing.Graph graph = new Microsoft.Glee.Drawing.Graph("Facebook Graph");
        UltraExpandableGroupBox[] gbBox;
        UltraExpandableGroupBoxPanel[] gbPanel;

        public FrmSearch()
        {
            InitializeComponent();
            
            //** overwriting initial values of GridView manually as somehow properties tab isnt updating these
            this.dgvProfileInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            this.dgvProfileInfo.RowHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            this.dgvProfileInfo.DefaultCellStyle.Font = new Font("Arial", 10);

            this.dgvPosts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            this.dgvPosts.RowHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            this.dgvPosts.DefaultCellStyle.Font = new Font("Arial", 10);

            this.dataGridView3PostLikersInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView3PostLikersInfo.RowHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            this.dataGridView3PostLikersInfo.DefaultCellStyle.Font = new Font("Arial", 10);




        }
                       
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //**** disabling place search query for page and group search i.e. disable combobox
            if (FB_cmbType.Text == "page" || FB_cmbType.Text == "group")
            {
                FB_cmbLocation.Enabled = false;
            }
            else
            {
                FB_cmbLocation.Enabled = true;
            }
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            //comboBox1.DroppedDown = true;
            comboBoxSearch.MaxDropDownItems = 10;
            Cursor.Current = Cursors.Default;

            int count = 0;            
            if (comboBoxSearch.Text.Length > 3)
            {
                fs.ResultSearch.Clear();
                comboBoxSearch.SelectedIndex = -1;
                fs.Query(comboBoxSearch.Text, comboBoxType.Text, comboBoxLocation.Text, "10");
                
                
                foreach (KeyValuePair<string, string> item in fs.ResultSearch)
                {
                    comboBoxSearch.Items.Add(item.Key.ToString());
                    count++;
                    if (count > 10)
                    {
                        break;
                    }
                }
                            
            } 
             */
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Text = FB_cmbQueryString.Text.ToString();
            //*** clearing display/variables boxes *****/
            listBoxBooks.Items.Clear();
            listBoxPosts.Items.Clear();
            listBoxPages.Items.Clear();
            listBoxMovies.Items.Clear();

            fs.ResultSearch.Clear();
            lbSearchResult.Items.Clear();

            fs.BookLikes.Clear();
            fs.Feed.Clear();
            fs.GroupLikes.Clear();
            fs.PageLikes.Clear();
            fs.MoviesLikes.Clear();
            //*** resetting done ***//

            //*** using query function of custom class****/
            fs.Query(FB_cmbQueryString.Text, FB_cmbType.Text, FB_cmbLocation.Text, "100");
            
           // foreach((KeyValuePair<string, string>)listProperties.SelectedItem in fs.ResultSearch)
            //{}
            
            //*** Adding search result into some LIST listBoxSearch ****/
            foreach (KeyValuePair<string, string> item in fs.ResultSearch)
            {
               lbSearchResult.Items.Add(item.Value.ToString());                                
            }
            
        }        
        void DisplayClear()
        {

            //*** clearing all ui objects
            rtbPostDescription.Text = "";

            listBoxBooks.Items.Clear();
            listBoxPosts.Items.Clear();
            listBoxPages.Items.Clear();
            listBoxMovies.Items.Clear();
            lbPostLikeByUsers.Items.Clear();
            
            //////////labelPostLikeCount.Text = "";            
            labelPostLink.Text = "";
            //labelPostCreated.Text = "";            
            
            dataGridView3PostLikersInfo.Refresh();
            dgvPosts.Refresh();

           // pictureBox3.Image = pictureBox3.InitialImage;
           // pictureBox4.Image = pictureBox4.InitialImage;
            
        }
        void GridViewUpdate(FacebookSearch FSGrid, DataGridView MydataGridView)
        {
            
            int Count = 0;            
            int FSKeyCount = 0;

            //** dont add if columns are already there
            if (MydataGridView.ColumnCount != 2)
            {
                MydataGridView.Columns.Add("Fields", "Fields");
                MydataGridView.Columns.Add("Values", "Values");
            }

            //** setting col width manually
            DataGridViewColumn column0 = MydataGridView.Columns[0];
            column0.Width = 200;

            DataGridViewColumn column = MydataGridView.Columns[1];
            column.Width = 820;
         

            if (FSGrid.Type.ToString() == "page")
            {
                //** fetching key id and updating label
                FSKeyCount = FSGrid.FacebookData.Keys.Count;
                //////////label1IdResult.Text = "page/" + ((string)(((JsonObject)FSGrid.FacebookData)["id"]));
                MydataGridView.Rows.Clear();


                //** Adding X number of rows where X = keys returned by a page id
                //** then adding values to dataGrid View
                foreach (string key in FSGrid.FacebookData.Keys)
                {                   
                    try
                    {
                        MydataGridView.Rows.Add(key);                    
                    }
                    catch { }
                }               
                Count = 0;
                try
                {
                    foreach (var value in FSGrid.FacebookData.Values)
                    {
                       
                        MydataGridView[1,Count].Value = value.ToString();
                        Count++;
                    }                
                }
                catch { }
            }
                                   
            
            
            //*** same labor for user type as above
            if (FSGrid.Type.ToString() == "user")
            {
                FSKeyCount = FSGrid.FacebookData.Keys.Count;
                //////////label1IdResult.Text = "profile/" + ((string)(((JsonObject)FSGrid.FacebookData)["id"]));
                MydataGridView.Rows.Clear();
                foreach (string key in FSGrid.FacebookData.Keys)
                {
                    try
                    {
                        MydataGridView.Rows.Add(key, key);
                    }
                    catch { }
                }

                Count = 0;                           
                try
                {
                    foreach (var value in FSGrid.FacebookData.Values)
                    {

                        MydataGridView[1, Count].Value = value.ToString();
                        Count++;
                    }
                }
                catch { }
            }
             
        }
        void GridViewUpdatePageName(FacebookSearch FSGrid)
        {
            //if (dataGridView2.ColumnCount != 1)
            //dataGridView2.Columns.Add("LikedBy", "Liked By Pages");            
            
            //fetching data i.e. page likes from Json object and adding in both list 
            if (FSGrid.Type.ToString() == "page")
            {                                                  
                try
                {
                    foreach (dynamic L1 in (JsonArray)FSGrid.FacebookData["data"])
                    {
                        try
                        {
                            //dataGridView2.Rows.Add(((string)(((JsonObject)L1)["name"])));
                            fs.PageLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["name"])), ((string)(((JsonObject)L1)["id"]))));
                            listBoxPages.Items.Add(((string)(((JsonObject)L1)["name"])));
                        }
                        catch { }
                    }
                }
                catch { }
            }                                                     
        }
        void GridViewUpdatePagePost(FacebookSearch FSGrid)
        {
            int Count = 0;            
            int FSKeyCount = 0;
           
            //**** adding details in dataGrid manually i.e. columns text and width 
            if (dgvPosts.ColumnCount != 4)
            {
                dgvPosts.Columns.Add("ID", "ID");
                dgvPosts.Columns.Add("Message", "Message");
                dgvPosts.Columns.Add("Created Time", "Created Time");
                dgvPosts.Columns.Add("Updated Time", "Updated Time");                 
            }
            DataGridViewColumn column0 = dgvPosts.Columns[0];
            column0.Width = 150;

            DataGridViewColumn column1 = dgvPosts.Columns[1];
            column1.Width = 550;

            DataGridViewColumn column2 = dgvPosts.Columns[2];
            column2.Width = 175;

            DataGridViewColumn column3 = dgvPosts.Columns[3];
            column3.Width = 175;

            //*** adding data in Grid value by value
            if (FSGrid.Type.ToString() == "page")
            {
                //groupBoxCreate(FSGrid.Feed_List.Count, panel7);
                FSKeyCount = FSGrid.FacebookData.Keys.Count;
                //label1IdResult.Text = "page/" + ((string)(((JsonObject)FSGrid.FacebookData)["id"]));
                dgvPosts.Rows.Clear();

                foreach (var key in FSGrid.Feed_List)
                {
                    try
                    {
                        dgvPosts.Rows.Add(key.Item1,key.Item2,key.Item3,key.Item4);
                    }
                    catch { }
                }
                            
            }
                                   
           
            //if (dataGridView3.ColumnCount != 2)
            //dataGridView2.Columns.Add("Post", "Pages Post");

            /*
            if (FSGrid.Type.ToString() == "page")
            {
                try
                {  
                    
                    while (Count < FSGrid.Feed.Count)
                    {
                        listBoxPosts.Items.Add(FSGrid.Feed[Count].Item2.ToString()); Count++;                        
                    }
                    foreach (dynamic L1 in (JsonArray)FSGrid.FacebookData["data"])
                    {
                        try
                        {
                            //dataGridView2[1, Count].Value = ((string)(((JsonObject)L1)["message"]));
                            //fs.MoviesLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["message"])), ((string)(((JsonObject)L1)["object_id"]))));                            
                            //Count++;
                        }
                        catch { }
                    }
                     
                }
                catch { }
            }
             */ 
        }
        void GridViewUpdatePagePostLikes(FacebookSearch FSGrid)
        {
            //** clearing UI and list **///
            int Count = 0;
            dataGridView3PostLikersInfo.DataSource = null;
            dataGridView3PostLikersInfo.Rows.Clear();
            dataGridView3PostLikersInfo.Refresh();
            if(dataGridView3PostLikersInfo.ColumnCount != 1)
            dataGridView3PostLikersInfo.Columns.Add("Post", "Post Liked By");

            //*** copying data in gridview from a list of likes **//
            if (FSGrid.Type.ToString() == "page")
            {
                while(Count < fs.PostLikes.Count)
                {
                try
                {
                            //dataGridView3[1, Count].Value = fs.PostLikes[Count].Item1;
                            dataGridView3PostLikersInfo.Rows.Add(fs.PostLikes[Count].Item1);
                            Count++;
                }        
                catch { }
                }   
                
             
            }
        }
        private void listBoxSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Text = lbSearchResult.SelectedItem.ToString();
            //** clearing display/variables ***/
            DisplayClear();
            fs.BookLikes.Clear();
            fs.Feed.Clear();
            fs.GroupLikes.Clear();
            fs.PageLikes.Clear();
            fs.MoviesLikes.Clear();

            //*** accessing selected item's index from the main search list 
            KeyValuePair<String, String> pair = fs.ResultSearch.ElementAt(lbSearchResult.SelectedIndex);
            
            //*** calling function according to type of the search query
                if (fs.Type == "user")
                {
                    fs.GetUserDataByID(pair.Key.ToString(), "100");

                    fs.GetPageGeneralData(pair.Key.ToString());                   
                    GridViewUpdate(fs,dgvProfileInfo);
                    fs.GetPictureByID(pair.Key.ToString());
                    pbxProfile.Image = GetImageFromUrl(fs.ImageLink);
                }

                if (fs.Type == "page")
                {
                    fs.GetPageDataByID(pair.Key.ToString(), "100");
                    fs.GetPageGeneralData(pair.Key.ToString());                   
                    GridViewUpdate(fs,dgvProfileInfo);
                }
            
        
            try
            {            
            //////////labelNameResult.Text = fs.Name;            
            pbxProfile.Image = GetImageFromUrl(fs.ImageLink);
            }
            catch { }

            
            /*
            int c = 1;
            while (c < fs.PageLikes.Count)
            {
                listBoxPages.Items.Add(fs.PageLikes[c].Item1.ToString()); c++;
            }
            c = 0;
            while (c < fs.MoviesLikes.Count)
            {
                listBoxMovies.Items.Add(fs.MoviesLikes[c].Item1.ToString()); c++;
            }
            c = 0;
            while (c < fs.BookLikes.Count)
            {

                listBoxBooks.Items.Add(fs.BookLikes[c].Item1.ToString()); c++;
            }
            c = 0;
      
            while (c < fs.GroupLikes.Count)
            {
                if (fs.Type == "user")
                {
                    listBoxGroups.Items.Add(fs.GroupLikes[c].Item1.ToString()); c++;
                }

                if (fs.Type == "page")
                {
                    listBoxGroups.Items.Add(fs.GroupLikes[c].Item2.ToString()); c++;
                }
            }
             */                       
            
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
        private void button2_Click(object sender, EventArgs e)
        {
            
            //*** getting additional informatino about page and showing in UI
            dgvPosts.DataSource = null;
            dgvPosts.Rows.Clear();
            dgvPosts.Refresh();
          
           
            KeyValuePair<String, String> pair = new KeyValuePair<string,string>();
            try
            {
                 //*** getting selected item [ID] from [ListBoxSearchResult ListBox]
                 pair = fs.ResultSearch.ElementAt(lbSearchResult.SelectedIndex);

                //*** getting pages liked by current page
                 fs.GetPageLikedPages(pair.Key.ToString());

                 GridViewUpdatePageName(fs); 

                 //*** getting page's post by current page
                 fs.GetPagePosts(pair.Key.ToString());
                 GridViewUpdatePagePost(fs);
                 

            }
            catch(Exception f) 
            {
                MessageBox.Show(f.ToString());
            }

            
        }
        /*
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (dataGridView2.CurrentCell.ColumnIndex == 1)
            {
                dataGridView3.Rows.Clear();
                dataGridView3.Refresh();
                string index = "0";
                try
                {
                    index = fs.Feed.ElementAt(dataGridView2.CurrentCell.RowIndex).Item1.ToString();
                    fs.GetPostDataByID(index,"10");
                    GridViewUpdatePagePostLikes(fs);
                    pictureBox4.Image = GetImageFromUrl(fs.ImageLink);
                    
                }
                catch { }

                    
            }
        
            

        }
         */             
       
               
        private void linkLabelProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //*** checking for valid url
            try
            {
                if (fs.Link.Contains("http") == true || fs.Link.Contains("www") == true)
                    Process.Start(fs.Link);
            }
            catch { }
        }
        private void button1Graph_Click(object sender, EventArgs e)
        {

            initialize_gragh();
            makegraph();
        }
        void initialize_gragh()
        {
          
            graph.GraphAttr.Fontsize = 8;
            graph.GraphAttr.FontName = "Arial";
            tabPage2.Controls.Add(viewer);
            viewer.Dock = DockStyle.Left;
            viewer.Refresh();
        }
        void makegraph()
        {

            string strNode1 = fs.Name;
            string strNode2 = "Likes";
            string strNode3 = "Posts";
            string strNode4 = "Movies";
            string strNode5 = "Book";
            string strNodeX = "";
            string strNodeLike  = "Liked By";
            string id = "";
            DataGridViewRow selectedRow;
            try
            {
                if (dgvPosts.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvPosts.SelectedCells[0].RowIndex;

                    selectedRow = dgvPosts.Rows[selectedrowindex];

                    id = Convert.ToString(selectedRow.Cells["ID"].Value);
                    strNodeX = Convert.ToString(selectedRow.Cells["Message"].Value);
                    strNodeX = strNodeX.Substring(0,20);
                }
            }
            catch { }

            //try { strNodeX = listBoxPosts.SelectedItem.ToString();  }
            //catch { }
            
            graph.AddEdge(strNode1, strNode2);
            graph.AddEdge(strNode1, strNode3);
            graph.AddEdge(strNode1, strNode4);
            graph.AddEdge(strNode1, strNode5);

            
            for (int Count = 0; Count < listBoxPages.Items.Count; Count++ )
                {
                    graph.AddEdge(strNode2, listBoxPages.Items[Count].ToString());
                }

            
            for (int Count = 0; Count < dgvPosts.Rows.Count; Count++)
            {
                try
                {
                    graph.AddEdge(strNode3, dgvPosts[1, Count].Value.ToString().Substring(0, 20));
                }
                catch { }
            }

            for (int Count = 0; Count < listBoxMovies.Items.Count; Count++)
            {
                graph.AddEdge(strNode4, listBoxMovies.Items[Count].ToString());
            }
            for (int Count = 0; Count < listBoxBooks.Items.Count; Count++)
            {
                graph.AddEdge(strNode5, listBoxBooks.Items[Count].ToString());
            }

            graph.AddEdge(strNodeX, strNodeLike);
            for (int Count = 0; Count < 5; ++Count)
            {
                graph.AddEdge(strNodeLike, lbPostLikeByUsers.Items[Count].ToString());
            }
            //bind the graph to the viewer
            viewer.Graph = graph;

            //associate the viewer with the form
            //Form2.SuspendLayout();
            viewer.Width = 1000;
            viewer.ZoomF = 4;
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            viewer.Dock = tabPage2.Dock;
            tabPage2.Controls.Add(viewer);            
            this.ResumeLayout();

            //show the form
            // this.ShowDialog();
        }
        /*
        void groupBoxCreate(int NoOfGBoxes, Panel container)
        {
            //UltraExpandableGroupBox[] gbBox;
            gbBox = new Infragistics.Win.Misc.UltraExpandableGroupBox[NoOfGBoxes];

            //UltraExpandableGroupBoxPanel[] gbPanel;
            gbPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel[NoOfGBoxes];

            //instantiate 
            for (int gb = 0; gb < NoOfGBoxes; gb++)
                gbPanel[gb] = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();

            for (int gb = 0; gb < NoOfGBoxes; gb++)
            {
                gbBox[gb] = new Infragistics.Win.Misc.UltraExpandableGroupBox();
                gbBox[gb].Controls.Add(gbPanel[gb]);
                gbBox[gb].Dock = System.Windows.Forms.DockStyle.Top;
                gbBox[gb].Expanded = false;
                gbBox[gb].ExpandedSize = new System.Drawing.Size(253, 115);
                gbBox[gb].Location = new System.Drawing.Point(18 * gb, 21);
                gbBox[gb].Name = "grpBoxPost" + gb.ToString();
                gbBox[gb].Size = new System.Drawing.Size(253, 21);
                gbBox[gb].TabIndex = 27;
                gbBox[gb].Text = "ultraExpandableGroupBox2";
                gbBox[gb].Visible = true;
                gbBox[gb].ExpandedStateChanged += new System.EventHandler(this.ultraGroupBox_ExpandedStateChanged);
                // 
                // ultraExpandableGroupBoxPanel2
                // 
                gbPanel[gb].Location = new System.Drawing.Point(-10000, -10000);
                gbPanel[gb].Name = "grpBoxPanelPost" + gb.ToString();
                gbPanel[gb].Size = new System.Drawing.Size(200, 100);
                gbPanel[gb].TabIndex = 0;
                gbPanel[gb].Visible = true;

                container.Controls.Add(gbBox[gb]);
            }

        } 
         */ 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //groupBoxCreate(5, panel7);
        }
        private void ultraGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            //UltraExpandableGroupBoxPanel ugb = sender as UltraExpandableGroupBoxPanel;
            //ugb.Controls.Add(label4);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbPostLikeByUsers.Items.Clear();
            //////////labelPostLikeCount.Text = "";
            rtbPostDescription.Text = "";
            labelPostLink.Text = "";
            //labelPostCreated.Text = "";
            //pictureBox4.Image = null;
            lbPostLikeByUsers.Items.Clear();
            dataGridView3PostLikersInfo.Refresh();
            string id = "";

            try
            {
                if (dgvPosts.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvPosts.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvPosts.Rows[selectedrowindex];
                    id = Convert.ToString(selectedRow.Cells["ID"].Value);
                    rtbPostDescription.Text = Convert.ToString(selectedRow.Cells["Message"].Value);
                }
            }
            catch { }
            //string id = fs.Feed[listBoxPosts.SelectedIndex].Item1.ToString();
            int count = 0;

            if (ps.Type == "page" || fs.Type == "page")
            {
                try
                {
                    ps.GetPostDataByID(id.ToString(), "50");
                    //richTextBoxPostDesc.Text = ps.Name;
                    labelPostLink.Text = ps.Link;
                    //labelPostCreated.Text = "Created Time : " + ps.CreatedTime;
                    while (count < ps.PostLikes.Count)
                    {
                        lbPostLikeByUsers.Items.Add(ps.PostLikes[count].Item1.ToString()); count++;
                    }

                    //////////labelPostLikeCount.Text = "Likes : " + lbPostLikeByUsers.Items.Count.ToString();

                    pbxPost.Image = GetImageFromUrl(ps.ImageLink);

                }
                catch { }

            }
        }
        private void listBoxPostLikedBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string id = ps.PostLikes[lbPostLikeByUsers.SelectedIndex].Item2.ToString();
            try
            {

                ls.Type = "user";
                ls.GetPageGeneralData(id);
                GridViewUpdate(ls, dataGridView3PostLikersInfo);
                ls.GetPictureByID(id);
                pbxLikedByUserProfile.Image = GetImageFromUrl(ls.ImageLink);

                DataGridViewColumn column0 = dataGridView3PostLikersInfo.Columns[0];
                column0.Width = 100;

                DataGridViewColumn column = dataGridView3PostLikersInfo.Columns[1];
                column.Width = 390;
            }
            catch { }
        }             
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (labelPostLink.Text.Contains("http") == true || labelPostLink.Text.Contains("www") == true)
                    Process.Start(labelPostLink.Text);
            }
            catch { }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ls.Link.Contains("http") == true || ls.Link.Contains("www") == true)
                    Process.Start(ls.Link);
            }
            catch { }
        }
        private void dgvPosts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbPostLikeByUsers.Items.Clear();
            //////////labelPostLikeCount.Text = "";
            rtbPostDescription.Text = "";
            labelPostLink.Text = "";
            //labelPostCreated.Text = "";
            //pictureBox4.Image = null;
            lbPostLikeByUsers.Items.Clear();
            dataGridView3PostLikersInfo.Refresh();
            string id = "";

            try
            {
                if (dgvPosts.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvPosts.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvPosts.Rows[selectedrowindex];
                    id = Convert.ToString(selectedRow.Cells["ID"].Value);
                    rtbPostDescription.Text = Convert.ToString(selectedRow.Cells["Message"].Value);
                }
            }
            catch { }
            //string id = fs.Feed[listBoxPosts.SelectedIndex].Item1.ToString();
            int count = 0;

            if (ps.Type == "page" || fs.Type == "page")
            {
                try
                {
                    ps.GetPostDataByID(id.ToString(), "50");
                    //richTextBoxPostDesc.Text = ps.Name;
                    labelPostLink.Text = ps.Link;
                    //labelPostCreated.Text = "Created Time : " + ps.CreatedTime;
                    while (count < ps.PostLikes.Count)
                    {
                        lbPostLikeByUsers.Items.Add(ps.PostLikes[count].Item1.ToString()); count++;
                    }

                    //////////labelPostLikeCount.Text = "Likes : " + lbPostLikeByUsers.Items.Count.ToString();

                    pbxPost.Image = GetImageFromUrl(ps.ImageLink);

                }
                catch { }

            }
        }
        private void lklUserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ls.Link.Contains("http") == true || ls.Link.Contains("www") == true)
                    Process.Start(ls.Link);
            }
            catch { }
        }

        private void pnlProfileInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSearchOption_Paint(object sender, PaintEventArgs e)
        {

        }

    
       
      
        //private void listBoxPostLikedBy_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    listBoxPostLikedBy.Items.Clear();
        //    labelPostLikeCount.Text = "";
        //    richTextBoxPostDesc.Text = "";
        //    labelPostLink.Text = "";
        //    //labelPostCreated.Text = "";
        //    //pictureBox4.Image = null;
        //    listBoxPostLikedBy.Items.Clear();
        //    dataGridView3PostLikersInfo.Refresh();


        //    string id = fs.Feed[listBoxPosts.SelectedIndex].Item1.ToString();
        //    int count = 0;
        //    if (ps.Type == "page" || fs.Type == "page")
        //    {
        //        try
        //        {
        //            ps.GetPostDataByID(id.ToString(), "50");
        //            richTextBoxPostDesc.Text = ps.Name;
        //            labelPostLink.Text = ps.Link;
        //            //labelPostCreated.Text = "Created Time : " + ps.CreatedTime;
        //            while (count < ps.PostLikes.Count)
        //            {
        //                listBoxPostLikedBy.Items.Add(ps.PostLikes[count].Item1.ToString()); count++;
        //            }

        //            labelPostLikeCount.Text = "Likes : " + listBoxPostLikedBy.Items.Count.ToString();

        //            pictureBox4.Image = GetImageFromUrl(ps.ImageLink);

        //        }
        //        catch { }

        //    }
          
        //}                                  
    }


    public class FacebookSearch
    {

        public dynamic FacebookData;
        public dynamic FacebookClient;
        public string  Name { get; set; }
        public string  ID   { get; set; }
        public dynamic Type { get; set; }
        public string  AccessToken { get; set; }
        public string  Link { get; set; }
        public string  ImageLink { get; set; }
        public string  CreatedTime { get; set; }
        public string  UpdatedTime { get; set; }
        public List<Tuple<string, string>> PageLikes = new List<Tuple<string, string>>();
        public List<Tuple<string, string>> Feed = new List<Tuple<string, string>>();
        public List<Tuple<string, string, string, string>> Feed_List = new List<Tuple<string, string, string, string>>();
        public List<Tuple<string, string>> MoviesLikes = new List<Tuple<string, string>>();
        public List<Tuple<string, string>> GroupLikes = new List<Tuple<string, string>>();
        public List<Tuple<string, string>> BookLikes = new List<Tuple<string, string>>();
        public List<Tuple<string, string>> PostLikes = new List<Tuple<string, string>>();
        //public List<Tuple<String, String>> ResultSearch = new List<Tuple<string, string>>();
        //public List<Dictionary<string, string>> ResultSearch = new List<Dictionary<string, string>>();
        public ICollection<KeyValuePair<String, String>> ResultSearch = new Dictionary<String, String>();

        public FacebookSearch(String AccessToken)  // constructor
        {
            //************* new instantiations ************
            Link = "";
            UpdatedTime = "";
            CreatedTime = "";
            Name = "";
            ID = "";
            ImageLink = "";
            Feed_List = new List<Tuple<string, string, string, string>>();
            PageLikes = new List<Tuple<string, string>>();
            Feed = new List<Tuple<string, string>>();
            MoviesLikes = new List<Tuple<string, string>>();
            GroupLikes = new List<Tuple<string, string>>();
            BookLikes = new List<Tuple<string, string>>();
            PostLikes = new List<Tuple<string, string>>();
            //ResultSearch = new List<Tuple<string, string>>();
            //ResultSearch = new List<Dictionary<string, string>>();
            ResultSearch = new Dictionary<string, string>();
            Type = "";
            FacebookClient = new FacebookClient(AccessToken);
        }
        public FacebookSearch()  // constructor
        {
            //************* new instantiations ************
            Link = "";
            CreatedTime = "";
            UpdatedTime = "";
            Name = "";
            ID = "";
            ImageLink = "";
            PageLikes = null;
            Feed = null;
            MoviesLikes = null;
            GroupLikes = null;
            BookLikes = null;
            PostLikes = null;
            Type = "";
            //FacebookClient = new FacebookClient(AccessToken);

        }
        public void Query(string name, string type, string place, string limit)
        {
                this.Type = type;
                //this.FacebookData = this.FacebookClient.Get("/search?q=" + name + "&type="+type);
                if (type == "user")
                {
                    try
                    {
                        this.FacebookData = FacebookClient.Get("/search?q=" + name + " in " + place + "&type=" + type + "&limit=" + limit);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return;
                    }
                }

                if (type == "page" || type == "group")
                {
                    try
                    {
                        this.FacebookData = FacebookClient.Get("/search?q=" + name + "&type=" + type + "&limit=" + limit);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return;
                    }
                }

                this.FacebookData = (IDictionary<string, object>)this.FacebookData;

                foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
                {
                    try
                    {

                        ResultSearch.Add(new KeyValuePair<String, String>((string)(((JsonObject)L1)["id"]), (string)(((JsonObject)L1)["name"])));
                        //ResultSearch.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["id"])), ((string)(((JsonObject)L1)["name"]))));
                    
                    }
                    catch { }
                }
            }         
        public void GetUserDataByID(string id, string limit)
        {
            if (this.Type == "user")
            {
                //******************** my id *****************
                this.FacebookData = FacebookClient.Get("/" + id);
                this.FacebookData = (IDictionary<string, object>)this.FacebookData;

                this.Name = ((string)(((JsonObject)this.FacebookData)["name"]));
                this.ID = ((string)(((JsonObject)this.FacebookData)["id"]));
                this.Link = ((string)(((JsonObject)this.FacebookData)["link"]));
                this.UpdatedTime = ((string)(((JsonObject)this.FacebookData)["updated_time"]));

            
                //************* Getting Likes *************
                this.FacebookData = FacebookClient.Get("/" + this.ID + "/likes?limit="+limit);
                this.FacebookData = (IDictionary<string, object>)this.FacebookData;

                foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
                {
                    try
                    {
                        this.PageLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["name"])), ((string)(((JsonObject)L1)["id"]))));
                    }
                    catch { }
                }

                //************* Getting group likes *************
                this.FacebookData = FacebookClient.Get("/" + id + "/groups?limit=" + limit);
                this.FacebookData = (IDictionary<string, object>)this.FacebookData;

                foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
                {
                    try
                    {
                        GroupLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["name"])), ((string)(((JsonObject)L1)["id"]))));
                    }
                    catch { }
                }

                //************* Getting Book likes *************
                this.FacebookData = FacebookClient.Get("/" + id + "/books?limit=" + limit);
                this.FacebookData = (IDictionary<string, object>)this.FacebookData;

                foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
                {
                    try
                    {
                        BookLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["name"])), ((string)(((JsonObject)L1)["id"]))));
                    }
                    catch { }
                }

                //************* Getting Movies likes *************
                this.FacebookData = FacebookClient.Get("/" + id + "/movies?limit="+limit);
                this.FacebookData = (IDictionary<string, object>)this.FacebookData;

                foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
                {
                    try
                    {
                        MoviesLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["name"])), ((string)(((JsonObject)L1)["id"]))));
                    }
                    catch { }
                }

                
            }


        }
        public void GetPageLikedPages(string id)
        {
            //************* Getting Likes *************
            this.FacebookData = FacebookClient.Get("/" + id + "/likes?limit=100");
            this.FacebookData = (IDictionary<string, object>)this.FacebookData;

            //foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
            //{
            //    this.PageLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["name"])), ((string)(((JsonObject)L1)["id"]))));
            //}

        }
        public void GetPagePosts(string id)
        {
            //************* Getting page post *************
            Feed.Clear();
            Feed_List.Clear();
            this.FacebookData = FacebookClient.Get("/" + id + "/posts?limit=20");
            this.FacebookData = (IDictionary<string, object>)this.FacebookData;

            
            foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
            {
                try
                {
                    this.Feed.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["object_id"])), ((string)(((JsonObject)L1)["message"]))));
                    this.Feed_List.Add(new Tuple<string, string, string, string>(((string)(((JsonObject)L1)["object_id"])), ((string)(((JsonObject)L1)["message"])), ((string)(((JsonObject)L1)["created_time"])), ((string)(((JsonObject)L1)["updated_time"]))));
                }
                catch { }
            }
             

        }
        public void GetPageDataByID(string id, string limit)
        {
                //******************** my id *****************
                this.FacebookData = FacebookClient.Get("/" + id);
                this.FacebookData = (IDictionary<string, object>)this.FacebookData;
                this.Name = ((string)(((JsonObject)this.FacebookData)["name"]));
                this.ID = ((string)(((JsonObject)this.FacebookData)["id"]));

                
             //     this.ImageLink   = ((string)(((JsonObject)this.FacebookData)["source"]));
             //     this.CreatedTime = ((string)(((JsonObject)this.FacebookData)["created_time"]));
             //     this.UpdatedTime = ((string)(((JsonObject)this.FacebookData)["updated_time"]));


                this.FacebookData = FacebookClient.Get("/" + id + "/picture?width=500&height=500&redirect=false");
                this.FacebookData = (IDictionary<string, object>)this.FacebookData;
                this.ImageLink = ((string)(((JsonObject)this.FacebookData["data"])["url"]));              
                                          
        }
        public void GetPageGeneralData(string id)
        {
            //******************** my id *****************
            this.FacebookData = FacebookClient.Get("/" + id);
            this.FacebookData = (IDictionary<string, object>)this.FacebookData;
            this.Link = ((string)((this.FacebookData["link"])));
        }      
        public void GetPostDataByID(string id, string limit)
        {
            this.PostLikes.Clear();
            //************* Getting Likes *************
            this.FacebookData = FacebookClient.Get("/" + id + "/likes?limit=900");
            this.FacebookData = (IDictionary<string, object>)this.FacebookData;

            foreach (dynamic L1 in (JsonArray)this.FacebookData["data"])
            {
                this.PostLikes.Add(new Tuple<string, string>(((string)(((JsonObject)L1)["name"])), ((string)(((JsonObject)L1)["id"]))));
            }

            //************* Getting General Data about post *************
            this.FacebookData = FacebookClient.Get("/" + id);
            this.FacebookData = (IDictionary<string, object>)this.FacebookData;

            try
            {
                this.Name = ((string)((this.FacebookData["name"])));
            }
            catch { }
            this.Link = ((string)((this.FacebookData["link"])));
            this.ImageLink = ((string)((this.FacebookData["source"])));
            this.CreatedTime = ((string)((this.FacebookData["created_time"])));

                           

        }
        public void GetPictureByID(string id)
        {

            this.FacebookData = FacebookClient.Get("/" + id + "/picture?width=500&height=500&redirect=false");
            this.FacebookData = (IDictionary<string, object>)this.FacebookData;
            this.ImageLink = ((string)(((JsonObject)this.FacebookData["data"])["url"]));              
           
        }   
    }
}
