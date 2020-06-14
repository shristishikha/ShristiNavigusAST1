using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

public partial class User : System.Web.UI.MasterPage
{
    static int id;
    static int pid = 0;
    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            id = Convert.ToInt32(Session["uid"].ToString());
            try
            {
                cn.Open();
                string qry = "select Name, Pic from user where U_id=" + id + ";";
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand(qry, cn);
                MySqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                cn.Close();
                Image1.ImageUrl = dt.Rows[0][1].ToString();

            }
            catch (MySqlException ex)
            {
                cn.Close();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Error...');", true);
            }
        }
        if (Session["pid"] != null)
            pid = Convert.ToInt32(Session["pid"].ToString());
        else if (pid != 0)
        {
            cn.Open();
            string data = "update page_access set status = 'INACTIVE' where p_id = " + pid + " and u_id = " + id;
            MySqlCommand cmd = new MySqlCommand(data, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
