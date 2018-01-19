using System.Text;
using RestSharp.Extensions.MonoHttp;

namespace Edu.Infrastructure.Helper
{
    public static class CSTEncodeHelper
    {
        /// <summary>
        /// URL编码 utf-8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(this string str)
        {
            return HttpUtility.UrlEncode(str, Encoding.UTF8);
        }
        /// <summary>
        /// URL解码 utf-8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DeEncode(this string str)
        {
            return HttpUtility.UrlDecode(str, Encoding.UTF8);
        }
    }
}
