namespace Vouzamo.Grid.Common.Models
{
    public class Location
    {
        public string Grid { get; protected set; }
        public string Path { get; protected set; }
        public Point3D Position { get; protected set; }

        public Location(string grid, string path, Point3D position)
        {
            Grid = grid;
            Path = path;
            Position = position;
        }
    }
}
