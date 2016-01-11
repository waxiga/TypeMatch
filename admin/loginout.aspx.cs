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

public partial class admin_loginout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string alertStr = "<h1>注销成功</h1>";
        try
        {
            Session.Remove("userType");
            Session.Remove("userName");
            Session.Remove("realName");
            cookieOperation.delOneCookie("login");
            if (Session["userType"] == null && cookieOperation.cookieIsOn("login")==false)
            {
                alertStr ="<h1>注销成功!</h1>1秒后自动返回首页.<script language='javascript'>window.setTimeout(\"window.location='../default.aspx'\",1000);</script>";
            }
        }
        catch(Exception exp)
        {
            saveErrorMessage.writeFile("注销时出错", exp.ToString());
        }
        Response.Write(alertStr);
    }
}
