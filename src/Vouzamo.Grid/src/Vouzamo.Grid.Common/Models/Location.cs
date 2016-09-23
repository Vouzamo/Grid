using System;

namespace Vouzamo.Grid.Common.Models
{
    public class Location : ILocation
    {
        public string Grid { get; protected set; }
        public string Path { get; protected set; }
        public Point3D Position { get; protected set; }

        private Location()
        {
            
        }

        public Location(string grid, string path, Point3D position) : this()
        {
            Grid = grid;
            Path = path;
            Position = position;
        }
    }

    public class ItemLocation : Location
    {
        public Guid ItemId { get; protected set; }

        public ItemLocation(string grid, string path, Point3D position, Guid itemId) : base(grid, path, position)
        {
            ItemId = itemId;
        }
    }
}
