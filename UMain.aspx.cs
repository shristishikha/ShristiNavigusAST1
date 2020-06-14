using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

public partial class UMain : System.Web.UI.Page
{
    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["error"] == "1")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Page not accessibe...');", true);
                Session["error"] = "0";
            }
            DataTable dt = new DataTable();
            cn.Open();
            string data = "select page_name from page";
            MySqlCommand cmd = new MySqlCommand(data, cn);
            MySqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            cn.Close();
            if (dt.Rows.Count != 0)
            {
                gv.Visible = true;
                gv.DataSource = dt;
                gv.DataBind();
                Label1.Visible = false;
            }
            else
            {
                gv.Visible = false;
                Label1.Visible = true;
                Label1.Text = "No page to access";
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Some issue occured...');", true);
        }
            
    }
    protected void lbtnNPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CreatePage.aspx");
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        string s = Convert.ToString((sender as LinkButton).CommandArgument);
        Response.Redirect("~/"+ s + ".aspx");
    }
}