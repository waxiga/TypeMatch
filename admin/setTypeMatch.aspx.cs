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

public partial class admin_setTypeMatch : System.Web.UI.Page
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
            if (adminOperation.checkIfAdmin())
            {
                int typestatus = countOperation.getOneCountFromApplication("ChTypeMatchIsOpen");
                if (typestatus == 1)
                {
                    string art_id = countOperation.getOneCountFromApplication("ChTypeMatchArtID").ToString();
                    this.Chtypematch.Text = "已开启,打字文章是:" + typeOperation.getArtTitleById(art_id);
                    this.closeChBtn.Visible = true;
                    this.openChBtn.Visible = false;
                }
                else
                {
                    this.Chtypematch.Text = "已关闭";
                    this.closeChBtn.Visible = false;
                    this.openChBtn.Visible = true;
                }
                typestatus = countOperation.getOneCountFromApplication("EnTypeMatchIsOpen");
                if (typestatus == 1)
                {
                    string art_id = countOperation.getOneCountFromApplication("EnTypeMatchArtID").ToString();
                    this.Entypematch.Text = "已开启,打字文章是:" + typeOperation.getArtTitleById(art_id);
                    this.closeEnBtn.Visible = true;
                    this.openEnBtn.Visible = false;
                }
                else
                {
                    this.Entypematch.Text = "已关闭";
                    this.closeEnBtn.Visible = false;
                    this.openEnBtn.Visible = true;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起,你未登陆或登陆超时,请重新登陆!');window.location='../login.html';</script>");
            }
        }
    }
    protected void openChBtn_ServerClick(object sender, EventArgs e)
    {
        int artid = Convert.ToInt32(this.DropDownList1.SelectedValue);
        if (countOperation.setOneCountToApplication("ChTypeMatchIsOpen", 1) && countOperation.setOneCountToApplication("ChTypeMatchArtID", artid))
        {
            this.openChBtn.Visible= false;
            this.closeChBtn.Visible =true;
            string art_id = countOperation.getOneCountFromApplication("ChTypeMatchArtID").ToString();
            this.Chtypematch.Text = "已开启,打字文章是:" + typeOperation.getArtTitleById(art_id);
            Response.Write("<script language='javascript'>alert('设置成功!');</script>");
        }
    }
    protected void closeChBtn_ServerClick(object sender, EventArgs e)
    {
        if (countOperation.setOneCountToApplication("ChTypeMatchIsOpen", 0))
        {
            this.openChBtn.Visible = true;
            this.closeChBtn.Visible =false;
            this.Chtypematch.Text = "已关闭";
            Response.Write("<script language='javascript'>alert('设置成功!');</script>");
        }
    }
    protected void openEnBtn_ServerClick(object sender, EventArgs e)
    {
        int artid = Convert.ToInt32(this.DropDownList2.SelectedValue);
        if (countOperation.setOneCountToApplication("EnTypeMatchIsOpen", 1) && countOperation.setOneCountToApplication("EnTypeMatchArtID", artid))
        {
            this.openEnBtn.Visible = false;
            this.closeEnBtn.Visible = true;
            string art_id = countOperation.getOneCountFromApplication("EnTypeMatchArtID").ToString();
            this.Entypematch.Text = "已开启,打字文章是:" + typeOperation.getArtTitleById(art_id);
            Response.Write("<script language='javascript'>alert('设置成功!');</script>");
        }
    }
    protected void closeEnBtn_ServerClick(object sender, EventArgs e)
    {
        if (countOperation.setOneCountToApplication("EnTypeMatchIsOpen", 0))
        {
            this.openEnBtn.Visible = true;
            this.closeEnBtn.Visible = false;
            this.Entypematch.Text = "已关闭";
            Response.Write("<script language='javascript'>alert('设置成功!');</script>");
        }
    }
}
