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
using System.IO;
using System.Text;

/// <summary>
/// saveErrorMessage 的摘要说明
/// </summary>
public class saveErrorMessage
{
	public saveErrorMessage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static bool writeFile(string events,string exceptionStr)
    {
        string ip = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString();
        string ServerPath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
        string errorMessage="事件源:"+ip+"\n事件缘由:"+events+"\n事件异常信息:"+exceptionStr+"\n事件发生时间:"+DateTime.Now.ToString();
        StreamWriter sw = null;
        string path = ServerPath.ToString() + "error\\";
        Encoding encod = Encoding.GetEncoding("gb2312");//设置编码
        string y= DateTime.Now.ToString("yyyy");
        string M = DateTime.Now.ToString("MM");
        string d = DateTime.Now.ToString("dd");
        string h = DateTime.Now.ToString("HH");
        string m = DateTime.Now.ToString("mm");
        string s = DateTime.Now.ToString("ss");
        string fullFileName =path+ y+"年"+M+"月"+d+"日"+h+"时"+m+"分"+s+"秒"+ ".txt";
        try  //写文件
        {
            sw = new StreamWriter(fullFileName, false, encod);
            sw.Write(errorMessage);
            sw.Flush();
            return true;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
            HttpContext.Current.Response.End();
            return false;
        }
        finally
        {
            sw.Close();
        }
    }
}
