using System;
using Vouzamo.Grid.Core.Enums;

namespace Vouzamo.Grid.Core.Models
{
    public interface IItem
    {
        Guid Id { get; }

        string Name { get; }
        ItemType Type { get; }

        IAction Invoke(ILocation location);
    }
}
