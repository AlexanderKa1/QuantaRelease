//using System;
//using AlexanderKa.QuantaRouter.WindowsStore.Common;
//using Bing.Maps;
//using Windows.Devices.Geolocation;
//using Windows.UI.Core;
//using Windows.UI.Xaml.Navigation;

//// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

//namespace AlexanderKa.QuantaRouter.WindowsStore.Views
//{
//    /// <summary>
//    ///     An empty page that can be used on its own or navigated to within a Frame.
//    /// </summary>
//    public sealed partial class MainMapView : LayoutAwarePage
//    {
//        private readonly Geolocator geolocator;
//        private Pushpin pushpin;

//        public MainMapView()
//        {
//            InitializeComponent();
//            geolocator = new Geolocator();
//            geolocator.PositionChanged += OnPositionChanged;
//        }


//        /// <summary>
//        ///     Raised when the location is updated.
//        /// </summary>
//        /// <param name="sender">The event source.</param>
//        /// <param name="args">The event data.</param>
//        private async void OnPositionChanged(Geolocator sender, PositionChangedEventArgs args)
//        {
//            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
//                {
//                    //Retrieve the Geolocation from Geolocator
//                    Geoposition geoposition = args.Position;
//                    //Create a new pushpin
//                    if (pushpin != null) return;
//                    pushpin = new Pushpin {Text = "Я"};
//                    //Add the pushpin
//                    map.Children.Add(pushpin);
//                    //Get the geolocation from windows 8 and convert to bing maps location
//                    var location = new Location(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
//                    //Set the position of the pushpin
//                    MapLayer.SetPosition(pushpin, location);
//                    //Zoom Bing Maps to location
//                    map.SetView(location, 14.0f);
//                });
//        }

//        /// <summary>
//        ///     Invoked when this page is about to be displayed in a Frame.
//        /// </summary>
//        /// <param name="e">
//        ///     Event data that describes how this page was reached.  The Parameter
//        ///     property is typically used to configure the page.
//        /// </param>
//        protected override void OnNavigatedTo(NavigationEventArgs e)
//        {
//        }
//    }
//}