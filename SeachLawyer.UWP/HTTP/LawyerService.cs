using SeachLawyer.UWP.Constant;
using SeachLawyer.UWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachLawyer.UWP.HTTP
{
    /// <summary>
    /// 接口服务类
    /// </summary>
    class LawyerService
    {
        GetInfoHelper<Lawyer> getLawyerInfo = new GetInfoHelper<Lawyer>();
        GetInfoHelper<Args> getArgsInfo = new GetInfoHelper<Args>();
        GetInfoHelper<string> getStringInfo = new GetInfoHelper<string>();
        /// <summary>
        /// 按省份查询律师信息
        /// </summary>
        static string _url_SearchLawyerByProvince = "http://op.juhe.cn/lawyers/pro?pro={0}&key={1}&dtype={2}&st={3}&count={4}";
        /// <summary>
        /// 按省份查询律师信息
        /// </summary>
        /// <param name="pro">省份</param>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="st"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Lawyer>> SearchLawyerByProvince(string pro, int st = ConstantValue.st, string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Lawyer> info = await getLawyerInfo.GetResultInfoGetHelper<Info<Lawyer>>(_url_SearchLawyerByProvince, pro, key, dtype, st, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 按城市查询律师信息
        /// </summary>
        static string _url_SearchLawyerByCity = "http://op.juhe.cn/lawyers/city?city={0}&key={1}&dtype={2}&st={3}&count={4}";
        /// <summary>
        /// 按城市查询律师信息
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="st"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Lawyer>> SearchLawyerByCity(string city, int st = ConstantValue.st, string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Lawyer> info = await getLawyerInfo.GetResultInfoGetHelper<Info<Lawyer>>(_url_SearchLawyerByCity, city, key, dtype, st, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 按照相似姓名查询律师
        /// </summary>
        static string _url_SearchLawyerByName = "http://op.juhe.cn/lawyers/name?name={0}&key={1}&dtype={2}&st={3}&count={4}";
        /// <summary>
        /// 按照相似姓名查询律师
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="st"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Lawyer>> SearchLawyerByName(string name, int st = ConstantValue.st, string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Lawyer> info = await getLawyerInfo.GetResultInfoGetHelper<Info<Lawyer>>(_url_SearchLawyerByName, name, key, dtype, st, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 随机查询律师
        /// </summary>
        static string _url_SearchLawyerByRand = "http://op.juhe.cn/lawyers/rand?key={0}&dtype={1}&count={2}";
        /// <summary>
        /// 随机查询律师
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Lawyer>> SearchLawyerByRand(string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Lawyer> info = await getLawyerInfo.GetResultInfoGetHelper<Info<Lawyer>>(_url_SearchLawyerByRand, key, dtype, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 按手机号码查询律师
        /// </summary>
        static string _url_SearchLawyerByMobile = "http://op.juhe.cn/lawyers/mobile?mobile={0}&key={1}&dtype={2}&st={3}&count={4}";
        /// <summary>
        /// 按手机号码查询律师
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="st"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Lawyer>> SearchLawyerByMobile(string mobile, int st = ConstantValue.st, string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Lawyer> info = await getLawyerInfo.GetResultInfoGetHelper<Info<Lawyer>>(_url_SearchLawyerByMobile, mobile, key, dtype, st, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 由省份查询城市
        /// </summary>
        static string _url_SeachCityByProvince = "http://op.juhe.cn/lawyers/citiesByPro?pro={0}&key={1}&dtype={2}";
        /// <summary>
        /// 由省份查询城市
        /// </summary>
        /// <param name="pro">省份</param>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public async Task<Info<string>> SearchCityByProvince(string pro, string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype)
        {
            try
            {
                Info<string> info = await getStringInfo.GetResultInfoGetHelper<Info<string>>(_url_SeachCityByProvince, pro, key, dtype);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 查询专业领域
        /// </summary>
        static string _url_SearchSpec = "http://op.juhe.cn/lawyers/specs?key={0}&dtype={1}";
        /// <summary>
        /// 查询专业领域
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public async Task<Info<string>> SearchSpec(string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype)
        {
            try
            {
                Info<string> info = await getStringInfo.GetResultInfoGetHelper<Info<string>>(_url_SearchSpec, key, dtype);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 查询省份列表
        /// </summary>
        static string _url_SearchProvince = "http://op.juhe.cn/lawyers/pros?key={0}&dtype={1}";
        /// <summary>
        /// 查询省份列表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public async Task<Info<string>> SearchProvince(string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype)
        {
            try
            {
                Info<string> info = await getStringInfo.GetResultInfoGetHelper<Info<string>>(_url_SearchProvince, key, dtype);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 按律师姓名查询辩词
        /// </summary>
        static string _url_SearchArgsByName = "http://op.juhe.cn/lawyers/argsByName?name={0}&key={1}&dtype={2}&st={3}&count={4}";
        /// <summary>
        /// 按律师姓名查询辩词
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="st"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Args>> SearchArgsByName(string name, int st = ConstantValue.st, string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Args> info = await getArgsInfo.GetResultInfoGetHelper<Info<Args>>(_url_SearchArgsByName, name, key, dtype, st, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 按关键词查询律师辩词
        /// </summary>
        static string _url_SearchArgsByTerm = "http://op.juhe.cn/lawyers/argsByTerm?term={0}&key={1}&dtype={2}&st={3}&count={4}";
        /// <summary>
        /// 按关键词查询律师辩词
        /// </summary>
        /// <param name="term">关键词</param>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="st"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Args>> SearchArgsByTerm(string term, int st = ConstantValue.st, string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Args> info = await getArgsInfo.GetResultInfoGetHelper<Info<Args>>(_url_SearchArgsByTerm, term, key, dtype, st, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
        /// <summary>
        /// 随机查询律师辩词
        /// </summary>
        static string _url_SearchArgsByRand = "http://op.juhe.cn/lawyers/argsByRand?key={0}&dtype={1}&count={2}";
        /// <summary>
        /// 随机查询律师辩词
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<Info<Args>> SearchArgsByRand(string key = ConstantValue.AppKey, string dtype = ConstantValue.dtype, int count = ConstantValue.count)
        {
            try
            {
                Info<Args> info = await getArgsInfo.GetResultInfoGetHelper<Info<Args>>(_url_SearchArgsByRand, key, dtype, count);
                return info;
            }
            catch (Exception ex)
            {
                return null;
                throw (ex);
            }
        }
    }
}
