using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpHelper;
using Newtonsoft.Json;
using SeachLawyer.UWP.Model;
using Windows.UI.Popups;

namespace SeachLawyer.UWP.HTTP
{
    public class GetInfoHelper<M> : ResultInfoHelper
    {
        /// <summary>
        /// 重写错误方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultUrl"></param>
        protected override async void ErrorMess<T>(string resultUrl)
        {
            if (typeof(T).Name==typeof(Info<M>).Name)
            {
                Info<M> error = JsonConvert.DeserializeObject<Info<M>>(resultUrl);
                if (error.error_code != 0)
                {
                    await (new MessageDialog("错误代码：" + error.error_code + "\r\n" + "错误信息：" + Constant.ConstantValue.Error[error.error_code])).ShowAsync();
                    return;
                }
            }
        }
    }
}
