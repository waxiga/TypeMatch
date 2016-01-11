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

public partial class admin_adminTop : System.Web.UI.Page
{
    public string adminName="未登陆";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {
            adminName = Session["admin"].ToString();
        }
    }
}
