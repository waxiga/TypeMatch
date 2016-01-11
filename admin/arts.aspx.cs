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

public partial class admin_arts : System.Web.UI.Page
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
            binddata("1");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string newsType = this.DropDownList1.SelectedValue.ToString();
        binddata(newsType);
    }
    public void binddata(string newsType)
    {
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select * from [news] where [newsType]=" + newsType;
            cmd.Connection = con;
            con.Open();
            OleDbDataReader odr = cmd.ExecuteReader();
            string recodeHtml = "";
            while (odr.Read())
            {
                recodeHtml = recodeHtml + "<tr>";
                recodeHtml = recodeHtml + "<td>" + odr["newsID"] + "</td>";
                recodeHtml = recodeHtml + "<td>" + odr["addUer"] + "</td>";
                recodeHtml = recodeHtml + "<td>《" + odr["title"] + "》</td>";
                recodeHtml = recodeHtml + "<td>" + odr["totalTime"] + "分钟</td>";
                recodeHtml = recodeHtml + "<td title=\"" + odr["body"].ToString().Replace("\"","\'") + "\">" + odr["body"].ToString().Substring(0, 30) + "……</td>";
                recodeHtml = recodeHtml + "<td>" + odr["addTime"] + "</td>";
                recodeHtml = recodeHtml + "<td>" + odr["useTimes"] + "次</td>";
                recodeHtml = recodeHtml + "<td>" + "<a href='addArt.aspx?id=" + odr["newsID"] + "' title='修改'><img src='../images/edit.gif' alt='修改' /></a></td>";
                recodeHtml = recodeHtml + "<td>" + "<a href='delete.aspx?tablename=news&key=newsID&value=" + odr["newsID"] + "' title='删除' onclick=\"return confirm('你确定要删除吗?删除后将不能恢复.');\"><img src='../images/delete.gif' alt='删除' /></a></td>";
                recodeHtml = recodeHtml + "</tr>";
            }
            odr.Close();
            con.Close();
            this.Literal1.Text = recodeHtml.ToString();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("从news表取全部数据时发生错误.", exp.ToString());
        }
    }
}
