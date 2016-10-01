using System;
using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Fields
{
    public class DateTimeField : Field<DateTime>
    {
        public DateTimeField(string name) : base(name, FieldType.DateTime)
        {

        }

        public override bool Validate(string raw, out DateTime value)
        {
            return DateTime.TryParse(raw, out value);
        }
    }
}
