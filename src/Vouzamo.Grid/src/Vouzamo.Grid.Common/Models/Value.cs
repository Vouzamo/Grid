using System;

namespace Vouzamo.Grid.Common.Models
{
    public class ItemFieldValue
    {
        public Guid FieldId { get; protected set; }
        public string Value { get; protected set; }

        public ItemFieldValue(Guid fieldId, string value)
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}