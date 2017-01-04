using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachLawyer.UWP.Constant
{
    public class ConstantValue
    {
        /// <summary>
        /// APPKEY
        /// </summary>
        public const string AppKey = "378a9fb09fbf6f2259be5306254cd6bc";

        /// <summary>
        /// 返回的数据格式
        /// </summary>
        public const string dtype = "json";

        /// <summary>
        /// 开始数
        /// </summary>
        public const int st = 0;

        /// <summary>
        /// 返回的个数
        /// </summary>
        public const int count = 10;

        /// <summary>
        /// 错误列表
        /// </summary>
        public static Dictionary<int, string> Error = new Dictionary<int, string>()
        {
            {208300, "网络异常"},
            {208301, "缺少参数"},
            {208302, "无查询结果"},
            {10001, "错误的请求KEY"},
            {10002, "该KEY无请求权限"},
            {10003, "KEY过期"},
            {10004, "错误的OPEN ID"},
            {10005, "应用未审核超时，请提交认证"},
            {10007, "未知的请求源"},
            {10008, "被禁止的IP"},
            {10009, "被禁止的KEY"},
            {10011, "当前IP的请求超过限制"},
            {10012, "请求超过次数限制"},
            {10013, "测试KEY超过请求限制"},
            {10014, "系统内部异常"},
            {10020, "接口维护"},
            {10021, "接口停用"}
        };
        /// <summary>
        /// 省份列表
        /// </summary>
        public static List<string> ProvinceList = new List<string>()
        {
            "北京",
            "江苏",
            "河南",
            "广东",
            "上海",
            "天津",
            "重庆",
            "湖北",
            "四川",
            "陕西",
            "河北",
            "山西",
            "吉林",
            "黑龙江",
            "内蒙古",
            "山东",
            "浙江",
            "福建",
            "湖南",
            "江西",
            "贵州",
            "甘肃",
            "青海",
            "新疆",
            "香港",
            "辽宁",
            "安徽",
            "海南",
            "广西",
            "云南",
            "宁夏",
            "西藏",
            "台湾"
        };
        /// <summary>
        /// 城市列表
        /// </summary>
        public static List<Data.Citys> CityList = new List<Data.Citys>();
        /// <summary>
        /// 查询类型
        /// </summary>        
    }
    public enum Method
    {
        LawyerByCity,
        LawyerByProvince,
        LawyerByPhone,
        LawyerByRand,
        LawyerByName,
        ArgsByName,
        ArgsByTerm,
        ArgsByRand
    }
}
