using System.Diagnostics;
using System.Threading.Tasks;
using AlexanderKa.QuantaRouter.PCL.Interfaces;
using Windows.Devices.Geolocation;

namespace AlexanderKa.QuantaRouter.WindowsStore.Classes
{
    public class GeoLocatorExtension : IGeoLocator
    {
        private GeoPosition _geoPosition;
        private Geolocator _geolocator;

        public GeoLocatorExtension()
        {
            Task.Run(() =>
                {
                    _geoPosition = new GeoPosition();
                    _geolocator = new Geolocator();
                    _geolocator.PositionChanged += _geolocator_PositionChanged;
                    _geolocator.GetGeopositionAsync();
                });
        }

        public Task<GeoPosition> GetGeoPositionAsync()
        {
            GeoPosition result = _geoPosition;
            Task<GeoPosition> task3 = Task<GeoPosition>.Factory.StartNew(() => result);
            return task3;
        }

        private void _geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            _geoPosition.Accuracy = args.Position.Coordinate.Accuracy;
            _geoPosition.Latitude = args.Position.Coordinate.Latitude;
            _geoPosition.Longitude = args.Position.Coordinate.Longitude;
            _geoPosition.TimeStamp = args.Position.Coordinate.Timestamp;
            Debug.WriteLine("Geo PositionChanged:" + " " + _geoPosition.Latitude + " " + _geoPosition.Longitude + " " +
                            _geoPosition.TimeStamp);
        }
    }
}