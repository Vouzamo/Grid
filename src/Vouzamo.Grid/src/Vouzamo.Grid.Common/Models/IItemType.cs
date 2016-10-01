using System;
using System.Collections.Generic;

namespace Vouzamo.Grid.Common.Models
{
    public interface IItemType
    {
        Guid Id { get; }

        string Name { get; }
        List<IField> Fields { get; }

        IItemAction Invoke(Location location, IItem item);
    }
}