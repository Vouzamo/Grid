using System;

namespace Vouzamo.Grid.Core.Models
{
    public class Location : ILocation
    {
        public Guid Id { get; protected set; }
        public string Grid { get; protected set; }
        public string Path { get; protected set; }
        public Point3D Position { get; protected set; }

        private Location()
        {
            Id = Guid.NewGuid();
        }

        public Location(string grid, string path, Point3D position) : this()
        {
            Grid = grid;
            Path = path;
            Position = position;
        }
    }
}
