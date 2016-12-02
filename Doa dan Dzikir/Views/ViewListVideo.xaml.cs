using Doa_dan_Dzikir.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Doa_dan_Dzikir.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewListVideo : Page
    {
        public ViewListVideo()
        {
            this.InitializeComponent();
            string videoID = "VgY1r23Fr0s";
            string html = @"<iframe width=""800"" height=""480"" src=""http://www.youtube.com/embed/" + videoID + @"?rel=0"" frameborder=""0"" allowfullscreen></iframe>";
            VMGetVideo vmgetvideo = new VMGetVideo();
            listVideo.DataContext = vmgetvideo;
            
        }

        private void listVideo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
