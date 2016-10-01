using System;
using System.Collections.Generic;
using System.Linq;
using Vouzamo.Grid.Common.Models;

namespace Vouzamo.Grid.Common.Helpers
{
    public static class FieldHelper
    {
        public static T GetField<T>(this IEnumerable<IField> fields, string fieldName) where T : IField
        {
            return fields.OfType<T>().Single(x => x.Name == fieldName);
        }

        public static T GetValue<T>(this IField<T> field, IEnumerable<FieldValue> itemValues) where T : IComparable<T>
        {
            var value = default(T);

            var itemValue = itemValues.FirstOrDefault(x => x.Field == field.Name);

            if(itemValue != null)
            {
                field.Validate(itemValue.Value, out value);
            }

            return value;
        }

        public static IEnumerable<T> GetValues<T>(this IField<T> field, IEnumerable<FieldValue> itemValues) where T : IComparable<T>
        {
            var values = new List<T>();

            foreach(var itemValue in itemValues.Where(x => x.Field == field.Name))
            {
                T value;
                if(field.Validate(itemValue.Value, out value))
                {
                    values.Add(value);
                }
            }

            return values;
        }
    }
}
