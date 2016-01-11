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

public partial class admin_sqlTran : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!adminOperation.checkIfAdmin())
        {
            string repsonStr = "<script language='javascript'>alert('对不起,你尚未登陆,或者你不是管理员,不能执行该操作!');window.location='../login.html';</script>";
            Response.Write(repsonStr);
        }
        if (!IsPostBack)
            this.TextBox3.Text = ConfigurationManager.AppSettings["databaseName"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {//查询
        string labTxt = "查询成功！";
        OleDbConnection con = new OleDbConnection();
        if (this.TextBox2.Text !="")
        {
            string databasePath = ConfigurationManager.AppSettings["databaseName"].ToString();
            if (this.CheckBox1.Checked == true && this.TextBox3.Text.ToString() != "")
            {
                databasePath = this.TextBox3.Text.ToString();
            }
            try
            {
                con = createOledbConn(databasePath);
                string sqlStr = this.TextBox2.Text.ToString();
                OleDbCommand cmd = new OleDbCommand(sqlStr, con);
                con.Open();
                OleDbDataReader odr = cmd.ExecuteReader();
                this.GridView1.DataSource = odr;
                this.GridView1.DataBind();
                odr.Close();
                con.Close();
                this.TextBox1.Text += "\n" + this.TextBox2.Text;
            }
            catch (Exception exp)
            {
                labTxt = "<b style='color:red;'>查询失败：" + exp.Message.ToString() + "<b>";
            }
            finally
            {
                if (con.State.ToString() == "Open")
                {
                    con.Close();
                }
            }

        }
        else
        {
            labTxt = "查询语句不能为空";
        }
        labTxt += "；当前连接状态：" + con.State.ToString();
        this.Label1.Text = labTxt;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {//执行
        string labTxt = "执行成功！";
        OleDbConnection con = new OleDbConnection();
        if (this.TextBox2.Text != "")
        {
            string databasePath = ConfigurationManager.AppSettings["databaseName"].ToString();
            if (this.CheckBox1.Checked == true && this.TextBox3.Text.ToString() != "")
            {
                databasePath = this.TextBox3.Text.ToString();
            }
            try
            {
                con = createOledbConn(databasePath);
                string sqlStr = this.TextBox2.Text.ToString();
                OleDbCommand cmd = new OleDbCommand(sqlStr, con);
                con.Open();
                int updateRecodeCount = cmd.ExecuteNonQuery();
                con.Close();
                this.TextBox1.Text += "\n" + this.TextBox2.Text;
                labTxt += "；受影响行数：" + updateRecodeCount.ToString();
            }
            catch (Exception exp)
            {
                labTxt = "<b style='color:red;'>执行失败：" + exp.Message.ToString() + "<b>";
            }
            finally
            {
                if (con.State.ToString() == "Open")
                {
                    con.Close();
                }
            }

        }
        else
        {
            labTxt = "执行语句不能为空";
        }
        this.Label1.Text = labTxt;
    }
    public static OleDbConnection createOledbConn(string datebasePath)
    {//创建数据库连接
        OleDbConnection con = new OleDbConnection();
        try
        {
            string ServerPath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
            string constr = ConfigurationManager.ConnectionStrings["accConStr"].ConnectionString.ToString() + ServerPath + datebasePath;
            con.ConnectionString = constr;
        }
        catch (Exception exp)
        {
            HttpContext.Current.Response.Write("操作有误：<br/>" + exp.Message.ToString());
        }
        return con;
    }
}
