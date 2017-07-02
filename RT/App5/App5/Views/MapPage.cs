using System;
using Plugin.Geolocator;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace app5.Views
{



    public class MapPage : ContentPage
    {
        public Map map { get; set; }
        public MapPage()
        {
            map = new Map(
                MapSpan.FromCenterAndRadius(
                    new Position(55.7565436, 21.8992711 ), Distance.FromMeters(605)));
            Content = map;
            map.MapType = MapType.Satellite;
            var pin1 = new Pin()
            {
                
                Position = new Position(55.7515436, 21.8992711),
                Label = "Kababine!",
                Address = "kašakas"

            };
            var pin2 = new Pin()
            {
                Type = PinType.Place,
                Position = new Position(55.7515436, 21.8982711),
                Label = "Arbuzine!",
                Address = "dod"

            };

            Get();
            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
        }

        public async void Get()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 10;
                var position = await locator.GetPositionAsync(10000);

                if (position != null)
                {
                    DisplayAlert("get", position.ToString(), "OK");
                    map.Pins.Add(new Pin()
                    {
                        Type = PinType.Place,
                        Position = new Position(position.Latitude, position.Longitude),
                        Label = "Aš!",
                        Address = "cia"

                    });
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),Distance.FromMeters(605)));
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Error", e.ToString(), "OK");
            }     
        }
    }
}