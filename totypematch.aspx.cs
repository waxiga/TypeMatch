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

public partial class totypematch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!studentOperation.checkIfLogin())
        {
            string alertstring = "<script language='javascript'>alert('对不起,你尚未登陆,请登陆再进行打字.');window.location='login.html';</script>";
            Response.Write(alertstring);
        }
        else
        {
            string typetype="3",artID="",artTitle="", artBody="", totalTime="",cmdStr="";
            if (Request.QueryString["type"] != null)
            {
                typetype = Request.QueryString["type"].ToString();
            }
            if (typetype == "3")
            {
                artID = countOperation.getOneCountFromApplication("ChTypeMatchArtID").ToString();
                cmdStr = "select top 1 * from news where newsID=" + artID + " and newsType=3";
            }
            else
            {
                if (typetype == "4")
                {
                    artID = countOperation.getOneCountFromApplication("EnTypeMatchArtID").ToString();
                    cmdStr = "select top 1 * from news where newsID=" + artID + " and newsType=4";
                }
                else
                {
                    if (Request.QueryString["artID"] == null)
                    {
                        artID = "1";
                        cmdStr = "select top 1 * from news where newsType=" + typetype + " order by addTime desc";
                    }
                    else
                    {
                        artID = Request.QueryString["artID"].ToString();
                        cmdStr = "select top 1 * from news where newsID=" + artID + " and newsType=" + typetype;

                    }
                }
            }
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand(cmdStr, con);
            con.Open();
            OleDbDataReader odr = cmd.ExecuteReader();
            while (odr.Read())
            {
                artTitle = odr["title"].ToString();
                totalTime = odr["totalTime"].ToString();
                artBody = odr["body"].ToString();
                artID = odr["newsID"].ToString();
            }
            odr.Close();
            con.Close();
            Session["typetype"] = typetype;
            Session["totalTime"] = totalTime;
            Session["newsID"] = artID;
            Session["typeArtTitle"] = artTitle;
            Session["artBody"] = artBody;
            string dds=DateTime.Now.Millisecond.ToString();
            Session["typeCookie"] = dds;
            con.Open();
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = "update [news] set useTimes=useTimes+1 where newsID="+artID;
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();
            con.Close();
            typeOperation.updateTypeTimeAndIP(typetype);
            if (cookieOperation.setOneCookie("typeMatchCookie", dds))
            {
                switch (typetype)
                {
                    case "1":
                        countOperation.countAddOne("joinEnTypeTrainCount");
                        Response.Redirect("typematch.aspx");
                        break;
                    case "2":
                        countOperation.countAddOne("joinChTypeTrainCount");
                        Response.Redirect("typematch.aspx");
                        break;
                    case "3":
                        if (countOperation.getOneCountFromApplication("ChTypeMatchIsOpen") == 1)
                        {
                            countOperation.countAddOne("joinChTypeMatchCount");
                            Response.Redirect("typematch.aspx"); 
                        }
                        else
                        {
                            if (countOperation.getOneCountFromApplication("EnTypeMatchIsOpen") == 1)
                            {
                                Response.Redirect("totypematch.aspx?type=4");
                            }
                            else
                            {
                                Response.Write("<p style='margin:50px'><h1>对不起,中文打字比赛和英文打字比赛都还没开始，请先进行练习．</h1><br/><b>如果你是管理员,请登陆后台点击[开始比赛.]<a href='default.aspx'>返回首页</a><b></P>");
                            }
                        }
                        break;
                    case "4":
                        if (countOperation.getOneCountFromApplication("EnTypeMatchIsOpen") == 1)
                        {
                            countOperation.countAddOne("joinEnTypeMatchCount");
                            Response.Redirect("typematch.aspx");
                        }
                        else
                        {
                            Response.Write("<h1>对不起,英文打字比赛还没开始,如果你是管理员,请登陆后台点击[开始比赛.]</h1><a href='default.aspx'>返回首页</a>");
                        }
                        break;
                    default:
                        if (countOperation.getOneCountFromApplication("ChTypeMatchIsOpen") == 1)
                        {
                            countOperation.countAddOne("joinChTypeMatchCount");
                            Response.Redirect("typematch.aspx");
                        }
                        else
                        {
                            Response.Write("<h1>对不起,中文打字比赛还没开始,如果你是管理员,请登陆后台点击[开始比赛.]</h1><a href='default.aspx'>返回首页</a>");
                        }
                        break;
                }
            }
            else
            {
                Response.Write("<h1>对不起,你的浏览器不支持Cookie,为了能正确保存你的打字结果，请开启Cookie再开始打字．</h1>如果你不想保存成绩，也可以<a href='typeMatch.aspx'>点击此处继续进入比赛</a>");
            }
        }
    }
}
