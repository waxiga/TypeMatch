using System;
using System.Collections;


    public class SqlString
    {
        //公有静态方法，将SQL字符串里面的(')转换成('')
        public static String GetSafeSqlString(String XStr)
        {
            return XStr.Replace("'", "''");
        }

        //公有静态方法，将SQL字符串里面的(')转换成('')，再在字符串的两边加上(')
        public static String GetQuotedString(String XStr)
        {
            return ("'" + GetSafeSqlString(XStr) + "'");
        }
        public static string keepoutSqlKey(string inputStr)
        {
            string StrKeyWord = "select,insert,delete,from,count(,drop table,update,truncate,asc(,mid(,char(,xp_cmdshell,exec master,netlocalgroup administrators,:,net user,or,and,";
            StrKeyWord = StrKeyWord + "-,;,/,(,),[,],},{,%,@,*,!,',|";
            string[] strArray = System.Text.RegularExpressions.Regex.Split(StrKeyWord, ",", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            foreach (string i in strArray)
            {
                inputStr = inputStr.Replace(i, "");
            }
            return inputStr;
        }
        public static string newsBodyEnCode(string inputStr)
        {
            inputStr = inputStr.Replace("'", "{{{{");
            inputStr = inputStr.Replace("\"", "}}}}");
            inputStr = inputStr.Replace("-", "%%%%");
            inputStr = inputStr.Replace("|", "@@@@");
            return inputStr;
        }
        public static string newsBodyDenCode(string inputStr)
        {
            inputStr = inputStr.Replace("{{{{", "'");
            inputStr = inputStr.Replace( "}}}}","\"");
            inputStr = inputStr.Replace("%%%%", "-");
            inputStr = inputStr.Replace("@@@@", "|");
            return inputStr;
        }
        public static string TBCode(string strtb)
        {
            strtb = strtb.Replace("!", "");
            strtb = strtb.Replace("@", "");
            strtb = strtb.Replace("#", "");
            strtb = strtb.Replace("$", "");
            strtb = strtb.Replace("%", "");
            strtb = strtb.Replace("^", "");
            strtb = strtb.Replace("&", "");
            strtb = strtb.Replace("*", "");
            strtb = strtb.Replace("(", "");
            strtb = strtb.Replace(")", "");
            strtb = strtb.Replace("_", "");
            strtb = strtb.Replace("+", "");
            strtb = strtb.Replace("|", "");
            strtb = strtb.Replace("?", "");
            strtb = strtb.Replace("/", "");
            strtb = strtb.Replace(".", "");
            strtb = strtb.Replace(">", "");
            strtb = strtb.Replace("<", "");
            strtb = strtb.Replace("{", "");
            strtb = strtb.Replace("}", "");
            strtb = strtb.Replace("[", "");
            strtb = strtb.Replace("]", "");
            strtb = strtb.Replace("-", "");
            strtb = strtb.Replace("=", "");
            strtb = strtb.Replace(",", "");
            return strtb;
        }
        public static string subStr(string soursStr,int length)
        {
            if (soursStr.Length > length)
            {
                soursStr = soursStr.Substring(0, length);
            }
            return soursStr;
        }
        public static string subStrAddSlh(string soursStr, int length)
        {
            if (soursStr.Length > length)
            {
                soursStr = soursStr.Substring(0, length)+"...";
            }
            return soursStr;
        }
        public static string changHtml(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex10 = new System.Text.RegularExpressions.Regex(@"\d*", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=JavaScript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = regex10.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("< >", "");
            html = html.Replace("<strong>", "");
            html = html.Replace("：", "");
            html = html.Replace("“", "");
            html = html.Replace("”", "");
            html = html.Replace("(图)", "");
            html = html.Replace("[", "");
            html = html.Replace("]", "");
            html = html.Replace("　", "");
            html = html.Replace(" ", "");
            html = html.Replace("<<", "");
            html = html.Replace("<", "");
            html = html.Replace("(", "");
            html = html.Replace(">>", "");
            html = html.Replace(")", "");
            html = html.Replace(">", "");
            html = html.Replace("？", "");
            html = html.Replace("！", "");
            html = html.Replace("图", "");
            html = html.Replace("(", "");
            html = html.Replace(")", "");
            html = html.Replace("-", "");
            html = html.Replace("x", "");
            html = html.Replace(".", "");
            html = html.Replace("%", "");
            html = html.Replace("?", "");
            html = html.Replace("!", "");
            html = html.Replace("@", "");
            html = html.Replace("#", "");
            html = html.Replace("$", "");
            html = html.Replace("^", "");
            html = html.Replace("&", "");
            html = html.Replace("*", "");
            html = html.Replace("《", "");
            html = html.Replace("》", "");
            html = html.Replace(",", "");
            html = html.Replace("_", "");
            html = html.Replace("+", "");
            html = html.Replace("=", "");
            html = html.Replace("|", "");
            html = html.Replace("/", "");
            html = html.Replace(";", "");
            html = html.Replace("_", "");
            html = html.Replace(";", "");
            html = html.Replace("--", "");
            html = html.Replace("%20", "");
            html = html.Replace("==", "");
            html = html.Replace("~", "");
            html = html.Replace(".", "");
            html = html.Replace(",", "");
            html = html.Replace("`", "");
            html = html.Replace("{", "");
            html = html.Replace("}", "");
            html = html.Replace("『", "");
            html = html.Replace("』", "");
            html = html.Replace("【", "");
            html = html.Replace("】", "");
            html = html.Replace("（", "");
            html = html.Replace("）", "");
            html = html.Replace("·", "");
            html = html.Replace("《", "");
            html = html.Replace("》", "");
            html = html.Replace("&lt;", "");
            html = html.Replace("&gt;", "");
            html = html.Replace("——", "");
            html = html.Replace("----", "");
            html = html.Replace("&nbsp;", "");
            html = html.Replace("‘", "");
            html = html.Replace("’", "");
            html = html.Replace("：", "");
            html = html.Replace("lt", "");
            html = html.Replace("gt", "");
            html = html.Replace("nbsp", "");
            html = html.Replace("；", "");
            html = html.Replace("★", "");
            html = html.Replace("…", ""); ;
            html = html.Replace("☆", "");
            return html;
        }
    }


