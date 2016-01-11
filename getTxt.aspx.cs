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

public partial class getTxt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string key = "howtoplay";
        if (!IsPostBack)
        {
            if (Request.QueryString["key"] != null)
            {
                key = Request.QueryString["key"].ToString();
            }
            this.Repeater1.DataSource = adminOperation.getSomeTxt(key);//5~1-a-s-p-x
            this.Repeater1.DataBind();
        }
    }
}
