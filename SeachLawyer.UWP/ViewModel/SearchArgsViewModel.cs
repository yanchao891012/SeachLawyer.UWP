using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SeachLawyer.UWP.Constant;
using SeachLawyer.UWP.HTTP;
using SeachLawyer.UWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace SeachLawyer.UWP.ViewModel
{
    public class SearchArgsViewModel: ViewModelBase
    {
        LawyerService lawyerSevice = new LawyerService();
        #region 属性
        private string _name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _tags;
        /// <summary>
        /// 关键词
        /// </summary>
        public string Tags
        {
            get
            {
                return _tags;
            }

            set
            {
                _tags = value;
                RaisePropertyChanged("Tags");
            }
        }

        private ObservableCollection<Args> _argsNameList = new ObservableCollection<Args>();
        /// <summary>
        /// 姓名的辩词列表
        /// </summary>
        public ObservableCollection<Args> ArgsNameList
        {
            get
            {
                return _argsNameList;
            }

            set
            {
                _argsNameList = value;
                RaisePropertyChanged("ArgsNameList");
            }
        }
        private ObservableCollection<Args> _argsTagList = new ObservableCollection<Args>();
        /// <summary>
        /// 关键词的辩词列表
        /// </summary>
        public ObservableCollection<Args> ArgsTagList
        {
            get
            {
                return _argsTagList;
            }

            set
            {
                _argsTagList = value;
                RaisePropertyChanged("ArgsTagList");
            }
        }

        private Visibility _progressRingVisibility = Visibility.Collapsed;
        /// <summary>
        /// 等待是否隐藏
        /// </summary>
        public Visibility ProgressRingVisibility
        {
            get
            {
                return _progressRingVisibility;
            }

            set
            {
                _progressRingVisibility = value;
                RaisePropertyChanged("ProgressRingVisibility");
            }
        }

        private ArgsList _argsNameListOrg;

        private ArgsList _argsTagListOrg;
        #endregion
        #region 方法
        /// <summary>
        /// 获取姓名辩词
        /// </summary>
        private async void GetNameArgs()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await (new MessageDialog("姓名不能为空，请填写！")).ShowAsync();
                return;
            }
            ArgsNameList = _argsNameListOrg = new ArgsList(Constant.Method.ArgsByName, Name);
            _argsNameListOrg.DataLoaded += _argsListOrg_DataLoaded;
            _argsNameListOrg.DataLoading += _argsListOrg_DataLoading;
        }
        /// <summary>
        /// 获取关键词辩词
        /// </summary>
        private async void GetTagsArgs()
        {
            if (string.IsNullOrEmpty(Tags))
            {
                await (new MessageDialog("关键词不能为空，请填写！")).ShowAsync();
                return;
            }
            ArgsTagList = _argsTagListOrg = new ArgsList(Constant.Method.ArgsByTerm, Tags);
            _argsTagListOrg.DataLoaded += _argsListOrg_DataLoaded;
            _argsTagListOrg.DataLoading += _argsListOrg_DataLoading;
        }

        private void _argsListOrg_DataLoading()
        {
            ProgressRingVisibility = Visibility.Visible;
        }

        private void _argsListOrg_DataLoaded()
        {
            ProgressRingVisibility = Visibility.Collapsed;
        }
        #endregion

        #region 按钮
        private RelayCommand<Method> _searchCommand;
        /// <summary>
        /// 查询按钮
        /// </summary>
        public RelayCommand<Method> SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new RelayCommand<Method>(p =>
                {
                    switch (p)//根据传入的参数，判别是哪个按钮触发的
                    {
                        case Method.ArgsByName:
                            GetNameArgs();
                            break;
                        case Method.ArgsByTerm:
                            GetTagsArgs();
                            break;
                        default:
                            break;
                    }
                }));
            }
        }
        #endregion
    }
}
