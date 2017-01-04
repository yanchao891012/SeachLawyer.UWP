using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace HttpHelper
{
    public static class BaseService
    {
        /// <summary>
        /// 访问服务器时的Cookies
        /// </summary>
        public static CookieContainer CookiesContainer;
        /// <summary>
        /// 向服务器发送GET请求 返回服务器回复的数据
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public async static Task<string> SendGetRequest(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(url));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
                throw(ex);
            }
        }
        /// <summary>
        /// 向服务器发送POST请求，返回服务器回复数据
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="body">报文体</param>
        /// <returns></returns>
        public async static Task<string> SendPostRequest(string url,string body)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync(new Uri(url), new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("", body) }));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
                throw(ex);
            }
        }
    }
}
