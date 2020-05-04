using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMS.UI.Shared.NavMenu
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItemModel>> GetMenu();
    }
}