using System.Collections.Generic;
using Vouzamo.Grid.Common.Models;

namespace Vouzamo.Grid.Common.Services
{
    public interface IGridService
    {
        IEnumerable<IItem> GetItems(Location location, double range);
    }
}
