using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachLawyer.UWP.Data
{
    public class Citys
    {
        /// <summary>
        /// 省份名
        /// </summary>
        private string _pro;
        /// <summary>
        /// 城市列表
        /// </summary>
        private List<string> _cityList=new List<string>();
        /// <summary>
        /// 省份
        /// </summary>
        public string Pro
        {
            get
            {
                return _pro;
            }

            set
            {
                _pro = value;
            }
        }
        /// <summary>
        /// 城市列表
        /// </summary>
        public List<string> CityList
        {
            get
            {
                return _cityList;
            }

            set
            {
                _cityList = value;
            }
        }
    }
}
