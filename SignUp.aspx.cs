using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

public partial class SignUp : System.Web.UI.Page
{
    MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string namep = @"(^[a-zA-Z]+[a-zA-Z ]*$)";
            string emailp = @"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$";
            Regex nmr = new Regex(namep);
            Regex emr = new Regex(emailp);
            int flag = 0;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPwd.Text;
            string str = flupPic.FileName;
            if (nmr.IsMatch(name) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Name..');", true);
                flag = 1;
            }
            if (emr.IsMatch(email) == false)
            {
                flag = 1;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Email..');", true);
            }
            if (pass != txtCPwd.Text && pass.Length < 6)
            {
                flag = 1;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Invalid Password..');", true);
            }
            if (flag != 1)
            {
                flupPic.PostedFile.SaveAs(Server.MapPath("~/Upload/" + str));
                string image = "~/Upload/" + str.ToString();
                /*HttpPostedFile postedFile = flupPic.PostedFile;
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                Byte[] image = binaryReader.ReadBytes((int)stream.Length);*/
                cn.Open();
                string data = "insert into user(Name, Email, Password, Pic) values('" + name + "','" + email + "','" + pass + "','" + image + "')";
                MySqlCommand cmd = new MySqlCommand(data, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Account Created...');", true);
            }
        }
        catch (MySqlException ex)
        {
            cn.Close();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Error...');", true);
        }
    }
}