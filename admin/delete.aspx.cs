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
using System.Data.OleDb;

public partial class admin_delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!adminOperation.checkIfAdmin())
            {
                string repsonStr = "<script language='javascript'>alert('对不起,你尚未登陆,或者你不是管理员,不能执行该操作!');window.location='../login.html';</script>";
                Response.Write(repsonStr);
            }
            string alertTxt = "<script language='javascript'>alert('删除数据失败,请重试!');history.go(-1);</script>";
            if (adminOperation.checkIfAdmin())
            {
                if (Request.QueryString["tablename"] != null)
                {
                    string tableName = Request.QueryString["tablename"].ToString();
                    string cmdtxt = "";
                    if (Request.QueryString["count"] != null)
                    {
                        cmdtxt = "delete from [" + tableName + "]";
                    }
                    if (Request.QueryString["key"] != null && Request.QueryString["value"] != null)
                    {
                        string rowKey = Request.QueryString["key"].ToString();
                        string rowValue = Request.QueryString["value"].ToString();
                        cmdtxt = "delete from [" + tableName + "] where [" + rowKey + "]=" + rowValue;
                    }
                    try
                    {
                        OleDbConnection con = DB.createcon();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandText = cmdtxt;
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        alertTxt = "<script language='javascript'>alert('删除数据成功!');history.go(-1);</script>";
                    }
                    catch
                    {
                        try
                        {
                            if (Request.QueryString["key"] != null && Request.QueryString["value"] != null)
                            {
                                string rowKey = Request.QueryString["key"].ToString();
                                string rowValue = Request.QueryString["value"].ToString();
                                cmdtxt = "delete from [" + tableName + "] where [" + rowKey + "]='" + rowValue+"'";
                                OleDbConnection con2 = DB.createcon();
                                OleDbCommand cmd2 = new OleDbCommand();
                                cmd2.CommandText = cmdtxt;
                                cmd2.Connection = con2;
                                con2.Open();
                                cmd2.ExecuteNonQuery();
                                con2.Close();
                                alertTxt = "<script language='javascript'>alert('删除数据成功!');history.go(-1);</script>";
                            }
                        }
                        catch (Exception exp)
                        {
                            saveErrorMessage.writeFile("从" + tableName + "表删除数据时发生错误.", exp.ToString());
                            alertTxt = "<script language='javascript'>alert('删除数据失败,请重试!');history.go(-1);</script>";
                        }
                    }
                }
            }
            else
            {
                alertTxt = "<script language='javascript'>alert('对不起,你尚未登陆或登陆超时,不能执行操作!');window.location='../login.html';</script>";
            }
            Response.Write(alertTxt);
        }
    }
}
