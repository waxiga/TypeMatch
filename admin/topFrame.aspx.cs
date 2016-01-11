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

public partial class admin_topFrame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["realName"] != null)
        {
            this.Literal1.Text = Session["realName"].ToString();
        }
        else
        {
            if (studentOperation.checkIfLogin())
            {
                this.Literal1.Text = Session["realName"].ToString();
            }
            else
            {
                this.Literal1.Text = "未登陆用户";
            }
        }
    }
}
