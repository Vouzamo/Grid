using System;
using System.Collections.Generic;
using Vouzamo.Grid.Common.Enums;
using Vouzamo.Grid.Common.Models.Actions;
using Vouzamo.Grid.Common.Models.Items;

namespace Vouzamo.Grid.Common.Models.ItemTypes
{
    public abstract class ItemType : IItemType
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public List<IField> Fields { get; protected set; }

        protected ItemType()
        {
            Id = Guid.NewGuid();
            Fields = new List<IField>();
        }

        protected ItemType(string name) : this()
        {
            Name = name;
        }

        public virtual IItemAction Invoke(Location location, IItem itemInstance)
        {
            return new ItemAction(ActionType.NoAction);
        }

        public virtual IItem CreateItem(string name, Location location)
        {
            return new Item(name, this, location);
        }
    }
}
