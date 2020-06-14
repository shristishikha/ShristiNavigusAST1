using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string email = TextBox1.Text;
            string pass = TextBox2.Text;

            cn.Open();
            string qry = "select * from user where Email='" + email + "' and Password='" + pass + "'";
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(qry, cn);
            MySqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            cn.Close();
            if (dt.Rows.Count == 1)
            {
                Session["uid"] = dt.Rows[0][0].ToString();
                Response.Redirect("~/UMain.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Incorrect Email and Password.');", true);
            }
        }
        catch
        {
            cn.Close();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Error....');", true);
        }
    }
}