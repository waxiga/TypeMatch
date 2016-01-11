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
/// DB 的摘要说明
/// </summary>
public class DB
{
	public DB()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static OleDbConnection createcon()
    {//创建数据库连接
        string ServerPath =HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
        string constr = ConfigurationManager.ConnectionStrings["accConStr"].ConnectionString.ToString() + ServerPath + ConfigurationManager.AppSettings["databaseName"].ToString();
        OleDbConnection con = new OleDbConnection(constr);
        countOperation.countAddOne("dbConnctionCount");
        return con;
    }
    public static bool compactDB()
    {//压缩数据库
        bool retuValue = true;
        string resultTxt = DateTime.Now.ToString() + "：<br />压缩数据库失败,<br />请确保没有其它用户连接数据库!";
        OleDbConnection strConn =createcon();
        object[] oParams;
        object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));
        string tempDb = "CompactDatabase-temp-" + DateTime.Now.ToShortDateString() + ".mdb";
        string tempPath = strConn.ConnectionString.Substring(strConn.ConnectionString.IndexOf("Data Source=") + 12, strConn.ConnectionString.LastIndexOf("\\") - strConn.ConnectionString.IndexOf("Data Source=") - 12);
        string dbName = strConn.ConnectionString.Substring(strConn.ConnectionString.LastIndexOf("\\"));
        oParams = new object[] { strConn.ConnectionString, strConn.ConnectionString.Substring(0, strConn.ConnectionString.LastIndexOf('\\')) + "\\" + tempDb + ";Jet OLEDB:Engine Type=5" };
        try
        {
            objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);
            if (System.IO.File.Exists(tempPath + "\\" + tempDb))
                System.IO.File.Copy(tempPath + "\\" + tempDb, tempPath + "\\" + dbName, true);
        }
        catch (Exception exp)
        {
            resultTxt = DateTime.Now.ToString() + "：<br />压缩数据库时出错，<br />原因：" + exp.Message.ToString();
            retuValue=false;
        }
        System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
        objJRO = null;
        if (System.IO.File.Exists(tempPath + "\\" + tempDb))
            System.IO.File.Delete(tempPath + "\\" + tempDb);
        if (retuValue)
        {
            resultTxt = DateTime.Now.ToString() + "：<br />压缩数据库成功！<br />被压缩的为系统数据库.";
        }
        systemRecord.insertOneRecord("数据库被压缩。");
        FileOper.writeOneFile("App_Data\\", "compactDB.txt", resultTxt);
        return retuValue;
    }
    public static bool backupDB(string backupName)
    {//备份数据库
        bool retuValue = true;
        string resultTxt = DateTime.Now.ToString() + "：<br />备份数据库成功，<br />备份的数据库为：" + backupName;
        OleDbConnection strConn = createcon();
        string tempPath = strConn.ConnectionString.Substring(strConn.ConnectionString.IndexOf("Data Source=") + 12, strConn.ConnectionString.LastIndexOf("\\") - strConn.ConnectionString.IndexOf("Data Source=") - 12);
        string dbName = strConn.ConnectionString.Substring(strConn.ConnectionString.LastIndexOf("\\"));
        try
        {
            System.IO.File.Copy(tempPath + "\\" + dbName, tempPath + "\\" + backupName, true);
        }
        catch (Exception exp)
        {
            resultTxt = DateTime.Now.ToString() + "；<br />备份数据库时出错，<br />原因：" + exp.Message.ToString();
            retuValue = false;
        }
        systemRecord.insertOneRecord("数据库被备份。");
        FileOper.writeOneFile("App_Data\\", "backupDB.txt", resultTxt);
        return retuValue;
    }
    public static bool restoreDB(string databaseName)
    {//还原数据库
        bool retuValue = true;
        string resultTxt = DateTime.Now.ToString() + "：<br />还原数据库成功，<br />还原的数据库为：" + databaseName;
        OleDbConnection strConn = createcon();
        string tempPath = strConn.ConnectionString.Substring(strConn.ConnectionString.IndexOf("Data Source=") + 12, strConn.ConnectionString.LastIndexOf("\\") - strConn.ConnectionString.IndexOf("Data Source=") - 12);
        string dbName = strConn.ConnectionString.Substring(strConn.ConnectionString.LastIndexOf("\\"));
        if (System.IO.File.Exists(tempPath + "\\" + databaseName))
        {
            try
            {
                System.IO.File.Copy(tempPath + "\\" + databaseName, tempPath + "\\" + dbName, true);
            }
            catch (Exception exp)
            {
                resultTxt = DateTime.Now.ToString() + "；<br />还原数据库时出错，<br />原因：" + exp.Message.ToString();
                retuValue = false;
            }
        }
        else
        {
            resultTxt = DateTime.Now.ToString() + "；<br />还原数据库时出错，原因，<br />相应的数据库没有找到,本错误信息来自页面： App_Code/DB.cs";
            retuValue = false;
        }
        systemRecord.insertOneRecord("数据库被还原。");
        FileOper.writeOneFile("App_Data\\", "restoreDB.txt", resultTxt);
        return retuValue;

    }
    public static bool delBackupDB(string databaseName)
    {//删除备份数据库
        bool retuValue = true;
        string resultTxt = DateTime.Now.ToString() + "：<br />删除数据库成功，<br />被删除的数据库为：" + databaseName;
        OleDbConnection strConn = createcon();
        string tempPath = strConn.ConnectionString.Substring(strConn.ConnectionString.IndexOf("Data Source=") + 12, strConn.ConnectionString.LastIndexOf("\\") - strConn.ConnectionString.IndexOf("Data Source=") - 12);
        if (System.IO.File.Exists(tempPath + "\\" + databaseName))
        {
            try
            {
                System.IO.File.Delete(tempPath + "\\" + databaseName);
            }
            catch (Exception exp)
            {
                resultTxt = DateTime.Now.ToString() + "<br />删除数据库时出错，原因：<br />" + exp.ToString();
                retuValue = false;
            }
        }
        else
        {
            resultTxt = DateTime.Now.ToString() + "：<br />删除数据库时出错，原因:<br />相应的数据库没有找到!";
            retuValue = false;
        }
        systemRecord.insertOneRecord("备份数据库被删除。");
        FileOper.writeOneFile("App_Data\\", "delBackupDB.txt", resultTxt);
        return retuValue;
    }
    public static bool setTimeOperDB(string operType,int dayCount)
    {//设置定时备份/还原/压缩数据库
        bool retuValue = true;
        if (dayCount > 0)
        {
            string theNextTime = DateTime.Now.AddDays(dayCount).ToString();
            try
            {
                countOperation.setOneCountToApplication(operType, dayCount);
                if (HttpContext.Current.Application[operType + "_about"] != null)
                {
                    HttpContext.Current.Application[operType + "_about"] = theNextTime;
                }
                countOperation.updateAllCountToDb();
                OleDbConnection con = createcon();
                string cmdStr = "update [count] set [countNum]=" + dayCount + ",[aboutThisCount]='" + theNextTime + "' where countName='" + operType + "'";
                OleDbCommand cmd = new OleDbCommand(cmdStr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                countOperation.getAllCountToApplication();
            }
            catch (Exception exp)
            {
                saveErrorMessage.writeFile("设置定时备份数据库时出错，原因：", exp.Message.ToString());
                retuValue = false;
            }
        }
        else
        {
            retuValue = false;
        }
        return retuValue;
    }
    public static void compareSetTimeOut()
    {
        try
        {
            //备份
            string operName="setTimeBackupDB";
            string operType = operName+"_about";
            DateTime nowTime = DateTime.Now;
            DateTime timeoutTime = DateTime.Now;
            int count = Convert.ToInt32(countOperation.getOneCountFromApplication(operName));
            if (count > 0)
            {
                if (HttpContext.Current.Application[operType] != null)
                {
                    timeoutTime = Convert.ToDateTime(HttpContext.Current.Application[operType]);
                }
                if (DateTime.Compare(timeoutTime, nowTime) < 1)
                {
                    //开始执行“备份，还原，压缩操作”
                    backupDB("backup.cs");
                    setTimeOperDB(operName, count);

                }
            }
            //还原
            operName = "setTimeRestoreDB";
            operType = operName + "_about";
            count = Convert.ToInt32(countOperation.getOneCountFromApplication(operName));
            if (count > 0)
            {
                if (HttpContext.Current.Application[operType] != null)
                {
                    timeoutTime = Convert.ToDateTime(HttpContext.Current.Application[operType]);
                }
                if (DateTime.Compare(timeoutTime, nowTime) < 1)
                {
                    //开始执行“备份，还原，压缩操作”
                    restoreDB("backup.cs");
                    setTimeOperDB(operName, count);
                }
            }
            //压缩
            operName = "setTimeCompactDB";
            operType = operName + "_about";
            count = Convert.ToInt32(countOperation.getOneCountFromApplication(operName));
            if (count > 0)
            {
                if (HttpContext.Current.Application[operType] != null)
                {
                    timeoutTime = Convert.ToDateTime(HttpContext.Current.Application[operType]);
                }
                if (DateTime.Compare(timeoutTime, nowTime) < 1)
                {
                    //开始执行“备份，还原，压缩操作”
                    compactDB();
                    setTimeOperDB(operName, count);
                }
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("检查是否到时间执行定时任务（定时备份，定时还原，定时压缩）时出错，原因：", exp.Message.ToString());
        }
    }
}
