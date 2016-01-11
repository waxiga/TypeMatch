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

public partial class admin_affiche : System.Web.UI.Page
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
                DataTable dt = adminOperation.getSomeTxt("affiche");
                this.afficheBody.Value = dt.Rows[0][3].ToString();
            }
            catch (Exception exp)
            {
                string repsonStr = "<script language='javascript'>alert('加载数据失败,请重试！失败原因:"+exp.Message.ToString()+"');</script>";
                Response.Write(repsonStr);
            }
        }
    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string googao=this.afficheBody.Value.ToString();
        string repsonStr = "<script language='javascript'>alert('保存数据失败,请重试！');</script>";
        if (adminOperation.setSomeTxt("affiche", googao))
        {
            if (typeOperation.writeIndexFile(googao))
            {
                repsonStr="<script language='javascript'>alert('保存数据成功！');</script>";
            }
        }
        Response.Write(repsonStr);
    }
}
