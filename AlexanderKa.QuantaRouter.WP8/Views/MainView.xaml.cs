using Microsoft.Phone.Controls;

namespace CaliburnMicro.Views
{
    using System;
#if !WINDOWS_PHONE71
 using Yandex.Metrica;
#endif


    public partial class MainView : PhoneApplicationPage
    {
        // Constructor
        public MainView()
        {
            InitializeComponent();
            this.Loaded += MainView_Loaded;
            this.OrientationChanged+=OnOrientationChanged;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void MainView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
#if !WINDOWS_PHONE71
 Counter.Start(6493);
#endif

        }

        private void OnOrientationChanged(object sender, OrientationChangedEventArgs orientationChangedEventArgs)
        {
            if (orientationChangedEventArgs.Orientation == PageOrientation.Landscape || orientationChangedEventArgs.Orientation == PageOrientation.LandscapeLeft || orientationChangedEventArgs.Orientation == PageOrientation.LandscapeRight)
            {
                ScrollViewer.Height = this.ActualHeight - 100;
            }
            else
            {
                ScrollViewer.Height = this.ActualHeight - 100;
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}