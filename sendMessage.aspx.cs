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
                this.header.InnerText = "����";
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
                    username = "δ��½�û�.";
                }
                if (Request.Form["messagetype"] != "")
                {
                    messagetype = Request.Form["messagetype"];//5*1*a*s*p*x
                }
                if (studentOperation.addOneMessage(username, studentname, messagebody, messagetype, "��ͨ��Ϣ"))
                {
			Response.Write("<script language='javascript'>alert('վ���ŷ��ͳɹ�!��л��Ա�վ����������.');</script>");
                }
                else
                {
			Response.Write("<script language='javascript'>alert('վ���ŷ���ʧ��,�����Ի���ϵ����Ա.');</script>");
                }
            }

    }
}
