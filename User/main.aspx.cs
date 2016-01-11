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

public partial class admin_main : System.Web.UI.Page
{
    public int theBG;
    public string adminName="未登陆";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AdminOper.ifLogin();
            Random rd=new Random();
            theBG = rd.Next(20);
            if(Session["admin"]!=null)
            adminName = Session["admin"].ToString();
        }
    }
}
