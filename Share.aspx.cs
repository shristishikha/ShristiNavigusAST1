using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

public partial class Share : System.Web.UI.Page
{
    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UMain.aspx");
    }
    protected void btnShare_Click(object sender, EventArgs e)
    {
        try
        {
            string mail = txtShare.Text.Trim().ToLower();
            cn.Open();
            DataTable dt = new DataTable();
            string data = "select u_id from user where lower(email) = '" + mail + "'";
            MySqlCommand cmd = new MySqlCommand(data, cn);
            MySqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            string id = dt.Rows[0][0].ToString();
            dt = new DataTable();
            data = "select * from page_access where u_id = " + id + " and p_id = " + Session["pid"].ToString();
            cmd = new MySqlCommand(data, cn);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            cn.Close();
            if (dt.Rows.Count == 0)
            {
                cn.Open();
                data = "insert into page_access(P_id, U_id, Status) values('" + Session["pid"].ToString() + "'," + id + ", 'INACTIVE')";
                cmd = new MySqlCommand(data, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Shared successfully...');", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Some error occured. Sharing unsuccessful...');", true);
        }
        
    }
}