using System;
using System.Collections.Generic;
using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Items
{
    public abstract class Item : IItem
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public IItemType Type { get; protected set; }

        public List<ItemFieldValue> Values { get; }

        private Item()
        {
            Id = Guid.NewGuid();
            Values = new List<ItemFieldValue>();
        }

        protected Item(string name, IItemType type) : this()
        {
            Name = name;
            Type = type;
        }

        public abstract IItemAction Invoke(ILocation location);
    }
}
