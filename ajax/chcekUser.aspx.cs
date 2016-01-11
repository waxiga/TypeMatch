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

public partial class ajax_chcekUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        if (Session["tryCount"] == null)//用户名或密码错误次数不得超过一定界限
        {
            Session["tryCount"] = 1;
        }
        if (Convert.ToInt32(Session["tryCount"]) >50)
        {
            i = 2;
        }
        else
        {
            if (Request.Form["uid"] != null && Request.Form["pwd"] != null)
            {
                try
                {
                    string username =SqlString.keepoutSqlKey(Request.Form["uid"]);
                    string password = SqlString.keepoutSqlKey(Request.Form["pwd"]);
                    OleDbConnection con = DB.createcon();
                    string sqlstr = "select * from [student] where [studentUsername]='" + username + "'  and ([studentPassword]='" + password + "' or [studentPassword]='" + MD5_encode(password) + "')";
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = sqlstr;
                    cmd.Connection = con;
                    OleDbDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        string role=sdr["roleType"].ToString();
                        string realname = sdr["studentName"].ToString();
                        password = sdr["studentPassword"].ToString();
                        Session["userType"] = role;
                        Session["realName"] = realname;
                        Session["userName"] = username;
                        cookieOperation.setOneCookie("userType",role);
                        cookieOperation.setOneCookie("realName", realname);
                        cookieOperation.setOneCookie("userName", username);
                        string logincode = MD5Encode.docubleMD5_encode(username, password);
                        cookieOperation.setOneCookie("loginCode", logincode);
                        i = 1;
                    }
                    sdr.Close();
                    con.Close();
                    if (i == 1)
                    {
                        string mydatetime = DateTime.Now.ToString();
                        string ip = Request.ServerVariables["REMOTE_HOST"].ToString();
                        string sqlstr2 = "update [student] set loginCount=loginCount+1,lastLoinTime='" + mydatetime + "',lastLoinIP='" + ip + "' where studentUsername='"+username+"'";
                        cmd.CommandText = sqlstr2;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        switch (Session["userType"].ToString())
                        {
                            case "2":
                                countOperation.countAddOne("adminLoginCount");
                                countOperation.countAddOne("onlineStudent");
                                systemRecord.insertOneRecord("管理员“"+username+"“登陆成功！");
                                break;
                            case "3":
                                countOperation.countAddOne("superAdminLoginCount");
                                countOperation.countAddOne("onlineStudent");
                                systemRecord.insertOneRecord("超级管理员“" + username + "“登陆成功！");
                                break;
                            default:
                                countOperation.countAddOne("onlineStudent");
                                systemRecord.insertOneRecord("学生“" + username + "“登陆成功！");
                                break;
                        }
                    }
                }
                catch (Exception exp)
                {
                    saveErrorMessage.writeFile("用户登陆时发生错误！", exp.ToString());
                    i = 0;
                }
            }
        }
        if (i == 0)
        {
            Session["tryCount"] = Convert.ToInt32(Session["tryCount"]) + 1;
        }
        Response.Write(i.ToString());
    }
    public string MD5_encode(string needMD5EncodeString)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(needMD5EncodeString, "MD5");
    }
}
