<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        systemRecord.insertOneRecord("系统启动");
        countOperation.foundAdminCountToDb();
        countOperation.getAllCountToApplication();
        countOperation.countAddOne("systemRestartCount");
        countOperation.setOneCountToApplication("onlineCount", 0); 
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码
        saveErrorMessage.writeFile("应用程序关闭", "来自GLOBAL.ASAX");
        countOperation.updateAllCountToDb();
        systemRecord.insertOneRecord("系统关闭");
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //// 在出现未处理的错误时运行的代码
        //Response.Redirect("systemError.htm");
        countOperation.countAddOne("systemErrorCount");
        systemRecord.insertOneRecord("系统出错");
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码
        countOperation.countAddOne("onlineCount");
        if (countOperation.getOneCountFromApplication("maxOnlineCount") < countOperation.getOneCountFromApplication("onlineCount"))
        {
            countOperation.countAddOne("maxOnlineCount");
        }
        countOperation.countAddOne("allCount");
        DB.compareSetTimeOut();
    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
        countOperation.countSubOne("onlineCount");
        countOperation.updateAllCountToDb();
        DB.compareSetTimeOut();
    }
</script>
