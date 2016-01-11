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

public partial class sendMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["messageType"] != null)
            {
                this.header.InnerText = "留言";
                this.messageType.Value = "guestbook";
            }
        }
            string studentname, messagebody, username, messagetype;
            if (Request.Form["studentName"] != null && Request.Form["messagebody"] != null)
            {
                studentname = Server.HtmlEncode(Request.Form["studentName"].ToString());
                messagebody = Server.HtmlEncode(Request.Form["messagebody"].ToString());
                messagetype = "admin";
                if (Session["userName"] != null)
                {
                    username = Session["userName"].ToString();
                }
                else
                {
                    username = "未登陆用户.";
                }
                if (Request.Form["messagetype"] != "")
                {
                    messagetype = Request.Form["messagetype"];//5*1*a*s*p*x
                }
                if (studentOperation.addOneMessage(username, studentname, messagebody, messagetype, "普通信息"))
                {
			Response.Write("<script language='javascript'>alert('站内信发送成功!感谢你对本站提出意见或建议.');</script>");
                }
                else
                {
			Response.Write("<script language='javascript'>alert('站内信发送失败,请重试或联系管理员.');</script>");
                }
            }

    }
}
