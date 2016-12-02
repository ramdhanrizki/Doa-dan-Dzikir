using Doa_dan_Dzikir.Helpers;
using Doa_dan_Dzikir.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Doa_dan_Dzikir
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(ViewListDoa));
            Home.IsSelected = true;
            //TitleTextBlock.Text = "Apa Doanya";
        }

        private void goback()
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                    Frame.GoBack();
                    a.Handled = true;

                }
            };

        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSplit.IsPaneOpen = !MenuSplit.IsPaneOpen;
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                MainFrame.Navigate(typeof(ViewListDoa));
            }
            else if (Video.IsSelected)
            {
                MainFrame.Navigate(typeof(ViewListVideo));
                goback();
            }
        }

        private void cari_Click(object sender, RoutedEventArgs e)
        {
            Navigation.query = txtCari.Text;
            MainFrame.Navigate(typeof(ViewCariDoa));
        }
    }
}

