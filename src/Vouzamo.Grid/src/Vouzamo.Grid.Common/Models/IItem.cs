using System;
using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models
{
    public interface IItem
    {
        Guid Id { get; }

        string Name { get; }
        ItemType Type { get; }

        IAction Invoke(ILocation location);
    }
}
