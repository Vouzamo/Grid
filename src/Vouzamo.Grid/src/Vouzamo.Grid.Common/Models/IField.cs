using System;
using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models
{
    public class ItemField
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        public FieldType Type { get; protected set; }
        public bool Multivalue { get; set; }
        public bool Mandatory { get; set; }

        protected ItemField()
        {
            Id = Guid.NewGuid();
            Multivalue = false;
            Mandatory = false;
        }

        public ItemField(string name, FieldType type = FieldType.Text) : this()
        {
            Name = name;
            Type = type;
        }
    }
}