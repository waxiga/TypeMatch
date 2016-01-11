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

public partial class admin_setDownLoad : System.Web.UI.Page
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
            string key = "howtoplay";
            if (Request.QueryString["key"] != null)
            {
                key = Request.QueryString["key"].ToString();
            }
            DataTable dt=adminOperation.getSomeTxt(key);
            this.HiddenField1.Value =dt.Rows[0][1].ToString();
            this.Label1.Text = dt.Rows[0][2].ToString();
            this.TEXTAREA1.Value = dt.Rows[0][3].ToString();
        }
    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string key = this.HiddenField1.Value.ToString();
        string value = this.TEXTAREA1.Value.ToString();
        if (adminOperation.setSomeTxt(key, value))
        {
            Response.Write("<script language=javascript>alert('修改成功!');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('修改失败,请重试或联系超级管理员!');</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string fullFileName = this.FileUpload1.PostedFile.FileName;
        string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);//51(aspx)
        string fileType = fileName.Substring(fileName.LastIndexOf(".") + 1);
        if (fileType == "rar" || fileType == "jpg" || fileType == "gif" || fileType == "bmp" || fileType == "txt" || fileType == "doc" || fileType == "html" || fileType == "htm" || fileType == "aspx" || fileType == "cs" || fileType == "xsl" || fileType == "ppt")
        {
            DateTime dt = DateTime.Now;
            fileName = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + "_" + fileName;
            this.FileUpload1.PostedFile.SaveAs(Server.MapPath("../uploadFile") + "\\" + fileName);
            this.Literal1.Text = "上传成功!下面的输入框是文件的相对地址.";
            this.filepath.Visible = true;
            this.TextBox1.Text = "uploadFile/"+fileName;
        }
        else
        {
            Response.Write("<script language=javascript>alert('不支持上传该类型的文件,请重新选择文件上传!');</script>");
        }
    }
}
