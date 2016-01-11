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

public partial class admin_databaseSafe : System.Web.UI.Page
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
            DB.compareSetTimeOut();
            OleDbConnection strConn =DB.createcon();
            string dbName = strConn.ConnectionString.Substring(strConn.ConnectionString.LastIndexOf("\\")+1);
            this.TextBox3.Text = dbName;
            this.Label1.Text = FileOper.readOneFile("App_Data\\", "backupDB.txt");
            this.Label2.Text = FileOper.readOneFile("App_Data\\", "restoreDB.txt");
            this.Label3.Text = FileOper.readOneFile("App_Data\\", "compactDB.txt");
            this.Label4.Text = FileOper.readOneFile("App_Data\\", "delBackupDB.txt");
            //取定时时间
            int setTimeBackup = 0;
            setTimeBackup = countOperation.getOneCountFromApplication("setTimeBackupDB");
            this.TextBox5.Text = setTimeBackup.ToString();
            int setTimeRestore = 0;
            setTimeRestore = countOperation.getOneCountFromApplication("setTimeRestoreDB");
            this.TextBox6.Text = setTimeRestore.ToString();
            int setTimeCompact = 0;
            setTimeCompact = countOperation.getOneCountFromApplication("setTimeCompactDB");
            this.TextBox7.Text = setTimeCompact.ToString();
            if (setTimeBackup == 1000)
            {
                this.Button11.Visible = true;
                this.Button12.Visible = false;
                this.Label5.Text = "未设置！";
            }
            else
            {
                this.Button11.Visible = false;
                this.Button12.Visible = true;
                this.Label5.Text = "已设置！";
            }
            if (setTimeRestore ==1000)
            {
                this.Button21.Visible = true;
                this.Button22.Visible = false;
                this.Label6.Text = "未设置！";
            }
            else
            {
                this.Button21.Visible = false;
                this.Button22.Visible = true;
                this.Label6.Text = "已设置！";
            }
            if (setTimeCompact == 1000)
            {
                this.Button31.Visible = true;
                this.Button32.Visible = false;
                this.Label7.Text = "未设置！";
            }
            else
            {
                this.Button31.Visible = false;
                this.Button32.Visible = true;
                this.Label7.Text = "已设置！";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //备份数据库
        DB.backupDB(this.TextBox1.Text.ToString());
        this.Label1.Text = FileOper.readOneFile("App_Data\\", "backupDB.txt");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //还原数据库
        DB.restoreDB(this.TextBox2.Text.ToString());
        this.Label2.Text = FileOper.readOneFile("App_Data\\", "restoreDB.txt");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //压缩数据库
        DB.compactDB();
        this.Label3.Text = FileOper.readOneFile("App_Data\\", "compactDB.txt");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //删除备份数据库
        string databaseName=this.TextBox4.Text;
        if (databaseName != "#typematch.mdb" && databaseName != "#typematch.mdb" && databaseName != "")
        {
            DB.delBackupDB(databaseName);
        }
        else
        {
            this.Label4.Text = DateTime.Now.ToString() + "删除失败!原因：非备份数据库不能删除";
        }
        this.Label4.Text = FileOper.readOneFile("App_Data\\", "delBackupDB.txt");
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        //设置定时备份数据库
        int setTimeBackupInt = Convert.ToInt32(this.TextBox5.Text);
        DB.setTimeOperDB("setTimeBackupDB", setTimeBackupInt);
        Response.Redirect("databaseSafe.aspx");
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        //取消定时备份数据库
        int setTimeBackupInt =1000;
        DB.setTimeOperDB("setTimeBackupDB", setTimeBackupInt);
        Response.Redirect("databaseSafe.aspx");
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        //设置定时还原数据库
        int setTimeBackupInt = Convert.ToInt32(this.TextBox6.Text);
        DB.setTimeOperDB("setTimeRestoreDB", setTimeBackupInt);
        Response.Redirect("databaseSafe.aspx");
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        //取消定时还原数据库
        int setTimeBackupInt =1000;
        DB.setTimeOperDB("setTimeRestoreDB", setTimeBackupInt);
        Response.Redirect("databaseSafe.aspx");
    }
    protected void Button31_Click(object sender, EventArgs e)
    {
        //设置定时压缩数据库
        int setTimeBackupInt = Convert.ToInt32(this.TextBox7.Text);
        DB.setTimeOperDB("setTimeCompactDB", setTimeBackupInt);
        Response.Redirect("databaseSafe.aspx");
    }
    protected void Button32_Click(object sender, EventArgs e)
    {
        //取消定时压缩数据库
        int setTimeBackupInt =1000;
        DB.setTimeOperDB("setTimeCompactDB", setTimeBackupInt);
        Response.Redirect("databaseSafe.aspx");
    }
}
