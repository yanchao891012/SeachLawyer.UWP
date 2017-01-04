using SeachLawyer.UWP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Calls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class LawyerInfo : Page
    {
        public LawyerInfo()
        {
            this.InitializeComponent();
        }

        private Lawyer lawyerInfo = new Lawyer();
        /// <summary>
        /// 律师信息
        /// </summary>
        public Lawyer LawyersInfo
        {
            get
            {
                return lawyerInfo;
            }

            set
            {
                lawyerInfo = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            object[] parameters = e.Parameter as object[];
            if (parameters!=null)
            {
                if (parameters.Length==1 && (parameters[0] as Lawyer)!=null)
                {
                    LawyersInfo = parameters[0] as Lawyer;
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
        /// <summary>
        /// 调用电话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallManager.ShowPhoneCallUI((sender as HyperlinkButton).Content.ToString(), "电话");            
        }
        /// <summary>
        /// 调用邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri($"mailto:"+(sender as HyperlinkButton).Content.ToString()+""));
        }
    }
}
