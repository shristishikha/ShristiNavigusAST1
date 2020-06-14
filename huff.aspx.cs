using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
public partial class huff: System.Web.UI.Page
{
MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
protected void Page_Load(object sender, EventArgs e)
{
lblPage.Text = "Welcome to Page " + this.ToString();
string pnm = this.ToString().Split('_')[0].Split('.')[1];
try
{
DataTable dt = new DataTable();
cn.Open();
string data = "select * from page where lower(page_name) = '" + pnm.ToLower() + "'";
MySqlCommand cmd = new MySqlCommand(data, cn);
MySqlDataReader rd = cmd.ExecuteReader();
dt.Load(rd);
Session["pid"] = dt.Rows[0][0];
dt = new DataTable();
data = "select * from page_access where p_id = " + Session["pid"].ToString() + " and u_id = " + Session["uid"].ToString();
cmd = new MySqlCommand(data, cn);
rd = cmd.ExecuteReader();
dt.Load(rd);
if (dt.Rows.Count == 0)
{
Session["error"] = "1";
Response.Redirect("~/UMain.aspx");
}
data = "update page_access set status = 'ACTIVE' where p_id = " + Session["pid"].ToString() + " and u_id = " + Session["uid"].ToString() ;
cmd = new MySqlCommand(data, cn);
cmd.ExecuteNonQuery();
dt = new DataTable();
data = "select count(*) from page_access where p_id = " + Session["pid"].ToString() + " and status = 'ACTIVE'";
cmd = new MySqlCommand(data, cn);
rd = cmd.ExecuteReader();
dt.Load(rd);
data = "Insert into page_history (p_id,u_id,last_visit) values(" + Session["pid"].ToString() + "," + Session["uid"].ToString() + "," + DateTime.Now;
cmd = new MySqlCommand(data, cn);
cmd.ExecuteNonQuery();
cn.Close();
btnCurr.Text = dt.Rows[0][0].ToString();
}
catch
{
ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Error Occured...');", true);
cn.Close();
}
}
protected void btnShare_Click(object sender, EventArgs e)
{
Response.Redirect("~/Share.aspx");
}
protected void btnCurr_Click(object sender, EventArgs e)
{
try
{
cn.Open();
DataTable dt = new DataTable();
string data = "select name, email from user where u_id in (select u_id from page_access where p_id = " + Session["pid"].ToString() + " and status = 'ACTIVE')";
MySqlCommand cmd = new MySqlCommand(data, cn);
MySqlDataReader rd = cmd.ExecuteReader();
dt.Load(rd);
gvCurr.Visible = true;
gvCurr.DataSource = dt;
gvCurr.DataBind();
cn.Close();
}
catch
{
ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Some error occured...');", true);
cn.Close();
}
}
protected void btnHis_Click(object sender, EventArgs e)
{
if (btnHis.Text == "Show History")
{
btnHis.Text = "Hide History";
gvCurr.Visible = true;
cn.Open();
DataTable dt = new DataTable();
string data = "select u.name, u.email, h.last_visit from user u, page_history h where u.u_id = h.u_id and h.p_id = " + Session["pid"].ToString();
MySqlCommand cmd = new MySqlCommand(data, cn);
MySqlDataReader rd = cmd.ExecuteReader();
dt.Load(rd);
gvCurr.DataSource = dt;
cn.Close();
}
else if (btnHis.Text == "Hide History")
{
btnHis.Text = "Show History";
gvCurr.Visible = false;
}
}
}
