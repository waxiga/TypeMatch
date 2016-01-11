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

public partial class deleteMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string alertstring, typeID;
            if (studentOperation.checkIfLogin())
            {
                if (Request.QueryString["id"] != null)
                {
                    typeID = Request.QueryString["id"].ToString();
                    if (typeID == "all")
                    {
                        if (studentOperation.delAllMessage())
                        {
                            alertstring = "<script language='javascript'>alert('恭喜，成功删除所有站内信.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                        else
                        {
                            alertstring = "<script language='javascript'>alert('对不起，删除站内信失败.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                    }
                    else
                    {
                        if (studentOperation.delOneMessage(typeID))
                        {
                            alertstring = "<script language='javascript'>alert('恭喜，成功删除一条信息.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                        else
                        {
                            alertstring = "<script language='javascript'>alert('对不起，删除站内信息失败.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                    }
                }
                else
                {
                    alertstring = "<script language='javascript'>alert('对不起，删除站内信息失败.');window.location='selectResult.aspx';</script>";
                    Response.Write(alertstring);
                }
            }
            else
            {
                alertstring = "<script language='javascript'>alert('对不起，未登陆不能删除站内信息.');window.location='login.html';</script>";
                Response.Write(alertstring);
            }
        }
    }
}
