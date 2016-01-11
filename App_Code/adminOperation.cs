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
/// adminOperation 的摘要说明
/// </summary>
public class adminOperation
{
	public adminOperation()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static bool checkIfAdmin()
    {
        if (HttpContext.Current.Session["userName"] != null && HttpContext.Current.Session["realName"] != null && HttpContext.Current.Session["userType"] != null)
        {
            if (Convert.ToInt32(HttpContext.Current.Session["userType"]) > 1)
            {
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
    public static DataTable getSomeTxt(string key)
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from [someTxt] where [key]=@username";
            cmd.Parameters.AddWithValue("@username", key);
            cmd.Connection = con;
            con.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            oda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            oda.Fill(ds, "mydatatable");
            con.Close();
            return ds.Tables["mydatatable"];
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("查询[someTxt]表的1条数据时发生错误.", exp.ToString());
            DataTable mytable = new DataTable();
            return mytable;
        }
    }
    public static bool setSomeTxt(string key,string value)
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "update [someTxt] set [value]='"+value+"' where [key]='"+key+"'";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("修改[someTxt]表的1条数据时发生错误.", exp.ToString());
            return false;
        }
    }
}
