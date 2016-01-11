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

public partial class admin_reply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!adminOperation.checkIfAdmin())
        {
            string repsonStr = "<script language='javascript'>alert('对不起,你尚未登陆,或者你不是管理员,不能执行该操作!');window.location='../login.html';</script>";
            Response.Write(repsonStr);
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                string responseMessage = "<script language='javascript'>alert('操作有误，请重试！');window.location='messages.aspx';</script>";
                Response.Write(responseMessage);
            }
            else
            {
                Session["messageId"] = Request.QueryString["id"];
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string responseMessage = "alert('回复失败，请重试！');";
        if (studentOperation.checkIfLogin())
        {
            string messageBody = "";
            string messageID = "";
            if (Session["messageId"] == null)
            {
                responseMessage = "alert('操作有误，请重试！');";
            }
            else
            {
                try
                {
                    messageID = Session["messageId"].ToString();
                    messageBody = this.TextBox1.Text.ToString();
                    OleDbConnection con = DB.createcon();
                    OleDbCommand cmd = new OleDbCommand();
                    string updateCommandTxt = "UPDATE [message] SET [ifNew]=true,[ifHaveRe] =true, [reBody] =@rebody WHERE [messageID] =@messageid";
                    cmd.CommandText = updateCommandTxt;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@rebody", messageBody);
                    cmd.Parameters.AddWithValue("@messageid", messageID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Remove("messageId");
                    responseMessage = "alert('站内信回复成功！');window.location='messages.aspx';";
                }
                catch(Exception exp)
                {
                    saveErrorMessage.writeFile("回复站内信或留言时出错．", exp.ToString());
                }
            }
        }
        else
        {
            responseMessage = "alert('你尚未登陆，不能回复，请先登陆！');window.location='../login.html';";
        }
        Response.Write("<script language='javascript'>" + responseMessage + "</script>");
    }
}
