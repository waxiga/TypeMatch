using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// MD5Encode 的摘要说明
/// </summary>
public class MD5Encode
{
	public MD5Encode()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string MD5_encode(string needMD5EncodeString)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(needMD5EncodeString, "MD5");
    }
    public static string docubleMD5_encode(string needMD5EncodeString1, string needMD5EncodeString2)
    {
        return MD5_encode(MD5_encode(needMD5EncodeString1) + MD5_encode(needMD5EncodeString2));
    }
}
