using System;
using BethanysPieShopHRM.ComponentsLibrary.Map;

namespace TMS.UI.Services
{
    public class LocationService : ILocationService
    {
        public Marker GetMarkerFromPlace(string place)
        {
            switch (place.ToLowerInvariant())
            {
                case "bydgoszcz":
                    return new Marker
                    {
                        Description = $"Huuge Arena",
                        ShowPopup = false,
                        X = Double.Parse("18.0084"),
                        Y = Double.Parse("53.1235")
                    };
                case "toruń":
                    return new Marker
                    {
                        Description = $"Toruń Brązowy Cukier place",
                        ShowPopup = false,
                        X = Double.Parse("18.5984"),
                        Y = Double.Parse("53.0138")
                    };
                default:
                    return new Marker
                    {
                        Description = $"Śliwice Arena",
                        ShowPopup = false,
                        X = Double.Parse("18.1803"),
                        Y = Double.Parse("53.7090")
                    };
            }
        }
    }
}