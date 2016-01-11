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
/// studentOperation 的摘要说明
/// </summary>
public class studentOperation
{
	public studentOperation()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //查询学生是否已经登陆
    public static bool checkIfLogin()
    {
        bool returnBool =true;
        if (HttpContext.Current.Session["userName"] == null)
        {
            returnBool = loginFromCookie.loginFromCookieOnly();
        }
        return returnBool;
    }
    //查询学生是否有新信息
    public static int haveNewMessageCount(string username)
    {
        int returnCount = 0;
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select count(*) from [message] where ([toUerID]='" + username + "' or  [sendUerName]='" + username + "') and [ifNew]=true";
            cmd.Connection = con;
            con.Open();
            returnCount =Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("删除一条打字结果时发生错误.", exp.ToString());
        }
        return returnCount;
    }
    //查询注册的用户名是否可用
    public static int checkUsernameIfEnable(string username)
    {
        OleDbConnection con = DB.createcon();
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText="select count(*) from [student] where [studentUsername]=@username";
        cmd.Parameters.AddWithValue("@username",username);
        cmd.Connection = con;
        con.Open();
        int recordccount = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        return recordccount;
    }
    //查询学生的打字排名
    public static int getPaiming(string username)
    {
        int returnInt = 1;
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select count(*) from [typeResult] where ([typeType]=2 or [typeType]=3) and [typeSpeed]>(select top 1 [typeSpeed] from [typeResult] where ([typeType]=2 or [typeType]=3) and [typeUser]=@username order by [typeSpeed] desc)";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Connection = con;
            con.Open();
            returnInt = Convert.ToInt32(cmd.ExecuteScalar())+1;
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("删除一条打字结果时发生错误.", exp.ToString());
        }
        return returnInt;
    }
    //查询一个学生的所有打字结果
    public static DataTable selectOneStudentResult(string username)
    {
        OleDbConnection con = DB.createcon();
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "select * from [typeResult] where [typeUser]=@username order by typeEndTime desc";
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Connection = con;
        con.Open();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        oda.SelectCommand = cmd;
        DataSet ds = new DataSet();
        oda.Fill(ds,"mydatatable");
        con.Close();
        return ds.Tables["mydatatable"];
    }
    //删除一条学生的打字结果
    public static bool delOneTypeResult(string typeID)
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from [typeResult] where [typeID]=@id and [typeType]<3";
            cmd.Parameters.AddWithValue("@id", typeID);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception exp)
        {
            if (saveErrorMessage.writeFile("删除一条打字结果时发生错误.", exp.ToString()))
            {
                HttpContext.Current.Response.Write("删除打字结果时发生异常,异常信息已记录,如果你是管理员,请打开Error文件夹查看.");
            }
            else
            {
                HttpContext.Current.Response.Write("删除打字结果时发生异常,并且异常信息无法记录,请联系管理员.");
            }
            return false;
        }
    }
    //删除一个学生的所有打字结果
    public static bool delAllTypeResult()
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from [typeResult] where [typeUser]='" + HttpContext.Current.Session["userName"].ToString() + "' and [typeType]<3";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception exp)
        {
            if (saveErrorMessage.writeFile("删除全部打字结果时发生错误.", exp.ToString()))
            {
                HttpContext.Current.Response.Write("删除打字结果时发生异常,异常信息已记录,如果你是管理员,请打开Error文件夹查看.");
            }
            else
            {
                HttpContext.Current.Response.Write("删除打字结果时发生异常,并且异常信息无法记录,请联系管理员.");
            }
            return false;
        }
    }
    //删除学生的一条信息
    public static bool delOneMessage(string messageID)
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from [message] where [messageID]=@id";
            cmd.Parameters.AddWithValue("@id", messageID);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception exp)
        {
            if (saveErrorMessage.writeFile("删除一条信息时发生错误.", exp.ToString()))
            {
                HttpContext.Current.Response.Write("删除信息时发生异常,异常信息已记录,如果你是管理员,请打开Error文件夹查看.");
            }
            else
            {
                HttpContext.Current.Response.Write("删除信息时发生异常,并且异常信息无法记录,请联系管理员.");
            }
            return false;
        }
    }
    //删除一个学生的所有信息
    public static bool delAllMessage()
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "delete from [message] where [toUerID]=@id";
            cmd.Parameters.AddWithValue("@id", HttpContext.Current.Session["userName"].ToString());
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception exp)
        {
            if (saveErrorMessage.writeFile("删除全部信息时发生错误.", exp.ToString()))
            {
                HttpContext.Current.Response.Write("删除信息时发生异常,异常信息已记录,如果你是管理员,请打开Error文件夹查看.");
            }
            else
            {
                HttpContext.Current.Response.Write("删除信息时发生异常,并且异常信息无法记录,请联系管理员.");
            }
            return false;
        }
    }
    //查询学生的所有站内信列表
    public static DataTable selectMyMessage(string username)
    {
        OleDbConnection con = DB.createcon();
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "select * from [message] where [toUerID]=@username or [sendUerName]=@username";
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Connection = con;
        con.Open();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        oda.SelectCommand = cmd;
        DataSet ds = new DataSet();
        oda.Fill(ds, "mydatatable");
        cmd.CommandText = "update [message] set ifNew=false where [toUerID]=@username or [sendUerName]=@username";
        cmd.Parameters.AddWithValue("@username", username);
        cmd.ExecuteNonQuery();
        con.Close();
        return ds.Tables["mydatatable"];
    }
    //添加一条信息到数据库
    public static bool addOneMessage(string senderUid, string stduentName, string messagebody, string toUer, string messgaeType)
    {
        try
        {
            if (stduentName == "")
            {
                stduentName = "匿名用户";
            }
            string ip = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"].ToString();
            string sendtime = DateTime.Now.ToString();
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into [message](toUerID,sendStudentName,sendUerName,messageType,messageBody,sendTime,sendIP) values(@touid,@sendername,@senderuid,@smessagetype,@msmbody,@sendtime,@senderip)";
            cmd.Parameters.AddWithValue("@touid", toUer);
            cmd.Parameters.AddWithValue("@sendername", stduentName);
            cmd.Parameters.AddWithValue("@senderuid", senderUid);
            cmd.Parameters.AddWithValue("@smessagetype", messgaeType);
            cmd.Parameters.AddWithValue("@msmbody", messagebody);
            cmd.Parameters.AddWithValue("@sendtime", sendtime);
            cmd.Parameters.AddWithValue("@senderip", ip);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception exp)
        {
            if (saveErrorMessage.writeFile("发送站内信时失败.",exp.ToString()))
            {
                HttpContext.Current.Response.Write("发送信息过程中发生了异常,异常信息已记录,如果你是管理员,请打开Error文件夹查看.");
            }
            else
            {
                HttpContext.Current.Response.Write("发送信息过程中发生了异常,异常信息无法记录,请联系管理员.");
            }
            return false;
        }
    }
}
