using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace HttpHelper
{
    /// <summary>
    /// Json返回结果
    ///说明：必须要重写ErrorMess，否则没有错误返回消息
    /// </summary>
    public abstract class ResultInfoHelper
    {
        /// <summary>
        /// 传入URL和参数，解析返回Json信息，并返回结果
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="_url">URl地址</param>
        /// <param name="args">相关参数</param>
        /// <returns></returns>
        public async Task<T> GetResultInfoGetHelper<T>(string _url,params object[] args)
        {
            string url = string.Format(_url, args);
            string resultUrl = await BaseService.SendGetRequest(url);
            ErrorMess<T>(resultUrl);
            T resultList = JsonConvert.DeserializeObject<T>(resultUrl);
            return resultList;
        }
        /// <summary>
        /// 传入URL和Body，解析返回Json信息，并返回结果
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="_url">URL地址</param>
        /// <param name="body">传入Body</param>
        /// <returns></returns>
        public async Task<T> GetResultInfoPostHelper<T>(string _url,string body)
        {
            string resultUrl = await BaseService.SendPostRequest(_url, body);
            ErrorMess<T>(resultUrl);
            T resultList = JsonConvert.DeserializeObject<T>(resultUrl);
            return resultList;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultUrl"></param>
        protected abstract void ErrorMess<T>(string resultUrl);
        
    }
}
