using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SeachLawyer.UWP.Constant;
using SeachLawyer.UWP.HTTP;
using SeachLawyer.UWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using SeachLawyer.UWP.Data;
using Windows.UI.Popups;
using static SeachLawyer.UWP.Constant.ConstantValue;

namespace SeachLawyer.UWP.ViewModel
{
    public class SearchLawyerViewModel : ViewModelBase
    {
        public SearchLawyerViewModel()
        {
            GetProvince();
        }

        LawyerService lawyerService = new LawyerService();

        #region 属性
        private List<string> _proList = new List<string>();
        /// <summary>
        /// 省份列表
        /// </summary>
        public List<string> ProList
        {
            get
            {
                return _proList;
            }

            set
            {
                _proList = value;
                RaisePropertyChanged("ProList");
            }
        }

        private ObservableCollection<string> _cityList = new ObservableCollection<string>();
        /// <summary>
        /// 城市列表
        /// </summary>
        public ObservableCollection<string> CityList
        {
            get
            {
                return _cityList;
            }

            set
            {
                _cityList = value;
                RaisePropertyChanged("CityList");
            }
        }

        private string _selectedItemPro;
        /// <summary>
        /// 省份选择
        /// </summary>
        public string SelectedItemPro
        {
            get
            {
                return _selectedItemPro;
            }

            set
            {
                _selectedItemPro = value;
                GetCity(_selectedItemPro);
                RaisePropertyChanged("SelectedItemPro");
            }
        }

        private string _selectedItemCity;
        /// <summary>
        /// 城市选择
        /// </summary>
        public string SelectedItemCity
        {
            get
            {
                return _selectedItemCity;
            }

            set
            {
                _selectedItemCity = value;
                RaisePropertyChanged("SelectedItemCity");
            }
        }

        private string _phoneNum;
        /// <summary>
        /// 电话号
        /// </summary>
        public string PhoneNum
        {
            get
            {
                return _phoneNum;
            }

            set
            {
                _phoneNum = value;
                RaisePropertyChanged("PhoneNum");
            }
        }

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

        private ObservableCollection<Lawyer> _lawyerProList = new ObservableCollection<Lawyer>();
        /// <summary>
        /// 省份的律师列表
        /// </summary>
        public ObservableCollection<Lawyer> LawyerProList
        {
            get
            {
                return _lawyerProList;
            }

            set
            {
                _lawyerProList = value;
                RaisePropertyChanged("LawyerProList");
            }
        }

        private ObservableCollection<Lawyer> _lawyerCityList = new ObservableCollection<Lawyer>();
        /// <summary>
        /// 城市的律师列表
        /// </summary>
        public ObservableCollection<Lawyer> LawyerCityList
        {
            get
            {
                return _lawyerCityList;
            }

            set
            {
                _lawyerCityList = value;
                RaisePropertyChanged("LawyerCityList");
            }
        }

        private ObservableCollection<Lawyer> _lawyerPhoneList = new ObservableCollection<Lawyer>();
        /// <summary>
        /// 电话的律师列表
        /// </summary>
        public ObservableCollection<Lawyer> LawyerPhoneList
        {
            get
            {
                return _lawyerPhoneList;
            }

            set
            {
                _lawyerPhoneList = value;
                RaisePropertyChanged("LawyerPhoneList");
            }
        }

