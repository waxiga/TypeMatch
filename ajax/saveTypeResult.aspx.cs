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

public partial class ajax_saveTypeResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool hefaUser = false;//用户是否合法，也就是是否从本站提交数据
        DateTime nowTime = DateTime.Now;
        if (Session["endLockTime"] != null)
        {
            DateTime endLockTime = Convert.ToDateTime(Session["endLockTime"]);
            Session["endLockTime"] = nowTime.AddMinutes(5);
            int a = DateTime.Compare(endLockTime, nowTime);
            if (a > 0)
            {
                Response.Write("0");
                Response.End();
            }

        }
        else
        {
            Session["endLockTime"] = nowTime.AddMinutes(5);
        }
        if (Request.ServerVariables["HTTP_REFERER"] != null)
        {
            string ServerName = Request.ServerVariables["SERVER_NAME"];
            string ServerName2 = Request.ServerVariables["HTTP_REFERER"];
            if (ServerName == ServerName2.Substring(7, ServerName.Length))
            {
                if (Request.Form["co"] != null && Request.Form["co"].ToString() == Session["typeCookie"].ToString())
                {
                    hefaUser = true;
                }
            }
        }
        if (!hefaUser)
        {
            systemRecord.insertOneRecord("参赛者“" + Session["userName"].ToString() + "“被怀疑有作弊行为。其作弊方法是站外提交。");
        }
        try
        {
            if (Request.Form["right"] != null && Request.Form["wrong"] != null && Request.Form["speed"] != null && Request.Form["last_time"] != null)
            {
                string typeuser = Session["userName"].ToString();
                string typeEndTime = DateTime.Now.ToString();
                string typeIP = Request.ServerVariables["REMOTE_HOST"].ToString();
                string typeType = Session["typetype"].ToString();
                string typeTitle = Session["typeArtTitle"].ToString();
                string rightwords = Request.Form["right"].ToString();
                string wrongwords = Request.Form["wrong"].ToString();
                string speed = Request.Form["speed"].ToString();
                string usetime = Request.Form["last_time"].ToString();
                if (speed != "0" && rightwords != "0")
                {
                    string cmdtxt = "insert into[typeResult](typeUser,typeIP,typeEndTime,typeType,typeArtTitle,useTime,typeSpeed,rightWordCount,wrongWordCount)";
                    cmdtxt = cmdtxt + " values('" + typeuser + "','" + typeIP + "','" + typeEndTime + "'," + typeType + ",'" + typeTitle + "'," + usetime + "," + speed + "," + rightwords + "," + wrongwords + ")";
                    if (Request.Form["zuobi"] == null)
                    {
                        OleDbConnection con = DB.createcon();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandText = cmdtxt;
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        systemRecord.insertOneRecord("参赛者“" + typeuser + "“成功提交打字成绩！");
                        Response.Write("1");
                    }
                    else
                    {
                        systemRecord.insertOneRecord("参赛者“" + Session["userName"].ToString() + "“被怀疑有作弊行为。其中，打字记录为：用时：" + usetime.ToString() + ";速度：" + speed.ToString() + ";正确字数：" + rightwords.ToString() + ";错误字数：" + wrongwords.ToString());
                    }
                }
                else
                {
                    Response.Write("0");
                }
            }
            else
            {
                Response.Write("0");
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("保存打字结果时出错.", exp.ToString());
            Response.Write("0");
        }
    }
}
