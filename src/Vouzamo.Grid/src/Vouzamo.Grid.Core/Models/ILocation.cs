using System;

namespace Vouzamo.Grid.Core.Models
{
    public interface ILocation
    {
        Guid Id { get; }

        string Grid { get; }
        string Path { get; }
        Point3D Position { get; }
    }
}
