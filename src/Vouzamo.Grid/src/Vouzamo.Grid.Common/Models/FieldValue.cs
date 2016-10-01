namespace Vouzamo.Grid.Common.Models
{
    public class FieldValue
    {
        public string Field { get; protected set; }
        public string Value { get; protected set; }

        public FieldValue(string field, string value)
        {
            Field = field;
            Value = value;
        }
    }
}