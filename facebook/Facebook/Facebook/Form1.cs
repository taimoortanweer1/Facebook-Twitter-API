using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            var fb = new FacebookClient("CAACEdEose0cBABXcorjdMKZBaZA0qaJnsX3k9uzckRZANEVQKJPmYFcRwoGydvnaeCR2IoAfCUAR8mdEMX3TyY44JCC1zZAY5lTbD24eSGKB6ICoZC61XsxpZCl2yPt5kfLZAlZBlhkvdr0VRiHmZCsi6KL3yyZCJloQfD4LBbAWNPqi4ohUzPrkZCfHGlIA4bOKD9loFpxAimqGKYUYCUbdqf0H4xTvWhZA4jkrfSGmG6ZBLZBQZDZD");

            dynamic result = fb.Get("139041419482037/feed?fields=id,full_picture,likes{link,name,profile_type,id,picture},comments,link,shares,updated_time,created_time,message,message_tags,properties,place,with_tags,subscribed");
            
                
          
            
            dynamic id = result.id;
            dynamic firstName = result.first_name;
            dynamic lastName = result.last_name;
            dynamic link = result.link;
            dynamic locale = result.locale;
        }
    }
}
