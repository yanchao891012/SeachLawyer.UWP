using SeachLawyer.UWP.Data;
using SeachLawyer.UWP.HTTP;
using SeachLawyer.UWP.Model;
using SeachLawyer.UWP.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace SeachLawyer.UWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            mainNavigationList.SelectedIndex = 1;
           // test();
        }

        public async void test()
        {
            XDocument xdoc = XDocument.Load("Constant/Pro_City.xml");
            List<Citys> citysList = new List<Citys>();
            foreach (XElement rootElement in xdoc.Descendants("Province"))
            {
                Citys citys = new Citys();
                citys.Pro = (string)rootElement.Element("pro_name");
                XElement nodesElement = rootElement.Element("City");
                foreach (XElement nodeElement in nodesElement.Elements("city_name"))
                {
                    citys.CityList.Add(nodeElement.Value);
                }
                citysList.Add(citys);
            }
        }

        int _preSelectNavigation = -1;

        private async void mainNavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem tapped_item = mainNavigationList.SelectedItems[0] as ListBoxItem;

            if (tapped_item != null && tapped_item.Tag != null)
            {
                mainSplitView.IsPaneOpen = false;
                _preSelectNavigation = mainNavigationList.SelectedIndex;
                if (tapped_item.Tag.ToString().Equals("1"))
                {
                    mainFrame.Navigate(typeof(HomePage));
                }
                //查找律师
                if (tapped_item.Tag.ToString().Equals("2"))
                {
                    mainFrame.Navigate(typeof(SearchLawyerPage));
                }
                //查找辩词
                if (tapped_item.Tag.ToString().Equals("3"))
                {
                    mainFrame.Navigate(typeof(SearchArgsPage));
                }

                if (tapped_item.Tag.ToString().Equals("4"))
                {
                    AboutPage about = new AboutPage();
                    await about.ShowAsync();
                }
            }
        }
        /// <summary>
        /// 导航栏显隐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListBoxItem tapped_item = sender as ListBoxItem;
            if (tapped_item != null && tapped_item.Tag != null && tapped_item.Tag.ToString().Equals("0"))
            {
                mainSplitView.IsPaneOpen = !mainSplitView.IsPaneOpen;
            }
        }
    }
}
