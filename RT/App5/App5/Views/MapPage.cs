using System.Diagnostics;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;
using PositionGEO = Plugin.Geolocator.Abstractions.Position;
namespace app5.Views
{
    public class MapPage : ContentPage
    {
        public Map map { get; set; }
        public IGeolocator locator { get; set; }
        public PositionGEO Position { get; set; }
        public MapPage()
        {
            map = new Map(
                MapSpan.FromCenterAndRadius(
                    new Position(55.7565436, 21.8992711 ), Distance.FromMeters(605)));
            Content = map;
            addPins();
            AddMy();
            map.MapType = MapType.Satellite;

        }

        public async void AddMy()
        {
            locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;
            locator.PositionChanged += position_Changed;
            await locator.StartListeningAsync(minTime: 2000, minDistance: 50);
        }

        // Callback function for when GPS location changes
        void position_Changed(object obj, PositionEventArgs e)
        {
            updateGPSDataList(e.Position);
            var pin2 = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(e.Position.Latitude, e.Position.Longitude),
                Label = "shop1!"+e.Position.Latitude,
                Address = "addres1"+ e.Position.Longitude

            };
            map.Pins.Add(pin2);
            RefreshMap(e.Position);
            DisplayAlert("ok", locator.DesiredAccuracy.ToString(), "ok");
        }

        // Update GPS location displays and database
        private void updateGPSDataList(PositionGEO position)
        {
            Debug.WriteLine("Position changed: " + position.Latitude);
        }

        public void RefreshMap(PositionGEO position)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Xamarin.Forms.Maps.Distance.FromMeters(605)));
            // locator.DesiredAccuracy = locator.DesiredAccuracy / 2;
           // map. .RouteCoordinates.Add(new Position(37.776831, -122.394627));
        }
        public void  addPins()
        {
            var pin1 = new Pin()
            {

                Position = new Position(55.7515436, 21.8992711),
                Label = "Shop1!",
                Address = "addres1"

            };
            var pin2 = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(55.7515436, 21.8982711),
                Label = "Shop2!",
                Address = "addres2"

            };
            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
        }
    }
}