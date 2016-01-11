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
using System.IO;
using System.Text;

/// <summary>
/// typeOperation 的摘要说明
/// </summary>
public class typeOperation
{
	public typeOperation()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string getArtTitleById(string artID)
    {
        string artTitle = "";
        try
        {
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "select [title] from [news] where [newsID]=" + artID;
            cmd.Connection = con;
            con.Open();
            artTitle = cmd.ExecuteScalar().ToString();
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("删除全部打字结果时发生错误.", exp.ToString());
        }
        return artTitle;
    }
    public static string topType(string typeType,int count)
    {
        string returnStr= "";
        try
        {
            string cmdstr = "select top " + count + " [typeUser],[typeArtTitle],[typeSpeed] from [typeResult] where ";
            switch (typeType)
            {
                case "ChType":
                    cmdstr = cmdstr + "typeType=2 or typeType=3"; break;
                case "EnType":
                    cmdstr = cmdstr + "typeType=1 or typeType=4"; break;
                case "ChMatch":
                    cmdstr = cmdstr + "typeType=3"; break;
                case "EnMatch":
                    cmdstr = cmdstr + "typeType=4"; break;
                case "ChTrain":
                    cmdstr = cmdstr + "typeType=2 "; break;
                case "EnTrain":
                    cmdstr = cmdstr + "typeType=1"; break;
                default:
                    cmdstr = cmdstr + "typeType=2 or typeType=3"; break;
            }
            cmdstr = cmdstr + " order by [typeSpeed] desc";
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = cmdstr;
            cmd.Connection = con;
            con.Open();
            OleDbDataReader odr = cmd.ExecuteReader();
            int i = 1;
            while (odr.Read())
            {
                returnStr = returnStr + "<li>第"+i+"名:" + odr["typeUser"] + "《" + odr["typeArtTitle"] + "》(" + odr["typeSpeed"] + "字/分)</li>";
                i++;
            }
            odr.Close();
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("设置公告时发生错误.错误来自:typeOperation.cs", exp.Message.ToString());
        }
        return returnStr;
    }
    public static bool writeIndexFile(string replaceStr)
    {
        string path = HttpContext.Current.Server.MapPath("../");//取目录
        Encoding encod = Encoding.GetEncoding("UTF-8");//设置编码
        // 读模板文件
        string templatePath = path + "admin/Default.txt";
        StreamReader sr = null;
        StreamWriter sw = null;
        string templateStr = "";
        try  //读文件
        {
            sr = new StreamReader(templatePath, encod);
            templateStr = sr.ReadToEnd();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("读文件时出错", exp.Message.ToString());
            return false;
        }
        finally
        {
            sr.Close();
        }
        //读文件完成后开始替换标签
        templateStr = templateStr.Replace("{$affiche$}", replaceStr);
        string copyright = "<div id=\"footer\">在使用本系统过程中有任何问题,请点击<a href=\"sendMessage.aspx\" title=\"给站长信箱发送信息\"  class=\"menu\" onclick=\"x_open('给站长信箱发送信息。','sendMessage.aspx',440,276);return false;\">给站长发站内信</a>或者到<a href=\"guestbook.aspx\" title=\"留言板\"  class=\"menu\" onclick=\"x_open('留言板','guestbook.aspx',674,550);return false;\">留言板</a>留言<br />copyright:<a href=\"http://www.bfc2008.cn/\">清新视觉网络工作室</a> 2007--2008 <br />键指飞舞 v1.0 2008   常用输入法<a href=\"getTxt.aspx?key=download\" title=\"本系统的使用帮助。\"  class=\"menu\" onclick=\"x_open('使用帮助','getTxt.aspx?key=download',674,340);return false;\">下载</a></div></div></form></body></html>";
        templateStr += copyright.ToString();
        try  //写文件
        {
            sw = new StreamWriter(path + "/Default.aspx", false, encod);
            sw.Write(templateStr);
            sw.Flush();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("写文件时出错", exp.Message.ToString());
            return false;
        }
        finally
        {
            sw.Close();
        }
        return true;
    }
    public static void updateTypeTimeAndIP(string typetype)
    {
        try
        {
            string cmdtxt = "update [student] set ";
            string username = "admin";
            if (HttpContext.Current.Session["userName"] != null)
            {
                username = HttpContext.Current.Session["userName"].ToString();
            }
            switch (typetype)
            {
                case "1":
                    cmdtxt = cmdtxt + "trainEnCount=trainEnCount+1"; break;
                case "2":
                    cmdtxt = cmdtxt + "trainChCount=trainChCount+1"; break;
                case "3":
                    cmdtxt = cmdtxt + "mathchChCount=mathchChCount+1"; break;
                case "4":
                    cmdtxt = cmdtxt + "mathchEnCount=mathchEnCount+1"; break;
                default:
                    cmdtxt = cmdtxt + "mathchChCount=mathchChCount+1"; break;
            }
            cmdtxt = cmdtxt + ",lastTypeTime='" + DateTime.Now + "',lastTypeIP='" + HttpContext.Current.Request.ServerVariables["REMOTE_HOST"] + "' where [studentUsername]='" + username + "'";
            OleDbConnection con = DB.createcon();
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = cmdtxt;
            cmd2.Connection = con;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("更新学生打字记录时出错", exp.ToString());
        }
    }
}
