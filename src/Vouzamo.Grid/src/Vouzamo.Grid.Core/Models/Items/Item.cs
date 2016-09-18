using System;
using Vouzamo.Grid.Core.Enums;

namespace Vouzamo.Grid.Core.Models.Items
{
    public abstract class Item : IItem
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public ItemType Type { get; protected set; }

        private Item()
        {
            Id = Guid.NewGuid();
        }

        protected Item(string name, ItemType type) : this()
        {
            Name = name;
            Type = type;
        }

        public abstract IAction Invoke(ILocation location);
    }
}
