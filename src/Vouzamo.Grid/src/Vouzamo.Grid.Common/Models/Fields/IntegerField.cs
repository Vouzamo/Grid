using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Fields
{
    public class IntegerField : Field<int>
    {
        public IntegerField(string name) : base(name, FieldType.Integer)
        {

        }

        public override bool Validate(string raw, out int value)
        {
            return int.TryParse(raw, out value);
        }
    }
}
