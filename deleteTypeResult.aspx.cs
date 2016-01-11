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

//源码下载 www.51aspx.com
public partial class deleteTypeResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string alertstring,typeID;
            if (studentOperation.checkIfLogin())
            {
                if (Request.QueryString["id"] != null)
                {
                    typeID=Request.QueryString["id"].ToString();
                    if (typeID == "all")
                    {
                        if (studentOperation.delAllTypeResult())
                        {
                            alertstring = "<script language='javascript'>alert('恭喜，成功删除所有记录.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                        else
                        {
                            alertstring = "<script language='javascript'>alert('对不起，删除打字记录失败.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                    }
                    else
                    {
                        if (studentOperation.delOneTypeResult(typeID))
                        {
                            alertstring = "<script language='javascript'>alert('恭喜，成功删除一条记录.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                        else
                        {
                            alertstring = "<script language='javascript'>alert('对不起，删除打字记录失败.');window.location='selectResult.aspx';</script>";
                            Response.Write(alertstring);
                        }
                    }
                }
                else
                {
                    alertstring = "<script language='javascript'>alert('对不起，删除打字记录失败.');window.location='selectResult.aspx';</script>";
                    Response.Write(alertstring);
                }
            }
            else
            {
                alertstring = "<script language='javascript'>alert('对不起，未登陆不能删除打字记录.');window.location='login.html';</script>";
                Response.Write(alertstring);
            }
        }
    }
}
