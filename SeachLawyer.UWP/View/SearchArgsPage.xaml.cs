using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace SeachLawyer.UWP.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SearchArgsPage : Page
    {
        public SearchArgsPage()
        {
            this.InitializeComponent();
        }

        private void pivotArgs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ArgsInfo), new object[] { e.ClickedItem });
        }
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode==NavigationMode.Back)
            {
                if (App.PageState!=null && App.PageState["SearchArgsPage_PivotSelectIndex"]!=null)
                {
                    pivotArgs.SelectedIndex = (int)App.PageState["SearchArgsPage_PivotSelectIndex"];
                }
            }
        }
        /// <summary>
        /// 页面离开
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (App.PageState==null)
            {
                App.PageState = new Dictionary<string, object>();
            }
            App.PageState.Remove("SearchArgsPage_PivotSelectIndex");
            App.PageState.Add("SearchArgsPage_PivotSelectIndex", pivotArgs.SelectedIndex);
        }
    }
}
