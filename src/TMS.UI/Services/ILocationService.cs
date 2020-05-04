using BethanysPieShopHRM.ComponentsLibrary.Map;

namespace TMS.UI.Services
{
    public interface ILocationService
    {
        Marker GetMarkerFromPlace(string place);
    }
}