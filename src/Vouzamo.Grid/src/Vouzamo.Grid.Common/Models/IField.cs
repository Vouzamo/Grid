using System;
using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models
{
    public interface IField
    {
        string Name { get; }
        FieldType Type { get; }
        bool Multivalue { get; }
        bool Mandatory { get; }
    }

    public interface IField<T> : IField where T : IComparable<T>
    {
        bool Validate(string raw, out T value);
    }
}