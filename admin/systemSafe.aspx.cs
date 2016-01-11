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

public partial class admin_systemSafe : System.Web.UI.Page
{
    #region 必需的设计器变量
    protected string MemberName;
    protected string ServerOS, CpuSum, CpuType, ServerSoft, MachineName, ServerName, ServerPath, ServerNet, ServerArea, ServerTimeOut, ServerStart;
    protected string PrStart, AspNetN, AspNetCpu, ServerSessions, ServerApp, ServerCache, ServerAppN, ServerFso, RunTime;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!adminOperation.checkIfAdmin())
        {
            Response.Redirect("../login.html");
        }
        if (Session["realName"] != null)
        {
            if (Convert.ToString(Session["userType"]) != "3")
            { 
                this.ifSuperAdmin.Visible = false;
                this.B1.InnerText = "极高的管理权限。";
            }
            MemberName = Session["realName"].ToString();
        }
        DataLoad();
    }
    #region 获取服务器及用户信息
    private void DataLoad()
    {
        DateTime sTime = DateTime.Now;
        ServerOS = Environment.OSVersion.ToString();
        CpuSum = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
        CpuType = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
        ServerSoft = Request.ServerVariables["SERVER_SOFTWARE"];
        MachineName = Server.MachineName;
        ServerName = Request.ServerVariables["SERVER_NAME"];
        ServerPath = Request.ServerVariables["APPL_PHYSICAL_PATH"];
        ServerNet = ".NET CLR " + Environment.Version.ToString();
        //获取时区
        //ServerArea = (DateTime.Now - DateTime.UtcNow).TotalHours > 0 ? "+" + (DateTime.Now - DateTime.UtcNow).TotalHours.ToString() : (DateTime.Now - DateTime.UtcNow).TotalHours.ToString();
        DateTime lTime = DateTime.Now;
        int i = 0;
        while (i < 100000000)
        { i++; }
        DateTime nTime = DateTime.Now;
        //改为测试ＣＰＵ速度
        ServerArea = ((nTime - lTime).TotalMilliseconds).ToString() + "毫秒";
        ServerTimeOut = Server.ScriptTimeout.ToString();
        ServerStart = ((Double)System.Environment.TickCount / 3600000).ToString("N2");
        PrStart = GetPrStart();
        AspNetN = GetAspNetN();
        AspNetCpu = GetAspNetCpu();
        ServerSessions = Session.Contents.Count.ToString();
        ServerApp = Application.Contents.Count.ToString();
        ServerCache = Cache.Count.ToString();
        ServerAppN = GetServerAppN();
        ServerFso = Check("Scripting.FileSystemObject");
        ServerTimeOut = Server.ScriptTimeout.ToString() + "毫秒";

        #region WebControls Config
        // ViewState Config
        this.EnableViewState = false;
        #endregion

        //执行时间
        DateTime eTime = DateTime.Now;
        RunTime = ((eTime - sTime).TotalMilliseconds).ToString();
    }
    #endregion

    #region 获取服务器系统信息
    private string GetServerAppN()
    {
        string temp;
        try
        {
            temp = ((Double)GC.GetTotalMemory(false) / 1048576).ToString("N2") + "M";
        }
        catch
        {
            temp = "未知";
        }
        return temp;
    }

    private string GetAspNetN()
    {
        string temp;
        try
        {
            temp = ((Double)System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / 1048576).ToString("N2") + "M";
        }
        catch
        {
            temp = "未知";
        }
        return temp;
    }

    private string GetAspNetCpu()
    {
        string temp;
        try
        {
            temp = ((TimeSpan)System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime).TotalSeconds.ToString("N0");
        }
        catch
        {
            temp = "未知";
        }
        return temp;
    }

    private string GetPrStart()
    {
        string temp;
        try
        {
            temp = System.Diagnostics.Process.GetCurrentProcess().StartTime.ToString();
        }
        catch
        {
            temp = "未知";
        }
        return temp;
    }

    private string Check(string obj)
    {
        try
        {
            object claobj = Server.CreateObject(obj);
            return "支持";
        }
        catch
        {
            return "不支持";
        }
    }
    #endregion
}
