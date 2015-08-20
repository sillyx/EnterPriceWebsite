using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace sniper.service
{
    public static class Extensions
    {
        public static string NewGuid()
        {
            return Guid.NewGuid().ToSafeTrim().Replace("-", "");
        }

        /// <summary>
        /// 判断字一个字符串是否为Empty或者Null,是返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool NotNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) ? false : true;
        }
        /// <summary>
        /// 将object类型转换为安全的String类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSafeTrim(this object str)
        {
            if (str == null)
                return string.Empty;
            return str.ToString().Trim();
        }
        /// <summary>
        /// 将object类型转换为安全的Int类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ToInt(this object param)
        {
            int r = default(int);
            try
            {
                int.TryParse(param.ToSafeTrim(), out r);
                return r;
            }
            catch
            {
                return r;
            }

        }
        /// <summary>
        /// 将Decimal类型转换为￥100的格式
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string FormatMoney(this decimal price)
        {
            return String.Format("￥{0}", price);
        }
        /// <summary>
        /// 将object类型转换为安全的Double类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static double ToDouble(this object param)
        {
            double r = default(double);
            try
            {
                double.TryParse(param.ToSafeTrim(), out r);
                return r;
            }
            catch { return r; }

        }
        /// <summary>
        /// 将object类型转换为安全的Decimal类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object param)
        {
            decimal r = default(decimal);
            try
            {
                decimal.TryParse(param.ToSafeTrim(), out r);
                return r;
            }
            catch { return r; }
        }
        /// <summary>
        /// 将object类型转换为安全的Float类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static float ToFloat(this object param)
        {
            float r = default(float);
            try
            {
                float.TryParse(param.ToSafeTrim(), out r);
                return r;
            }
            catch { return r; }
        }
        /// <summary>
        /// 将Ojbect类型转换为安全的DateTime类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj)
        {
            DateTime dateTime = default(DateTime);
            DateTime.TryParse(obj.ToSafeTrim(), out dateTime);
            return dateTime;
        }
        /// <summary>
        /// 根据指定长度截取字符串
        /// </summary>
        /// <param name="target"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string CutString(this string target, int maxLength)
        {
            if (null == target
                || 0 == target.Length
                || maxLength < 1)
                return String.Empty;

            if (target.Length > maxLength)
                return System.Web.HttpUtility.HtmlEncode(target.Substring(0, maxLength)) + "...";

            return System.Web.HttpUtility.HtmlEncode(target);
        }
        /// <summary>
        /// 比较俩个字符串，不区分大小写
        /// </summary>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns></returns>
        public static bool CompareIgnoreCase(this string strA, string strB)
        {
            return string.Compare(strA, strB, true) == 0 ? true : false;
        }
        /// <summary>
        /// 比较俩个字符串，区分大小写
        /// </summary>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns></returns>
        public static bool CompareNotIgnoreCase(this string strA, string strB)
        {
            return string.Compare(strA, strB, false) == 0 ? true : false;
        }
        /// <summary>
        /// 将一个object类型的数据序列化为Json对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
        /// <summary>
        /// 返回带长度的Json对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, int count)
        {
            string template = "\"total\":{0},\"rows\":{1}";
            if (count == 0)
            {
                return "{" + string.Format(template, 0, "[]") + "}";
            }
            else
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return "{" + string.Format(template, count, serializer.Serialize(obj)) + "}";
            }
        }
        /// <summary>
        /// 转换成Char类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static char ToChar(this object obj)
        {
            char result = default(char);
            Char.TryParse(obj.ToSafeTrim(), out result);
            return result;
        }
        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToMD5(this object obj)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(obj.ToSafeTrim(), "MD5");
        }
        /// <summary>
        /// base64加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodeBase64(this string str)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(str));
        }
        /// <summary>
        /// base64解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecodeBase64(this string str)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(str));
        }
        /// <summary>
        /// 判断是否为Int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsInt(this object obj)
        {
            int r = default(int);
            return int.TryParse(obj.ToSafeTrim(), out r);
        }
        /// <summary>
        /// 利用正则表达式验证格式
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsAnyFormat(this object obj, string pattern)
        {
            return Regex.IsMatch(obj.ToSafeTrim(), pattern);
        }

        /// <summary>
        /// 选择题选项设置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SetItemName(this int obj)
        {
            switch (obj.ToSafeTrim())
            {
                case "0":
                    return "A";
                case "1":
                    return "B";
                case "2":
                    return "C";
                case "3":
                    return "D";
                case "4":
                    return "E";
                default:
                    return null;
            }
        }

        /// <summary>
        /// 判断题
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SetPanDuan(this int obj)
        {
            switch (obj.ToSafeTrim())
            {
                case "0":
                    return "对";
                case "1":
                    return "错";
                default:
                    return null;
            }
        }


        /// <summary>
        /// 获取试题题型
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public static int ConvertQuestionType(this string questionType)
        {
            int type = default(int);
            switch (questionType)
            {
                case "单选题":
                    type = 0;
                    break;
                case "多选题":
                    type = 1;
                    break;
                case "判断题":
                    type = 2;
                    break;
                case "分析题":
                    type = 3;
                    break;
                case "填空题":
                    type = 4;
                    break;
                default:
                    type = 0;
                    questionType = "单选题";
                    break;
            }
            return type;
        }


        public static string ConvertTypeToName(this string type)
        {
            switch (type)
            {
                case "0":
                    return "单选题";
                case "1":
                    return "多选题";
                case "2":
                    return "判断题";
                case "3":
                    return "分析题";
                case "4":
                    return "填空题";
                default:
                    return "未知题型";
            }

        }

        /// <summary>
        /// 设置题型序号
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertQuestionNumber(this int number)
        {
            switch (number)
            {
                case 1:
                    return "一";
                case 2:
                    return "二";
                case 3:
                    return "三";
                case 4:
                    return "四";
                case 5:
                    return "五";
                case 6:
                    return "六";
                case 7:
                    return "七";
                default:
                    return "NaN";
            }
        }

        public static string GetYear(this string dateTime, float minutes)
        {
            try
            {
                var date = DateTime.Parse(dateTime);
                var lastDate = date.AddMinutes(minutes);
                return lastDate.Year.ToSafeTrim();
            }
            catch { return string.Empty; }
        }
        public static string GetMonth(this string dateTime, float minutes)
        {
            try
            {
                var date = DateTime.Parse(dateTime);
                var lastDate = date.AddMinutes(minutes);
                return lastDate.Month.ToSafeTrim();
            }
            catch { return string.Empty; }
        }
        public static string GetDay(this string dateTime, float minutes)
        {
            try
            {
                var date = DateTime.Parse(dateTime);
                var lastDate = date.AddMinutes(minutes);
                return lastDate.Day.ToSafeTrim();
            }
            catch { return string.Empty; }
        }
        public static string GetMinute(this string dateTime, float minutes)
        {
            try
            {
                var date = DateTime.Parse(dateTime);
                var lastDate = date.AddMinutes(minutes);
                return lastDate.Minute.ToSafeTrim();
            }
            catch { return string.Empty; }
        }


        public static string GetHour(this string dateTime, float minutes)
        {
            try
            {
                var date = DateTime.Parse(dateTime);
                var lastDate = date.AddMinutes(minutes);
                return lastDate.Hour.ToSafeTrim();
            }
            catch { return string.Empty; }
        }

        public static string GetSecond(this string dateTime, float minutes)
        {
            try
            {
                var date = DateTime.Parse(dateTime);
                var lastDate = date.AddMinutes(minutes);
                return lastDate.Second.ToSafeTrim();
            }
            catch { return string.Empty; }
        }

        public static string GetDateFormat(this object dateTime)
        {
            try
            {
                var date = DateTime.Parse(dateTime.ToSafeTrim());
                return date.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch { return string.Empty; }
        } 
    }
}

