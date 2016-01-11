using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// cookieOperation 的摘要说明
/// </summary>
public class cookieOperation
{
	public cookieOperation()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static bool setOneCookie(string cookie_name,string cookie_value0)
    {
        string cookie_value = HttpContext.Current.Server.UrlEncode(cookie_value0);
        bool returnBool = false;
        try
        {
            HttpCookie loginCookie = new HttpCookie("login");
            if (cookieIsOn("login"))
            {
                loginCookie = HttpContext.Current.Request.Cookies["login"];
            }
            if (getOneCookie(cookie_name) !="")
            {
                loginCookie.Values.Remove(cookie_name);
            }
            loginCookie.Values.Add(cookie_name, cookie_value);
            loginCookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Current.Response.AppendCookie(loginCookie);
            if (cookieIsOn(cookie_name))
            {
                returnBool =true;
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("设置cookie[" + cookie_name + "]时发生错误", exp.ToString());
        }
        return returnBool;
    }
    public static string getOneCookie(string cookie_name)
    {
        string cookieValue="";
        try
        {
            if (cookieIsOn("login"))
            {
                HttpCookie getCookieValue = HttpContext.Current.Request.Cookies["login"];
                if (getCookieValue.Values[cookie_name] != null)
                {
                    cookieValue = getCookieValue.Values[cookie_name].ToString();
                }
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("获取cookie[" + cookie_name + "]时发生错误", exp.ToString());
        }
        return  HttpContext.Current.Server.UrlDecode(cookieValue);
    }
    public static bool delOneCookie(string cookie_name)
    {
        bool returnBool = false;
        try
        {
            if (cookieIsOn(cookie_name))
            {
                HttpCookie loginCookie = new HttpCookie("login");
                if (cookieIsOn("login"))
                {
                    loginCookie = HttpContext.Current.Request.Cookies["login"];
                }
                loginCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.AppendCookie(loginCookie);
            }
            if (!cookieIsOn("login"))
            {
                returnBool = true;
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("删除cookie[" + cookie_name + "]时发生错误", exp.ToString());
        }
        return returnBool;
    }
    public static bool cookieIsOn(string cookie_name)
    {
        bool returnBool = false;
        try
        {
            if (HttpContext.Current.Request.Cookies["login"] != null)
            {
                returnBool = true;
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("检查cookie[" + cookie_name + "]是否存在是时发生错误", exp.ToString());
        }
        return returnBool;
    }
}
