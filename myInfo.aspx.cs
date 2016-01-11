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

public partial class myInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binderStudentInfo(Session["userName"].ToString());
        }
    }
    public void binderStudentInfo(string username)
    {
        try
        {
            OleDbConnection con=DB.createcon();
            OleDbCommand cmd=new OleDbCommand();
            cmd.CommandText="select * from [student] where [studentUsername]='"+username+"'";
            cmd.Connection=con;
            con.Open();
            OleDbDataReader odr= cmd.ExecuteReader();
            while(odr.Read()){
               this.userName.Text=username;
                this.student_name.Value=odr["studentName"].ToString();
                //this.student_id.Value = odr["studentID"].ToString();
                //this.student_xibie.Value = odr["studentDepartment"].ToString();
               // this.student_grate.Value = odr["studentGrade"].ToString();
                //this.student_class.Value = odr["studentClass"].ToString();
                //this.tel.Value = odr["studentTel"].ToString();
                this.qq.Value = odr["studentQQ"].ToString();
                this.about.Value = odr["studentAbout"].ToString();

                ////this.ChTypeTrainCount.Text=odr["trainChCount"].ToString();
                //this.EnTypeTrainCount.Text=odr["trainEnCount"].ToString();
                //this.ChypeMatchCount.Text=odr["mathchChCount"].ToString();
                //this.EnTypeMatchCount.Text=odr["mathchEnCount"].ToString();
            }
            odr.Close();
            con.Close();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("查询学生的个人信息时出错",exp.ToString());
        }
    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string realname=this.student_name.Value.ToString();
        //string studentID=this.student_id.Value.ToString();
        //string xibie=this.student_xibie.Value.ToString();
        //string grate=this.student_grate.Value.ToString();
        //string sclass=this.student_class.Value.ToString();
        //string stel=this.tel.Value.ToString();
        string sqq=this.qq.Value.ToString();
        string sabout=this.about.Value.ToString();
        string pass = this.password.Value.ToString();
        bool a1=saveOneRecode("studentName",realname);
        //bool a2=saveOneRecode("studentID",studentID);
        //bool a3=saveOneRecode("studentDepartment",xibie);
        //bool a4=saveOneRecode("studentGrade",grate);
        //bool a5=saveOneRecode("studentClass",sclass);
        //bool a6=saveOneRecode("studentTel",stel);
        bool a7=saveOneRecode("studentQQ",sqq);
        bool a8=saveOneRecode("studentAbout",sabout);//5+1+a+s+p+x
        bool a9 = saveOneRecode("studentPassword", pass);
        //if (a1 && a2 && a3 && a4 && a5 && a6 && a7 && a8)
        //{
        Response.Write("<script>alert('修改成功！');window.location='myInfo.aspx';</script>");
        //}
        //else
        //{
        //    Response.Write("<script>alert('修改成功！');window.location='myInfo.aspx';</script>");
        //}
    }
    public bool saveOneRecode(string key,string value)
    {
        try
        {
            if (value != "")
            {
                OleDbConnection con = DB.createcon();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "update [student] set [" + key + "]='" + value + "' where [studentUsername]='" + Session["userName"].ToString() + "'";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        catch(Exception exp)
        {
            saveErrorMessage.writeFile("更改学生个人信息时发生错误", exp.ToString());
            return false;
        }
    }
}
