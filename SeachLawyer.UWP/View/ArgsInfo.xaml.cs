using SeachLawyer.UWP.Model;
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
    public sealed partial class ArgsInfo : Page
    {
        public ArgsInfo()
        {
            this.InitializeComponent();
        }

        private Args _argsInfo = new Args();
        /// <summary>
        /// 辩词信息
        /// </summary>
        public Args ArgsInfoS
        {
            get
            {
                return _argsInfo;
            }

            set
            {
                _argsInfo = value;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            object[] parameters = e.Parameter as object[];
            if (parameters != null)
            {
                if (parameters.Length == 1 && (parameters[0] as Args) != null)
                {
                    ArgsInfoS = parameters[0] as Args;
                }
            }
        }
    }
}
