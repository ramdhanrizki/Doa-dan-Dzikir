using Doa_dan_Dzikir.Helpers;
using Doa_dan_Dzikir.Model;
using Doa_dan_Dzikir.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Doa_dan_Dzikir.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewListDoa : Page
    {
        public ViewListDoa()
        {
            this.InitializeComponent();
            try
            {
               
                VMGetListDoa vmgetall = new VMGetListDoa();
                listDoa.DataContext = vmgetall;
                listviewDoa.DataContext = vmgetall;
            }
            catch(Exception e )
            {
                
            }
           
                  
        }

        private void listDoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goback();
            ModelDoa data = (sender as GridView).SelectedItem as ModelDoa;
            Navigation.idDoa = data.idDoa;
            Frame.Navigate(typeof(ViewDataDoa));
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

        private void listviewDow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
