using System;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Plugin.Geolocator.Abstractions.Position;

namespace app5.Sevices
{
    public static class Geolocation
    {
        public static Position Position { get; set; }
        public static IGeolocator locator;

        static Geolocation()
        {
             GetPositionAsync();
            //locator.PositionChanged += LocatorOnPositionChanged;
        }

        public static async Task<Position> GetPositionAsync()
        {
            try
            {
                if (Position != null)
                {

                    return Position;
                }
                locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                //return await locator.GetPositionAsync(10000);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }

        private static void LocatorOnPositionChanged(object sender, PositionEventArgs positionEventArgs)
        {

            Position = positionEventArgs.Position;
        }
    }
}
