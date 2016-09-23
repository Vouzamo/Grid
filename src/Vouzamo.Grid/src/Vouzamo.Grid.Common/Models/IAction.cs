using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models
{
    public interface IAction
    {
        ActionType Type { get; }
    }
}
