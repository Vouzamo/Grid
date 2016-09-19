using System;
using System.Collections.Generic;
using Vouzamo.Grid.Core.Extensions;
using Vouzamo.Grid.Core.Models;
using Vouzamo.Grid.Core.Models.Items;

namespace Vouzamo.Grid.Core.Services
{
    public interface IGridService
    {
        IEnumerable<ItemInstance> GetItems(ILocation location, double range);
    }

    public class GridService : IGridService
    {
        protected Random Random { get; set; }

        public GridService()
        {
            Random = new Random();
        }

        public IEnumerable<ItemInstance> GetItems(ILocation location, double range)
        {
            var items = new List<ItemInstance>();

            for(int i = 1; i < range; i++)
            {
                var x = Random.NextDouble(location.Position.X - range, location.Position.X + range);
                var y = Random.NextDouble(location.Position.Y - range, location.Position.Y + range);
                var z = Random.NextDouble(location.Position.Z - range, location.Position.Z + range);

                var point = new Point3D(x, y, z);

                var itemLocation = new Location(location.Grid, location.Path, point);
                var item = new WarpItem($"Warp Item {i}", new Location(location.Grid, location.Path, Point3D.Zero));

                items.Add(new ItemInstance(itemLocation, item));
            }

            return items;
        }
    }
}
