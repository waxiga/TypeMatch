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

public partial class admin_addArt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (adminOperation.checkIfAdmin())
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        this.Submit1.Value = "保存修改";
                        OleDbConnection con = DB.createcon();
                        string artID = Request.QueryString["id"].ToString();
                        this.artIdHidden.Value = artID;
                        string cmdStr = "select top 1 * from [news] where [newsID]=" + artID;
                        OleDbCommand cmd = new OleDbCommand(cmdStr, con);
                        con.Open();
                        OleDbDataReader odr = cmd.ExecuteReader();
                        while (odr.Read())
                        {
                            this.artTitleTb.Text = odr["title"].ToString();
                            this.totalTimeTb.Text = odr["totalTime"].ToString();
                            this.artBodyTf.Value = odr["body"].ToString();
                            this.artTypeDbl.SelectedValue = odr["newsType"].ToString();
                        }
                        odr.Close();
                        con.Close();
                    }
                    catch (Exception exp)
                    {
                        saveErrorMessage.writeFile("查询[news]表的1条数据时发生错误.错误来自页面：admin/addArt.aspx.cs", exp.ToString());
                        string alertTxt = "<script language='javascript'>alert('载入数据失败，请重试！');history.go(-1);</script>";
                        Response.Write(alertTxt);
                    }
                }
            }
            else {
                string alertTxt = "<script language='javascript'>alert('对不起,你尚未登陆或登陆超时，不能执行操作！');window.location='../login.html';</script>";
                Response.Write(alertTxt);
            }
        }
    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string alertTxt = "<script language='javascript'>alert('保存数据失败，请重试！');</script>";
        try
        {
            string artID = this.artIdHidden.Value.ToString();
            string artTitle = this.artTitleTb.Text.ToString();
            string artBody = this.artBodyTf.Value.ToString();
            string totalTime = this.totalTimeTb.Text.ToString();
            string artType = this.artTypeDbl.SelectedValue.ToString();
            string addUser = "admin";
            if (Session["userName"] != null)
            {
                addUser = Session["userName"].ToString();
            }
            string cmdStr = "insert into [news](newsType,addUer,addTime,title,totalTime,body) values(" + artType + ",'" + addUser + "','" + DateTime.Now.ToString() + "',@arttitle," + totalTime + ",@artbody)";
            if (artID!= "")
            {
                cmdStr = "update [news] set [newsType]=" + artType + ",[title]=@arttitle,[totalTime]=" + totalTime + ",[body]=@artbody where newsID=" + artID;
            }
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = cmdStr;
            cmd.Parameters.AddWithValue("@arttitle", artTitle);
            cmd.Parameters.AddWithValue("@artbody", artBody);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            alertTxt = "<script language='javascript'>alert('保存数据成功！');</script>";
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("查询[news]表的1条数据时发生错误.错误来自页面：admin/addArt.aspx.cs", exp.ToString());
        }
        Response.Write(alertTxt);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.artTitleTb.Text != "" || this.artBodyTf.Value != "")
        {
            Response.Write("<script language='javascript'>if(confirm('你确定确定不保存就离开本页面吗?.')){window.location='arts.aspx';}</script>");
        }
        else
        {
            Response.Redirect("arts.aspx");
        }
    }
}
