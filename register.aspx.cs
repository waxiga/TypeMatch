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

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username, password, student_name, student_id, studen_xibie, studen_grate, studen_class, studen_tel, studen_qq, studen_about;
        bool student_sex;
        username = Request.Form["username"];
        if (studentOperation.checkUsernameIfEnable(username) == 1)
        {
            Response.Write("<script language='javascript'>alert('对不起,该用户名已被注册!请选择其它用户名.');window.location='reg.aspx';</script>");
            Response.End();
        }
        else
        {
            password = Request.Form["password"];
            student_name = Request.Form["studentName"];
            student_id = Request.Form["studentID"];
            if (Request.Form["sex"] == "boy")
                student_sex = true;
            else
                student_sex = false;
            studen_xibie =Request.Form["mail"].ToString();
            studen_grate = "";
            studen_class ="";
            studen_tel ="";
            studen_qq = Request.Form["qq"];
            studen_about = Request.Form["about"];
            if (Insert(username, password, student_name, student_id, student_sex, studen_xibie, studen_grate, studen_class, studen_tel, studen_qq, studen_about))
            {
                systemRecord.insertOneRecord("有一个新学生注册，真名为：" + student_name + ";用户名为：" + username);
                Response.Write("<script language='javascript'>alert('恭喜,注册成功!请登陆.');window.location='login.html';</script>");
                Response.End();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起,注册失败!请重试.');window.location='reg.aspx';</script>");
                Response.End();
            }
        }
    }
    public bool Insert(string username, string pass,string realname,string studentID,bool sex,string department,string grade,string studentclass,string tel, string qq,string about)
    {//插入数据
        try
        {
            string cmdtext = "insert into student(studentUsername,studentPassword,studentName,studentID,studentSex,email,studentGrade,studentClass,studentTel,studentQQ,studentAbout,registerTime,registerIP)";
            cmdtext = cmdtext + " values ('" + username + "','" + pass + "','" + realname + "','" + studentID + "'," + sex + ",'" + department + "','" + grade + "','" + studentclass + "','" + tel + "','" + qq + "','" + about + "','" + DateTime.Now.ToString()
 + "','" + Request.ServerVariables["REMOTE_HOST"] + "')";
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = DB.createcon();
            cmd.CommandText = cmdtext;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            countOperation.countAddOne("registerCount");
            return true;
        }
        catch
        {
            return false;
        }
    }
}
