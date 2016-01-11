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
using System.Data.OleDb;

public partial class typeMatch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!studentOperation.checkIfLogin())
            {
                string alertstring = "<script language='javascript'>alert('对不起,你尚未登陆,请先登陆再进行打字.');window.location='login.html';</script>";
                Response.Write(alertstring);
            }
            else
            {
                string typetype= "3";
                if (Session["typetype"] != null)
                {
                    typetype = Session["typetype"].ToString();
                }
                if (typetype == "3" || typetype=="4")
                {
                    this.selectArtBtn.Visible = false;//5^1^a^s^p^x
                }
                else
                {
                    OleDbConnection con = DB.createcon();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "select * from [news] where [newsType]=" + typetype;
                    cmd.Connection = con;
                    con.Open();
                    OleDbDataReader odr = cmd.ExecuteReader();//5%1%a%s%p%x
                    this.Repeater1.DataSource = odr;
                    this.Repeater1.DataBind();
                    odr.Close();
                }
            }
        }
    }
}
