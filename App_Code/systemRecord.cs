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
/// systemRecord 的摘要说明
/// </summary>
public class systemRecord
{

	public systemRecord()
    {    
	}
    public static bool insertOneRecord(string eventContent)
    {
        bool returnValue = true;
        try
        {
            string eventTime = DateTime.Now.ToString();
            OleDbConnection con = DB.createcon();
            string cmdStr = "insert into [systemRecord]([recordContent],[recordTime]) values('" + eventContent + "','" + eventTime + "')";
            OleDbCommand cmd = new OleDbCommand(cmdStr, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("向systemRecord表插入一条记录时出错", exp.ToString());
            returnValue = false;
        }
        return returnValue;
    }
    public static DataTable getAllRecordFromDB()
    {
        DataTable dt = new DataTable();
        try
        {
            OleDbConnection con = DB.createcon();
            string cmdStr = "select * from [systemRecord]";
            OleDbCommand cmd = new OleDbCommand(cmdStr, con);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "returnTable");
            if (con.State.ToString() == "Open")
            {
                con.Close();
            }
            dt=ds.Tables[0];
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("取systemRecord表的全部记录时出错", exp.ToString());
        }
        return dt;
    }
}
