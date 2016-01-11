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
/// countOperation 的摘要说明
/// </summary>
public class countOperation
{
	public countOperation()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static void getAllCountToApplication()
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from [count]";
            cmd.Connection = con;
            con.Open();
            OleDbDataReader odr = cmd.ExecuteReader();
            HttpContext.Current.Application.Lock();
            while (odr.Read())
            {
                string countname=odr["countName"].ToString();
                string countnum=odr["countNum"].ToString();
                string aboutThisCountKey = odr["countName"].ToString()+"_about";
                string aboutThisCountValue = odr["aboutThisCount"].ToString();
                HttpContext.Current.Application[countname] = countnum;
                HttpContext.Current.Application[aboutThisCountKey] = aboutThisCountValue;
            }
            HttpContext.Current.Application.UnLock();
            odr.Close();
            con.Close();
        }
        catch (Exception exp)
        {
           saveErrorMessage.writeFile("取count表的数据时发生错误.", exp.ToString());
        }
    }
    public static int getOneCountFromDb(string countName)
    {
        int returnValue = 0;
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select [countNum] from [count] where [countName]='" + countName + "'";
            cmd.Connection = con;
            con.Open();
            returnValue = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("从count表取" + countName + "的值时发生错误.", exp.ToString());
        }
        return returnValue;
    }
    public static int getOneCountFromApplication(string countName)
    {
        int returnValue = 0;
        try
        {
            returnValue = Convert.ToInt32(HttpContext.Current.Application[countName]);
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("从application取" + countName + "的值时发生错误.", exp.ToString());
        }
        return returnValue;
    }
    public static bool setOneCountToApplication(string countName,int countNum)
    {
        bool returnValue =false;
        try
        {
            HttpContext.Current.Application[countName]=countNum;
            returnValue = true;
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("设置application" + countName + "的值时发生错误.", exp.ToString());
        }
        return returnValue;
    }
    public static void updateAllCountToDb()
    {
        string appkey = "";
        int appvalue = 0;
        try
        {
            for (int i = 0; i < HttpContext.Current.Application.Count; i++)
            {
                appkey=HttpContext.Current.Application.Keys[i].ToString();
                try
                {
                    appvalue = Convert.ToInt32(HttpContext.Current.Application[i]);
                }
                catch(Exception)
                {
                    appvalue =-1;
                }
                if (appvalue > 0)
                {
                    updateOneCountToDb(appkey, appvalue);
                }
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("同时更新count表所有的数据时发生错误.", exp.ToString());
        }
    }
    public static void updateOneCountToDb(string countName,int countNum)
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "update [count] set [countNum]="+countNum+" where [countName]='"+countName+"'";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("更新count表的一条记录时发生错误.", exp.ToString());
        }
    }
    public static void countAddOne(string countName)
    {
        try
        {
            if (HttpContext.Current.Application[countName] != null)
            {
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application[countName] = Convert.ToInt32(HttpContext.Current.Application[countName]) + 1;
                HttpContext.Current.Application.UnLock();
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("使appliction的值"+ countName +"加1时发生错误.", exp.ToString());
        }
    }
    public static void countSubOne(string countName)
    {
        try
        {
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application[countName] = Convert.ToInt32(HttpContext.Current.Application[countName]) - 1;
            HttpContext.Current.Application.UnLock();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("使appliction的值"+ countName +"减1时发生错误.", exp.ToString());
        }
    }
    public static void foundAdminCountToDb()
    {
        int returnValue = 0;
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select count(*) from [student] where roleType=2 or roleType=3";
            cmd.Connection = con;
            con.Open();
            returnValue = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("从admin表取管理员总数时发生错误.", exp.ToString());
        }
        updateOneCountToDb("adminCount", returnValue);
    }
}
