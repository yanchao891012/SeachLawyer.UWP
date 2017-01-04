using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachLawyer.UWP.Model
{
    /// <summary>
    /// 辩词
    /// </summary>
    class Args
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string pdate { get; set; }
        /// <summary>
        /// 律师
        /// </summary>
        public string lawer { get; set; }
    }
}
