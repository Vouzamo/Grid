using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Fields
{
    public class DecimalField : Field<decimal>
    {
        public DecimalField(string name) : base(name, FieldType.Decimal)
        {

        }

        public override bool Validate(string raw, out decimal value)
        {
            return decimal.TryParse(raw, out value);
        }
    }
}
