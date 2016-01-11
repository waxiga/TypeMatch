<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["login"] != null)
            {
                Response.Write("已经登陆");
                HttpCookie getCookieValue = Request.Cookies["login"];
                string username = getCookieValue.Values["userName"].ToString();
                Session["username"] = username;
                Response.Write(Session["username"].ToString());
            }
            else
            {
                Response.Write("未登陆");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie loginCookie = new HttpCookie("login");
        loginCookie.Values.Add("userName", this.TextBox1.Text);
        loginCookie.Expires = DateTime.Now.AddYears(1);
        Response.AppendCookie(loginCookie);
        Response.Redirect("index.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        HttpCookie loginCookie = new HttpCookie("login");
        loginCookie.Expires = DateTime.Now.AddDays(-1);
        Response.AppendCookie(loginCookie);
        Session.Remove("username");
        Response.Redirect("index.aspx");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Cookies测试</title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1"
            runat="server" Text="登陆" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="注销" /></div>
    </form>
</body>
</html>
