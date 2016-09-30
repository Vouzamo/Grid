﻿using System;
using System.Collections.Generic;

namespace Vouzamo.Grid.Common.Models
{
    public interface IItem
    {
        Guid Id { get; }

        string Name { get; }
        IItemType Type { get; }

        List<ItemFieldValue> Values { get; }
    }
}
