﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ajax_checkUsernameEnable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["user"]!=null)
        {
            Response.Write(studentOperation.checkUsernameIfEnable(Request.QueryString["user"].ToString()));
        }
    }
}
