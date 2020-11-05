using System.Net;

namespace Hsl.Tools
{
    public static class StringEx
    {
        #region IP地址

        /// <summary>
        ///     校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns>
        public static IPAddress MatchInetAddress(this string s, out bool isMatch)
        {
            IPAddress ip;
            isMatch = IPAddress.TryParse(s, out ip);
            return ip;
        }

        /// <summary>
        ///     校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool MatchInetAddress(this string s)
        {
            bool success;
            MatchInetAddress(s, out success);
            return success;
        }

        #endregion IP地址
    }
}