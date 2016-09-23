using System.Collections.Generic;
using Vouzamo.Grid.Common.Models;

namespace Vouzamo.Grid.Common.Services
{
    public interface IGridService
    {
        IEnumerable<ItemInstance> GetItems(ILocation location, double range);
    }
}