        private ObservableCollection<Lawyer> _lawyerNameList = new ObservableCollection<Lawyer>();
        /// <summary>
        /// 姓名的律师列表
        /// </summary>
        public ObservableCollection<Lawyer> LawyerNameList
        {
            get
            {
                return _lawyerNameList;
            }

            set
            {
                _lawyerNameList = value;
                RaisePropertyChanged("LawyerNameList");
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

        private LawyerList _lawyerProListOrg;

        private LawyerList _lawyerCityListOrg;

        private LawyerList _lawyerPhoneListOrg;

        private LawyerList _lawyerNameListOrg;

        #endregion

        #region 方法
        /// <summary>
        /// 获取省份
        /// 如果接口能取到，则用接口的，如果取不到，则用默认的
        /// </summary>
        private async void GetProvince()
        {
            try
            {
                if (ProList.Count <= 0)
                {
                    Info<string> info = await lawyerService.SearchProvince();
                    if (info.result.Count > 0)
                    {
                        ProList = info.result;
                    }
                    else
                    {
                        ProList = ConstantValue.ProvinceList;
                    }
                }
            }
            catch (Exception)
            {
                ProList = ConstantValue.ProvinceList;
            }
            finally
            {
                SelectedItemPro = ProList[0].ToString();
            }
        }

        /// <summary>
        /// 根据省份获得城市列表
        /// 如果接口能够取得，则用接口的，如果取不到，则从默认里获取
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        private async void GetCity(string pro)
        {
            CityList.Clear();
            try
            {
                ProgressRingVisibility = Visibility.Visible;
                Info<string> info = await lawyerService.SearchCityByProvince(pro);
                if (info.result.Count > 0)//判断接口是否获取到了城市
                {
                    CityList = new ObservableCollection<string>(info.result);
                }
                else
                {
                    CityList = new ObservableCollection<string>(ConstantValue.CityList.Where(p => p.Pro == pro).First().CityList);
                }
            }
            catch (Exception)
            {
                CityList = new ObservableCollection<string>(ConstantValue.CityList.Where(p => p.Pro == pro).First().CityList);
            }
            finally
            {
                SelectedItemCity = CityList[0].ToString();
                ProgressRingVisibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 获取省份律师
        /// </summary>
        private async void GetProLawyer()
        {
            if (string.IsNullOrEmpty(SelectedItemPro))
            {
                await (new MessageDialog("省份不能为空，请等待……")).ShowAsync();
                return;
            }
            LawyerProList = _lawyerProListOrg = new Model.LawyerList(Method.LawyerByProvince,SelectedItemPro);
            _lawyerProListOrg.DataLoaded += _lawyerListOrg_DataLoaded;
            _lawyerProListOrg.DataLoading += _lawyerListOrg_DataLoading;

        }
        /// <summary>
        /// 获取城市律师
        /// </summary>
        private async void GetCityLawyer()
        {
            if (string.IsNullOrEmpty(SelectedItemCity))
            {
                await (new MessageDialog("城市不能为空，请等待……")).ShowAsync();
                return;
            }
            LawyerCityList = _lawyerCityListOrg = new LawyerList(Method.LawyerByCity,SelectedItemCity);
            _lawyerCityListOrg.DataLoaded += _lawyerListOrg_DataLoaded;
            _lawyerCityListOrg.DataLoading += _lawyerListOrg_DataLoading;
        }
        /// <summary>
        /// 获取电话律师
        /// </summary>
        private async void GetPhoneLawyer()
        {
            if (string.IsNullOrEmpty(PhoneNum))
            {
                await (new MessageDialog("电话号码不能为空，请填写！")).ShowAsync();
                return;
            }
            LawyerPhoneList = _lawyerPhoneListOrg = new LawyerList(Method.LawyerByPhone, PhoneNum);
            _lawyerPhoneListOrg.DataLoaded += _lawyerListOrg_DataLoaded;
            _lawyerPhoneListOrg.DataLoading += _lawyerListOrg_DataLoading;
        }
        /// <summary>
        /// 获取姓名律师
        /// </summary>
        private async void GetNameLawyer()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await (new MessageDialog("姓名不能为空，请填写！")).ShowAsync();
                return;
            }
            LawyerNameList = _lawyerNameListOrg = new LawyerList(Method.LawyerByName, Name);
            _lawyerNameListOrg.DataLoaded += _lawyerListOrg_DataLoaded;
            _lawyerNameListOrg.DataLoading += _lawyerListOrg_DataLoading;
        }
        private void _lawyerListOrg_DataLoading()
        {
            ProgressRingVisibility = Visibility.Visible;
        }
        private void _lawyerListOrg_DataLoaded()
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
                        case Method.LawyerByCity:
                            GetCityLawyer();
                            break;
                        case Method.LawyerByProvince:
                            GetProLawyer();
                            break;
                        case Method.LawyerByPhone:
                            GetPhoneLawyer();
                            break;
                        case Method.LawyerByName:
                            GetNameLawyer();
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
