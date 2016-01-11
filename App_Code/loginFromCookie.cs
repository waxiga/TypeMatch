using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// loginFromCookie 的摘要说明
/// </summary>
public class loginFromCookie
{
	public loginFromCookie()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static bool loginFromCookieOnly()
    {
        string username = cookieOperation.getOneCookie("userName").ToString();
        string logincode = cookieOperation.getOneCookie("loginCode").ToString();
        string realname="",password="", role="";
        if (username != "" && logincode != "")
        {

            OleDbConnection con = DB.createcon();
            string sqlstr = "select * from [student] where [studentUsername]='" + username + "'";
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = sqlstr;
            cmd.Connection = con;
            OleDbDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                password = sdr["studentPassword"].ToString();
                role = sdr["roleType"].ToString();
                realname = sdr["studentName"].ToString();
            }
            sdr.Close();
            con.Close();
            //HttpContext.Current.Response.Write(MD5Encode.docubleMD5_encode(username, password)+"<br>");
            //HttpContext.Current.Response.Write(logincode);
            if (MD5Encode.docubleMD5_encode(username, password) == logincode)
            {
                HttpContext.Current.Session["userType"] = role;
                HttpContext.Current.Session["realName"] = realname;
                HttpContext.Current.Session["userName"] = username;
                cookieOperation.setOneCookie("userType", role);
                cookieOperation.setOneCookie("realName", realname);
                cookieOperation.setOneCookie("userName", username);
                cookieOperation.setOneCookie("loginCode", logincode);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
