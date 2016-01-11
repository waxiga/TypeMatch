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

public partial class admin_aboutServer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!adminOperation.checkIfAdmin())
        {
            string repsonStr = "<script language='javascript'>alert('对不起,你尚未登陆,或者你不是管理员,不能执行该操作!');window.location='../login.html';</script>";
            Response.Write(repsonStr);
        }
        if (!IsPostBack)
        {
            try
            {
                OleDbConnection con = DB.createcon();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [systemRecord]", con);
                con.Open();
                OleDbDataReader odr = cmd.ExecuteReader();
                this.Repeater1.DataSource = odr;
                this.Repeater1.DataBind();
                odr.Close();
                con.Close();//5+1+a+s+p+x
            }
            catch (Exception exp)
            {
                saveErrorMessage.writeFile("取systemRecord表的全部记录时出错", exp.ToString());
            }
        }
    }
}
