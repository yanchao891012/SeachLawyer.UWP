using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachLawyer.UWP.Model
{
    public class Info<T>
    {
        /// <summary>
        /// 成功的返回
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// 返回的内容
        /// </summary>
        public List<T> result { get; set; }
        /// <summary>
        /// 错误信息ID
        /// </summary>
        public int error_code { get; set; }
    }
}
