using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class admin_setmanage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!adminOperation.checkIfAdmin())
        {
            string repsonStr = "<script language='javascript'>alert('对不起,你尚未登陆,或者你不是管理员,不能执行该操作!');window.location='../login.html';</script>";
            Response.Write(repsonStr);
        }
        if (adminOperation.checkIfAdmin())
        {
            if (!IsPostBack)
            {
                this.username.Text = Session["userName"].ToString();
                if (Session["userType"].ToString() == "3")
                {
                    this.alluserTable.Visible = true;
                    OleDbConnection con = DB.createcon();
                    OleDbCommand cmd = new OleDbCommand("select * from [student] where roleType=2 or roleType=3", con);
                    con.Open();
                    OleDbDataReader odr = cmd.ExecuteReader();
                    this.Repeater1.DataSource = odr;
                    this.Repeater1.DataBind();
                    odr.Close();
                    con.Close();
                }
            }
        }
        else
        {
            string alertTxt = "<script language='javascript'>alert('对不起,你尚未登陆或登陆超时,不能执行操作!');window.location='../login.html';</script>";
            Response.Write(alertTxt);
        }
    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string alertTxt = "<script language='javascript'>alert('修改成功！请牢记新密码.');</script>";
        if (this.password.Value == this.password2.Value)
        {
            try
            {
                string userName = Session["userName"].ToString();
                string newPassword = this.password.Value.ToString();
                string passMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "MD5");
                OleDbConnection con = DB.createcon();
                OleDbCommand cmd = new OleDbCommand("update [student] set [studentPassword]='" + passMD5 + "' where [studentUsername]='" + userName + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception exp)
            {
                saveErrorMessage.writeFile("修改管理员密码时出错", exp.Message.ToString());
                alertTxt = "<script language='javascript'>alert('修改失败，请重试！');</script>";
            }
        }
        else
        {
            alertTxt = "<script language='javascript'>alert('两次输入的密码不一样!');</script>";
            
        }
        Response.Write(alertTxt);
    }
    protected void Submit2_ServerClick(object sender, EventArgs e)
    {
        string alertTxt = "<script language='javascript'>alert('添加成功！');</script>";
        if (this.newUserpass.Value.ToString()==this.newUserpass2.Value.ToString())
        {
            string newUser = this.newUsername.Value.ToString();
            string newPass = this.newUserpass.Value.ToString();
            if (studentOperation.checkUsernameIfEnable(newUser)==0)
            {
                try
                {
                    string passMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPass, "MD5");
                    OleDbConnection con = DB.createcon();
                    OleDbCommand cmd = new OleDbCommand("insert into [student] (studentUsername,studentPassword,roleType) values ('" + newUser + "','" + passMD5 + "',2)", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception exp)
                {
                    saveErrorMessage.writeFile("添加管理员时出错", exp.Message.ToString());
                    alertTxt = "<script language='javascript'>alert('添加管理员失败，请重试！');</script>";
                }
            }
            else
            {
                alertTxt = "<script language='javascript'>alert('添加失败,用户名重复，请重试！');</script>";
            }
        }
        else
        {
            alertTxt = "<script language='javascript'>alert('两次输入的密码不一样!');</script>";
        }
        Response.Write(alertTxt);
    }
}
