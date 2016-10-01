using System;
using System.Collections.Generic;

namespace Vouzamo.Grid.Common.Models.Items
{
    public class Item : IItem
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IItemType Type { get; protected set; }
        public Location Location { get; protected set; }
        public List<FieldValue> Values { get; }

        public Item(string name, IItemType type, Location location)
        {
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Location = location;
            Values = new List<FieldValue>();
        }

        public virtual IItemAction Invoke(Location location)
        {
            return Type.Invoke(location, this);
        }
    }
}
