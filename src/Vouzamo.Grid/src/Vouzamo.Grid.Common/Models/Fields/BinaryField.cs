using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Fields
{
    public class BinaryField : Field<string>
    {
        public BinaryField(string name) : base(name, FieldType.Binary)
        {

        }

        public override bool Validate(string raw, out string value)
        {
            value = raw;
            return true;
        }
    }
}
