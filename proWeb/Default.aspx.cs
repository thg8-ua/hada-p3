using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<br>Page has been posted back.");
            }
        }

        protected void code_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void amount_TextChanged(object sender, EventArgs e)
        {

        }

        protected void category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void price_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date_TextChanged(object sender, EventArgs e)
        {

        }

        protected void create_Click(object sender, EventArgs e)
        {
            Button buttonClick = sender as Button;
        
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Button buttonClick = sender as Button;
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Button buttonClick = sender as Button;
        }

        protected void read_Click(object sender, EventArgs e)
        {
            Button buttonClick = sender as Button;
        }

        protected void readfirst_Click(object sender, EventArgs e)
        {
            Button buttonClick = sender as Button;
        }

        protected void readprev_Click(object sender, EventArgs e)
        {
            Button buttonClick = sender as Button;
        }

        protected void readnext_Click(object sender, EventArgs e)
        {
            Button buttonClick = sender as Button;
        }
    }
}