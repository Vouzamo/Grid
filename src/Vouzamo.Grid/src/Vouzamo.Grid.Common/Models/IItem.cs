using System;
using System.Collections.Generic;

namespace Vouzamo.Grid.Common.Models
{
    public interface IItem
    {
        string Name { get; }
        IItemType Type { get; }
        Location Location { get; }
        List<FieldValue> Values { get; }
    }
}
