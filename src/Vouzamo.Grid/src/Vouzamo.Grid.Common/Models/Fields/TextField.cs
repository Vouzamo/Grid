using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Fields
{
    public class TextField : Field<string>
    {
        public TextField(string name) : base(name, FieldType.Text)
        {

        }

        public override bool Validate(string raw, out string value)
        {
            value = raw;
            return true;
        }
    }
}
