using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;


public partial class CreatePage : System.Web.UI.Page
{
    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UMain.aspx");
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            cn.Open();
            string data = "select * from page where lower(page_name) = '" + txtPName.Text.Trim().ToLower() + "'";
            MySqlCommand cmd = new MySqlCommand(data, cn);
            MySqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            cn.Close();
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Page already exist...');", true);
            }
            else
            {
                string[] srccode = genAspx();
                string[] codefile = genCs();
                File.WriteAllLines(Server.MapPath("" + txtPName.Text.Trim() + ".aspx"), srccode);
                File.WriteAllLines(Server.MapPath("" + txtPName.Text.Trim() + ".aspx.cs"), codefile);
                cn.Open();
                data = "insert into page(Page_Name, U_id) values('" + txtPName.Text.Trim() + "'," + Convert.ToInt32(Session["uid"].ToString()) + ")";
                cmd = new MySqlCommand(data, cn);
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                data = "select P_id from page where lower(page_name) = '" + txtPName.Text.Trim().ToLower() + "'";
                cmd = new MySqlCommand(data, cn);
                rd = cmd.ExecuteReader();
                dt1.Load(rd);
                int pid = Convert.ToInt32(dt1.Rows[0][0].ToString());
                data = "insert into page_access(P_id, U_id, Status) values('" + pid + "'," + Convert.ToInt32(Session["uid"].ToString()) + ", 'ACTIVE')";
                cmd = new MySqlCommand(data, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Page Created...');", true);
                Response.Redirect("" + txtPName.Text.Trim() + ".aspx");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Some issue occured while creating page...');", true);
        }
    }
    public string[] genAspx()
    {
        string[] srccode = {"<%@ Page Title=\"\" Language=\"C#\" MasterPageFile=\"~/User.master\" AutoEventWireup=\"true\" CodeFile=\"" + txtPName.Text.Trim() + ".aspx.cs\" Inherits=\"" + txtPName.Text.Trim() + "\" %>",
                                        "<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"head\" Runat=\"Server\">",
                                        "</asp:Content>",
                                        "<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"ContentPlaceHolder1\" Runat=\"Server\">",
                                        "<div runat = \"server\" style = \"margin:30px 0 0 378px;width:900px;background:white;min-height:450px;padding:50px 0 0 50px\">",
                                        "<div style =\"position:fixed;height:30px;float:right;margin-left:50%;\">",
                                        "<asp:Label ID=\"Label1\" runat=\"server\" Text=\"Currently Active \"></asp:Label>&nbsp;&nbsp;&nbsp;",
                                        "<asp:Button ID=\"btnCurr\" runat=\"server\" Text=\"\" OnClick=\"btnCurr_Click\"/>",
                                        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;",
                                        "<asp:Button ID=\"btnHis\" runat=\"server\" Text=\"Show History\" OnClick=\"btnHis_Click\" />",
                                        "</div>",
                                        "<br /><br /><br />",
                                        "<asp:Button ID=\"btnShare\" runat=\"server\" Text=\"Share\" style=\"text-align:left;float:right;margin-right:80px\" OnClick=\"btnShare_Click\"/>",
                                        "<br />",
                                        "<asp:Label ID=\"lblPage\" runat=\"server\" Text=\"\"></asp:Label>",
                                        "<br />  <br />",
                                        "<asp:GridView ID=\"gvCurr\" runat=\"server\" Visible =\"false\"></asp:GridView>",
                                        "</div>",
                                        "</asp:Content>"
                                    };
        return srccode;
    }
    public string[] genCs()
    {
        string[] codefile = {"using System;",
                                        "using System.Collections.Generic;",
                                        "using System.Linq;",
                                        "using System.Web;",
                                        "using System.Web.UI;",
                                        "using System.Web.UI.WebControls;",
                                        "using MySql.Data.MySqlClient;",
                                        "using System.Configuration;",
                                        "using System.Data;",

                                        "public partial class " + txtPName.Text.Trim() + ": System.Web.UI.Page",
                                        "{",
                                            "MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings[\"cn\"].ConnectionString);",
                                            "protected void Page_Load(object sender, EventArgs e)",
                                            "{",
                                                "lblPage.Text = \"Welcome to Page \" + this.ToString();",
                                                "string pnm = this.ToString().Split('_')[0].Split('.')[1];",
                                                "try",
                                                "{",
                                                    "DataTable dt = new DataTable();",
                                                    "cn.Open();",
                                                    "string data = \"select * from page where lower(page_name) = '\" + pnm.ToLower() + \"'\";",
                                                    "MySqlCommand cmd = new MySqlCommand(data, cn);",
                                                    "MySqlDataReader rd = cmd.ExecuteReader();",
                                                    "dt.Load(rd);",
                                                    "Session[\"pid\"] = dt.Rows[0][0];",
                                                    "dt = new DataTable();",
                                                    "data = \"select * from page_access where p_id = \" + Session[\"pid\"].ToString() + \" and u_id = \" + Session[\"uid\"].ToString();",
                                                    "cmd = new MySqlCommand(data, cn);",
                                                    "rd = cmd.ExecuteReader();",
                                                    "dt.Load(rd);",
                                                    "if (dt.Rows.Count == 0)",
                                                    "{",
                                                        "Session[\"error\"] = \"1\";",
                                                        "Response.Redirect(\"~/UMain.aspx\");",
                                                    "}",
                                                    "data = \"update page_access set status = 'ACTIVE' where p_id = \" + Session[\"pid\"].ToString() + \" and u_id = \" + Session[\"uid\"].ToString() ;",
                                                    "cmd = new MySqlCommand(data, cn);",
                                                    "cmd.ExecuteNonQuery();",
                                                    "dt = new DataTable();",
                                                    "data = \"select count(*) from page_access where p_id = \" + Session[\"pid\"].ToString() + \" and status = 'ACTIVE'\";",
                                                    "cmd = new MySqlCommand(data, cn);",
                                                    "rd = cmd.ExecuteReader();",
                                                    "dt.Load(rd);",
                                                    "data = \"Insert into page_history (p_id,u_id,last_visit) values(\" + Session[\"pid\"].ToString() + \",\" + Session[\"uid\"].ToString() + \",'\" + DateTime.Now.ToString() +\"')\";",
                                                    "cmd = new MySqlCommand(data, cn);",
                                                    "cmd.ExecuteNonQuery();",
                                                    "cn.Close();",
                                                    "btnCurr.Text = dt.Rows[0][0].ToString();",
                                                "}",
                                                "catch",
                                                "{",
                                                    "ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), \"alert\", \"alert('Error Occured...');\", true);",
                                                    "cn.Close();",
                                                "}",
                                            "}",
                                            "protected void btnShare_Click(object sender, EventArgs e)",
                                            "{",
                                                "Response.Redirect(\"~/Share.aspx\");",
                                            "}",
                                            "protected void btnCurr_Click(object sender, EventArgs e)",
                                            "{",
                                                "try",
                                                "{",
                                                    "cn.Open();",
                                                    "DataTable dt = new DataTable();",
                                                    "string data = \"select name, email from user where u_id in (select u_id from page_access where p_id = \" + Session[\"pid\"].ToString() + \" and status = 'ACTIVE')\";",
                                                    "MySqlCommand cmd = new MySqlCommand(data, cn);",
                                                    "MySqlDataReader rd = cmd.ExecuteReader();",
                                                    "dt.Load(rd);",
                                                    "gvCurr.Visible = true;",
                                                    "gvCurr.DataSource = dt;",
                                                    "gvCurr.DataBind();",
                                                    "cn.Close();",
                                                "}",
                                                "catch",
                                                "{",
                                                    "ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), \"alert\", \"alert('Some error occured...');\", true);",
                                                    "cn.Close();",
                                                "}",
                                            "}",
                                            "protected void btnHis_Click(object sender, EventArgs e)",
                                            "{",
                                                "if (btnHis.Text == \"Show History\")",
                                                "{",
                                                    "btnHis.Text = \"Hide History\";",
                                                    "gvCurr.Visible = true;",
                                                    "cn.Open();",
                                                    "DataTable dt = new DataTable();",
                                                    "string data = \"select u.name, u.email, h.last_visit from user u, page_history h where u.u_id = h.u_id and h.p_id = \" + Session[\"pid\"].ToString();",
                                                    "MySqlCommand cmd = new MySqlCommand(data, cn);",
                                                    "MySqlDataReader rd = cmd.ExecuteReader();",
                                                    "dt.Load(rd);",
                                                    "gvCurr.DataSource = dt;",
                                                    "gvCurr.DataBind();",
                                                    "cn.Close();",
                                                "}",
                                                "else if (btnHis.Text == \"Hide History\")",
                                                "{",
                                                    "btnHis.Text = \"Show History\";",
                                                    "gvCurr.Visible = false;",
                                                "}",
                                            "}",
                                        "}"
                                    };
        return codefile;
    }
}