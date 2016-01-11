using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

//源码下载 www.51aspx.com
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (studentOperation.checkIfLogin())
        {
            string userType = Session["userType"].ToString();
            string userName = Session["userName"].ToString();
            string realName = Session["realName"].ToString();
            this.real_name.InnerText=realName;
            this.student_name.InnerText=realName;
            string paiming = studentOperation.getPaiming(userName).ToString();
            this.studentPaiming.InnerText = paiming;
            this.adminPaiming.InnerText = paiming;
            switch (userType)
            {
                case "1":
                    this.isstudent.Style.Remove("display"); break;
                case "2":
                    this.isadmin.Style.Remove("display"); break;
                case "3":
                    this.isadmin.Style.Remove("display"); 
                    this.ifSuperAdmin.Text="超级";
                    break;
                default:
                    this.isstudent.Style.Remove("display"); break;
            }
            int newMessageCount =studentOperation.haveNewMessageCount(userName);
            if (newMessageCount > 0)
            {
                this.alertWindow_container.Visible = true;
                this.alertTable.Visible = true;
                this.messageCount.InnerText = newMessageCount.ToString();
            }
        }
        else
        {
            this.nologin.Style.Remove("display");
        }
    }
}
