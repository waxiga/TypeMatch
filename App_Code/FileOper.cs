using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

/// <summary>
/// FileOper 的摘要说明
/// </summary>
public class FileOper
{
	public FileOper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 写文件操作,返回bool形数据
    /// </summary>
    /// <param name="fileDir">根目录下的文件路径，如update\</param>
    /// <param name="fileName">文件名，如temp.doc</param>
    /// <param name="txtStream">文本流，要输入的文本流信息</param>
    public static bool writeOneFile(string fileDir,string fileName, string txtStream)
    {
        bool returnValue = true;
        string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
        string strDirPath = serverBasePath + fileDir;//文件夹路径
        //如果文件夹不存在,则创建一个
        if (!Directory.Exists(strDirPath))
        {
            Directory.CreateDirectory(strDirPath);
        }
        StreamWriter sw = null;
        string fullPath = strDirPath + fileName;//完整目录
        Encoding encod = Encoding.GetEncoding("gb2312");//设置编码
        try  //开始写文件
        {
            sw = new StreamWriter(fullPath, false, encod);
            sw.Write(txtStream);
            sw.Flush();
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("写文件"+fullPath+"时出错",exp.ToString());
            returnValue = false;
        }
        finally
        {
            sw.Close();
        }
        return returnValue;
    }
    /// <summary>
    /// 读文件操作,返回string数据
    /// </summary>
    /// <param name="fileDir">根目录下的文件路径，如update\</param>
    /// <param name="fileName">文件名，如temp.doc</param>
    public static string readOneFile(string fileDir, string fileName)
    {
        string returnValue ="没有读取到数据";
        string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
        string fullPath =serverBasePath+fileDir+ fileName;//完整目录
        Encoding encod = Encoding.GetEncoding("gb2312");//设置编码
        StreamReader sr = null;
        try  //读文件
        {
            if (ifHaveThisFile(fileDir + fileName))
            {
                sr = new StreamReader(fullPath, encod);
                returnValue = sr.ReadToEnd();
                sr.Close();
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("读文件" + fullPath + "时出错", exp.ToString());
            returnValue = returnValue + exp.ToString();
        }
        return returnValue;
    }
    /// <summary>
    /// 复制文件操作,返回bool形数据
    /// </summary>
    /// <param name="sourceFileFullPath">源文件完整路径</param>
    /// <param name="newFileFullPath">目的文件完整路径</param>
    public static bool copyOneFile(string sourceFileFullPath,string newFileFullPath)
    {
        bool returnValue = false;
        string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
        try
        {
            if (ifHaveThisFile(sourceFileFullPath))
            {
                File.Copy(serverBasePath + sourceFileFullPath, serverBasePath + newFileFullPath, true);
                returnValue = true;
            }
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("复制文件时出错，原因，可能是有其它用户正在使用此文件", exp.ToString());
        }
        return returnValue;
    }
    /// <summary>
    /// 删除文件操作,返回bool形数据
    /// </summary>
    /// <param name="fileFullPath">所要删除的文件完整路径</param>
    public static bool deleteOneFile(string fileFullPath)
    {
        bool returnValue = true;
        string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
        try
        {
            if (ifHaveThisFile(fileFullPath))
                File.Delete(serverBasePath + fileFullPath);
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("删除文件时出错，原因：", exp.ToString());
            returnValue = false;
        }
        return returnValue;
    }
    /// <summary>
    /// 判断文件是否存在,返回bool形数据
    /// </summary>
    /// <param name="fileFullPath">文件完整路径</param>
    public static bool ifHaveThisFile(string fileFullPath)
    {
        bool returnValue = false;
        string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
        try
        {
            if (File.Exists(serverBasePath + fileFullPath))
                returnValue = true;
        }
        catch (Exception exp)
        {
            saveErrorMessage.writeFile("查找文件时出错，原因：", exp.ToString());
        }
        return returnValue;
    }
}
