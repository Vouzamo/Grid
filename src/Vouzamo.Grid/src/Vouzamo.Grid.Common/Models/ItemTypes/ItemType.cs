using System;
using System.Collections.Generic;
using Vouzamo.Grid.Common.Enums;
using Vouzamo.Grid.Common.Models.Actions;

namespace Vouzamo.Grid.Common.Models.ItemTypes
{
    public abstract class ItemType : IItemType
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public List<ItemField> Fields { get; protected set; }

        protected ItemType()
        {
            Id = Guid.NewGuid();
            Fields = new List<ItemField>();
        }

        protected ItemType(string name) : this()
        {
            Name = name;
        }

        public virtual IItemAction Invoke(ItemInstance itemInstance)
        {
            return new ItemAction(ActionType.NoAction);
        }
    }
}
