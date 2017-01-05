using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeachLawyer.UWP.ViewModel
{
    public class VMLocator
    {
        /// <summary>
        /// 上锁
        /// </summary>
        private static readonly object SynObject = new object();

        private static VMLocator _instance;
        /// <summary>
        /// ViewModel实例控制器
        /// </summary>
        public static VMLocator Instance
        {
            get
            {
                if (_instance==null)
                {
                    lock (SynObject)
                        _instance = new VMLocator();
                }
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        private HomeViewModel _homeVM;
        /// <summary>
        /// 主页面View Model
        /// </summary>
        public HomeViewModel HomeVM
        {
            get
            {
                return _homeVM ?? (_homeVM = new HomeViewModel());
            }
        }

        private SearchLawyerViewModel _searchLawyerVM;
        /// <summary>
        /// 查询律师页面ViewModel
        /// </summary>
        public SearchLawyerViewModel SearchLawyerVM
        {
            get
            {
                return _searchLawyerVM ?? (_searchLawyerVM = new SearchLawyerViewModel());
            }
        }

        private SearchArgsViewModel _searchArgsVM;
        /// <summary>
        /// 查询辩词页面ViewModel
        /// </summary>
        public SearchArgsViewModel SearchArgsVM
        {
            get
            {
                return _searchArgsVM ?? (_searchArgsVM = new SearchArgsViewModel());
            }
        }
    }
}
