using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AlexanderKa.QuantaRouter.WindowsStore.Views
{
    using AlexanderKa.QuantaRouter.WindowsStore.Common;

    using Windows.UI;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainView : LayoutAwarePage
    {
        public MainView()
        {
            this.InitializeComponent();
            this.Loaded += MainView_Loaded;
        }

        void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= MainView_Loaded;
        
        }

      

        private async void DoOperation(IUICommand command)
        {
            Uri uri = new Uri("https://mega.co.nz/#!4ApSQAoK!e4z1HjtG7KO5zGTCZmT65CLkfjYxlxxPhQ5vEGcJFd0");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        

      
    }
}
