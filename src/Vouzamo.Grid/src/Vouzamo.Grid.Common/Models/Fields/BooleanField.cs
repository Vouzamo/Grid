using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Fields
{
    public class BooleanField : Field<bool>
    {
        public BooleanField(string name) : base(name, FieldType.Boolean)
        {

        }

        public override bool Validate(string raw, out bool value)
        {
            return bool.TryParse(raw, out value);
        }
    }
}
