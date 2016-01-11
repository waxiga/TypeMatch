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

public partial class admin_systemHistor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (adminOperation.checkIfAdmin())
            {
                if (Request.QueryString["name"] != null)
                {
                    countOperation.setOneCountToApplication(Request.QueryString["name"].ToString(), 0);
                    bindRepeater();
                }
                else
                {
                    bindRepeater();
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起,你未登陆.请先登陆!');window.location='../login.html';</script>");
            }
        }
    }
    public void bindRepeater()
    {
        countOperation.updateAllCountToDb();
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand("select * from [count]", con);
            con.Open();
            OleDbDataReader odr = cmd.ExecuteReader();
            this.Repeater1.DataSource = odr;
            this.Repeater1.DataBind();
            odr.Close();
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("获取[count]表的全体数据时出错", exp.ToString());
            string alertTxt = "<script language='javascript'>alert('加载数据失败，请刷新本页！');</script>";
            Response.Write(alertTxt);
        }
    }
}
