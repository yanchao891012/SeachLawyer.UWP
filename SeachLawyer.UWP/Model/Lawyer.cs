using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachLawyer.UWP.Model
{
    /// <summary>
    /// 律师基本信息
    /// </summary>
    public class Lawyer
    {
        /// <summary>
        /// 专长领域
        /// </summary>
        public string spec { get; set; }
        /// <summary>
        /// 座机
        /// </summary>
        public string tel { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string img { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string addr { get; set; }
        /// <summary>
        /// 执业机构
        /// </summary>
        public string corp { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desp { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 称谓
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 执业证号
        /// </summary>
        public string idno { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string qq { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }

    }
}
