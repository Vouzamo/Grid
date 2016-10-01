using System;
using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Fields
{
    public abstract class Field<T> : IField<T> where T : IComparable<T>
    {
        public string Name { get; protected set; }
        public FieldType Type { get; protected set; }
        public bool Multivalue { get; set; }
        public bool Mandatory { get; set; }

        protected Field(string name, FieldType type)
        {
            Multivalue = false;
            Mandatory = false;

            Name = name;
            Type = type;
        }

        public abstract bool Validate(string raw, out T value);
    }
}
