using System.ComponentModel.DataAnnotations;

namespace Hsl.Tools
{
    public class IPAttribute : ValidationAttribute
    {
        /// <summary>
        ///     验证IPv4地址是否合法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "IP地址不能为空！";
                return false;
            }

            var ip = value as string;

            if (ip.MatchInetAddress()) return true;
            ErrorMessage = "IP地址格式不正确，请输入有效的IPv4地址";
            return false;
        }
    }
}
