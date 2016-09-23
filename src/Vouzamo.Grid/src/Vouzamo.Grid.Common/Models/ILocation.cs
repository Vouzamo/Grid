using System;

namespace Vouzamo.Grid.Common.Models
{
    public interface ILocation
    {
        string Grid { get; }
        string Path { get; }
        Point3D Position { get; }
    }
}
