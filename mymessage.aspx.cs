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

public partial class mymessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userName"] == null)
            {
                Response.Write("<script language='javascript'>alert('对不起,你还没登陆,不能查看信息!');window.location='login.html';</script>");
            }
            else
            {
                DataTable dt = studentOperation.selectMyMessage(Session["userName"].ToString());
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
        }
    }
}
